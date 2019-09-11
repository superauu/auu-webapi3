using System;
using System.Collections.Generic;
using System.Threading;
using Auu.Framework.Common;
using Auu.Framework.Common.Log;
using Auu.Framework.DbControllers.Base;
using Auu.PlugIn.Cloud.Base;

namespace Auu.PlugIn.Cloud.AliyunApi
{
    /// <summary>
    ///     操作阿里云Rds数据库的api封装
    /// </summary>
    public class RdsController : ICloudRds
    {
        private readonly ApiParam _apiParam;

        public RdsController(ApiParam param)
        {
            _apiParam = param;
        }

        public IDbHelper DbHelper { get; set; }
        public ILogHelper LogHelper { get; set; }

        /// <summary>
        ///     在rds上创建数据库,此方法需要采用异步方式执行
        /// </summary>
        /// <returns></returns>
        public void CreateDatabase(string dbInstanceId, string dbName, string dbDesc, string adminAccount)
        {
            try
            {
                var result = Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam, "CreateDatabase",
                    "DBInstanceId=" + Encrypt.UrlEncode(dbInstanceId),
                    "DBName=" + Encrypt.UrlEncode(dbName),
                    "CharacterSetName=utf8",
                    "DBDescription=" + Encrypt.UrlEncode(dbDesc));

                var status = "";
                var flag = 0;
                while (status != "Running" && flag < 60) //等待一分钟
                {
                    status = GetDbStatus(dbInstanceId, dbName);
                    Thread.Sleep(1000);
                    flag++;
                }

                var grantResult = GrantAccountPrivilege(dbInstanceId, dbName, adminAccount);

                if (result.StartsWith("error") || !grantResult)
                    DbHelper.Execute(
                        $"update SysCustomerInfo set status=5 where `database` ='{dbName}'");
                else
                    DbHelper.Execute(
                        $"update SysCustomerInfo set status=0 where `database` ='{dbName}'");

            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
            }
        }

        /// <summary>
        ///     删除rds上数据库，要谨慎操作
        /// </summary>
        /// <param name="dbInstanceId">实例编号</param>
        /// <param name="dbName">数据库名</param>
        /// <returns></returns>
        public string DeleteDatabase(string dbInstanceId, string dbName)
        {
            if (dbName.Length < 32)
                throw new Exception("只能删除系统自动创建的数据库");
            return Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam, "DeleteDatabase",
                "DBInstanceId=" + Encrypt.UrlEncode(dbInstanceId),
                "DBName=" + Encrypt.UrlEncode(dbName));
        }

        /// <summary>
        ///     获取某实例中数据库数量
        /// </summary>
        /// <param name="dbInstanceId"></param>
        /// <returns></returns>
        public int GetDatabaseCountByInstanceId(string dbInstanceId)
        {
            var json = Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam, "DescribeDatabases",
                "DBInstanceId=" + Encrypt.UrlEncode(dbInstanceId));
            if (json.StartsWith("error"))
                return -1;
            return Json.GetPropertyCount(json, "DBName");
        }

        /// <summary>
        ///     获取某数据库状态
        /// </summary>
        /// <param name="dbInstanceId"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public string GetDbStatus(string dbInstanceId, string dbName)
        {
            var json = Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam, "DescribeDatabases",
                "DBInstanceId=" + Encrypt.UrlEncode(dbInstanceId));
            if (json.StartsWith("error"))
                return json;
            if (!(Json.GetObject<dynamic>(json).Databases.Database is IEnumerable<dynamic> dbs)) return json;
            foreach (var obj in dbs)
            {
                string str = obj.DBName.ToString();
                if (str == dbName)
                    return obj.DBStatus;
            }

            return json;
        }

        /// <summary>
        ///     获取区域编号列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> DescribeRegions()
        {
            var resul = Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam, "DescribeRegions");
            if (resul.StartsWith("error"))
                return null;

            if (!(Json.GetObject<dynamic>(resul).Regions.RDSRegion is IEnumerable<dynamic> reg)) return null;
            var result = new List<string>();
            foreach (var obj in reg)
            {
                string str = obj.RegionId.ToString();
                if (result.Contains(str))
                    continue;
                result.Add(str);
            }

            return result;
        }

        /// <summary>
        ///     获取制定地区的数据库实例列表
        /// </summary>
        /// <param name="regionId"></param>
        /// <returns>只返回实例id</returns>
        public IEnumerable<string> GetDbInstances(string regionId)
        {
            var json = Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam,
                "DescribeDBInstances", "RegionId=" + Encrypt.UrlEncode(regionId),
                "DBInstanceType=Primary", "PageSize=100");
            if (json.StartsWith("error"))
                return null;
            var reg = Json.GetObject<dynamic>(json).Items.DBInstance as IEnumerable<dynamic>;
            var result = new List<string>();
            if (reg == null) return result;
            foreach (var obj in reg)
            {
                string str = obj.DBInstanceId.ToString();
                if (result.Contains(str))
                    continue;
                result.Add(str);
            }

            return result;
        }

        /// <summary>
        ///     设置数据库的账号权限
        /// </summary>
        /// <returns></returns>
        public bool GrantAccountPrivilege(string dbInstanceId, string dbName, string accountName)
        {
            var json = Auu.PlugIn.Cloud.AliyunApi.AliyunApi.Request(_apiParam,
                "GrantAccountPrivilege",
                "DBInstanceId=" + dbInstanceId,
                "DBName=" + dbName,
                "AccountName=" + accountName,
                "AccountPrivilege=ReadWrite");
            return !json.StartsWith("error");
        }
    }
}