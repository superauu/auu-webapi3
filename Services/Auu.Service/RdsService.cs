using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auu.Framework.Common;
using Auu.Framework.Common.Log;
using Auu.Framework.DbControllers.Base;
using Auu.Models.System;
using Auu.PlugIn.Cloud.Base;

namespace Auu.Service
{
    public class RdsService
    {
        public ICloudRds Rds { get; set; }
        public ILogHelper LogHelper { get; set; }

        public IEnumerable<string> GetRegions()
        {
            return Rds.DescribeRegions(); //目前不需要，我们选定一个区域就好了。
        }

        public async Task CreateDataBase(IDbHelper db, SysCustomerInfo customerInfo)
        {
            var instants = Rds.GetDbInstances(GlobalVar.RegionID);
            //找一个没满的实例
            foreach (var instant in instants)
            {
                var dbCount = Rds.GetDatabaseCountByInstanceId(instant);
                if (dbCount < GlobalVar.MaxRdsDbNumbers)
                {
                    var dbName = Encrypt.Md5(Guid.NewGuid().ToString());
                    await Task.Run(
                        () => Rds.CreateDatabase(instant, dbName, customerInfo.Id, GlobalVar.RdsAdminAccount));
                    customerInfo.RdsId = instant;
                    customerInfo.Database = dbName;
                    customerInfo.CurrentVersion = 0;
                    customerInfo.ConnString = ""; //todo 需要一个instance的地址列表
                    db.Update(customerInfo);
                    return;
                }
            }

            throw new Exception("All Instances are full.");
        }

        //这个方法比较危险
        public bool DeleteDataBase(IDbHelper db, SysCustomerInfo customerInfo)
        {
            try
            {
                Rds.DeleteDatabase(customerInfo.RdsId, customerInfo.Database);
                customerInfo.Status = ServiceStatus.Released;
                db.Update(customerInfo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int InitDataBase(IDbHelper sysDb, IDbHelper userDb, SysCustomerInfo customerInfo)
        {
            var scripts = sysDb.QueryList<SysDbScript>($"select * from SysDbScript order by Version");
            var result = 0;

            if (scripts.Count > 0)
                foreach (var sql in scripts)
                {
                    sysDb.BeginTrans();
                    userDb.BeginTrans();
                    try
                    {
                        result += userDb.Execute(sql.Script);
                        customerInfo.CurrentVersion = sql.Version;
                        sysDb.Update(customerInfo);
                        var status = new SysDbScriptExecutionStatus();
                        status.Id = Guid.NewGuid().ToString();
                        status.DbName = customerInfo.Database;
                        status.ScriptVersion = sql.Version;
                        status.Success = true;
                        status.ExecuteDateTime = DateTime.Now;

                        sysDb.Insert(status);
                        userDb.Commit();
                        sysDb.Commit();
                    }
                    catch (Exception ex)
                    {
                        sysDb.Rollback();
                        LogHelper.LogError(ex);
                        userDb.Rollback();
                        var status = new SysDbScriptExecutionStatus();
                        status.Id = Guid.NewGuid().ToString();
                        status.DbName = customerInfo.Database;
                        status.ScriptVersion = sql.Version;
                        status.Success = false;
                        status.ExecuteDateTime = DateTime.Now;
                        status.Log = ex.Message;
                        sysDb.Insert(status); //回滚之后重新插入
                    }
                }

            return result;
        }

        public void UpdateAllDb(IDbHelper sysDb, IDbHelper userDb)
        {
            var customerList =
                sysDb.QueryList<SysCustomerInfo>(
                    $"select * from sysCustomerInfo where status <> {(int) ServiceStatus.Released} and status <> {(int) ServiceStatus.CreatingDb} and status <> {(int) ServiceStatus.CreateDbFailed}");
            var scripts = sysDb.QueryList<SysDbScript>($"select * from SysDbScript order by Version");

            //所有数据库都要更新，包括已经过期的用户
            if (customerList != null)
                foreach (var customerInfo in customerList)
                {
                    userDb.SetConnString(customerInfo.ConnString);
                    var scriptsNeedRun = scripts.Where(s => s.Version > customerInfo.CurrentVersion)
                        .OrderBy(s => s.Version).ToList();
                    foreach (var script in scriptsNeedRun)
                    {
                        userDb.BeginTrans();
                        try
                        {
                            userDb.Execute(script.Script);
                            sysDb.BeginTrans();
                            customerInfo.CurrentVersion = script.Version;
                            sysDb.Update(customerInfo);
                            var status = new SysDbScriptExecutionStatus();
                            status.Id = Guid.NewGuid().ToString();
                            status.DbName = customerInfo.Database;
                            status.ScriptVersion = script.Version;
                            status.Success = true;
                            status.ExecuteDateTime = DateTime.Now;
                            sysDb.Insert(status);
                            userDb.Commit();
                            sysDb.Commit();
                        }
                        catch (Exception ex)
                        {
                            sysDb.Rollback();
                            LogHelper.LogError(ex);
                            userDb.Rollback();
                            var status = new SysDbScriptExecutionStatus();
                            status.Id = Guid.NewGuid().ToString();
                            status.DbName = customerInfo.Database;
                            status.ScriptVersion = script.Version;
                            status.Success = false;
                            status.ExecuteDateTime = DateTime.Now;
                            status.Log = ex.Message;
                            sysDb.Insert(status); //回滚之后重新插入
                            break;
                        }
                    }
                }
        }
    }
}