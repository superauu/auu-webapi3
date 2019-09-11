using System;
using System.Collections.Generic;
using System.Linq;
using Auu.Framework.Common;
using Auu.Framework.DbControllers.Base;
using Dapper;
using DapperExtensions;
using MySql.Data.MySqlClient;
using SqlKata;
using SqlKata.Compilers;

namespace Auu.Framework.DbControllers.Mysql
{
    public class MysqlDbHelper : MysqlDbHelperBase, IDbHelper
    {
        private MySqlConnection _conn;
        private MySqlTransaction _trans;

        public MysqlDbHelper(string connString) : base(connString)
        {
        }

        public new void SetConnString(string connString)
        {
            base.SetConnString(connString);
        }

        /// <summary>
        ///     单挑插入更新或删除
        /// </summary>
        /// <param name="query">sql语句</param>
        /// <param name="obj">参数实体类</param>
        /// <returns></returns>
        /// null
        public int Execute<T>(string query, T obj = default)
        {
            if (IfTrans()) return _conn.Execute(query, obj, _trans);

            using (var connection = GetConnection())
            {
                return connection.Execute(query, obj);
            }
        }

        /// <summary>
        ///     单挑插入更新或删除
        /// </summary>
        /// <param name="query">sql语句</param>
        /// <returns></returns>
        /// null
        public int Execute(string query)
        {
            if (IfTrans()) return _conn.Execute(query, null, _trans);

            using (var connection = GetConnection())
            {
                return connection.Execute(query);
            }
        }

        public object Scalar(string query)
        {
            if (IfTrans()) return _conn.ExecuteScalar(query, null, _trans);

            using (var connection = GetConnection())
            {
                return connection.ExecuteScalar(query);
            }
        }

        /// <summary>
        ///     var query = connection.Query(Users)("select * from Users where UserName=@UserName", new { UserName = "jack" });
        ///     返回第一条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T QueryOne<T>(string sql, object obj = null)
        {
            if (IfTrans()) return _conn.Query<T>(sql, null, _trans).FirstOrDefault();

            using (var connection = GetConnection())
            {
                return connection.Query<T>(sql, obj)
                    .FirstOrDefault();
            }
        }

        public Compiler GetCompiler()
        {
            return new MySqlCompiler();
        }

        public Query GetQuery(string tbName)
        {
            return new Query(tbName);
        }

        /// <summary>
        ///     返回实体类列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<T> QueryList<T>(string sql, object obj = null)
        {
            if (IfTrans()) return _conn.Query<T>(sql, null, _trans).AsList();

            using (var connection = GetConnection())
            {
                return connection.Query<T>(sql, obj).AsList();
            }
        }

        /// <summary>
        ///     执行sql返回行列表，不用实体类
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="obj"></param>
        /// <returns>dynamic 列表</returns>
        public List<dynamic> QueryDynamicList(string sql, object obj = null)
        {
            if (IfTrans()) return _conn.Query(sql, null, _trans).AsList();

            using (var connection = GetConnection())
            {
                return connection.Query(sql, obj).AsList();
            }
        }

        /// <summary>
        ///     执行事务
        /// </summary>
        /// <param name="sqls">sql语句和参数的键值对数组</param>
        /// <returns></returns>
        public int ExecuteTransaction(Dictionary<string, object> sqls)
        {
            if (IfTrans())
            {
                var rows = 0;

                foreach (var item in sqls)
                    rows += _conn.Execute(item.Key, item.Value, _trans);

                return rows;
            }

            using (var connection = GetConnection())
            {
                var trans = connection.BeginTransaction();
                try
                {
                    var rows = 0;

                    foreach (var item in sqls)
                        rows += connection.Execute(item.Key, item.Value, trans);
                    trans.Commit();

                    return rows;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        ///     返回值是新的oid编号
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public dynamic Insert<T>(T entity) where T : class, IEntity
        {
            if (IfTrans())
            {
                return _conn.Insert(entity, _trans);
            }

            using (var connection = GetConnection())
            {
                try
                {
                    return connection.Insert(entity);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        /// <summary>
        ///     事务批量插入实体对象
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool Insert<T>(T[] entities) where T : class, IEntity
        {
            if (IfTrans())
            {
                foreach (var entity in entities)
                    _conn.Insert(entity, _trans);
                return true;
            }

            using (var connection = GetConnection())
            {
                var trans = connection.BeginTransaction();
                try
                {
                    foreach (var entity in entities)
                        connection.Insert(entity, trans);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }

                return true;
            }
        }

        public bool Update<T>(T entity) where T : class, IEntity
        {
            if (IfTrans())
            {
                return _conn.Update(entity,_trans);
            }
            
            using (var connection = GetConnection())
            {
                return connection.Update(entity);
            }
        }

        /// <summary>
        ///     事务批量更新实体对象
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool Update<T>(T[] entities) where T : class, IEntity
        {
            if (IfTrans())
            {
                foreach (var entity in entities)
                    _conn.Update(entity, _trans);
                return true;
            }
            
            using (var connection = GetConnection())
            {
                var trans = connection.BeginTransaction();
                try
                {
                    foreach (var entity in entities)
                        connection.Update(entity, trans);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }

                return true;
            }
        }

        public bool Delete<T>(T entity) where T : class, IEntity
        {
            if (IfTrans())
            {
                return _conn.Delete(entity,_trans);
            }
            
            using (var connection = GetConnection())
            {
                return connection.Delete(entity);
            }
        }

        /// <summary>
        ///     事务批量删除实体对象
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool Delete<T>(T[] entities) where T : class, IEntity
        {
            if (IfTrans())
            {
                foreach (var entity in entities)
                    _conn.Delete(entity, _trans);
                return true;
            }
            
            using (var connection = GetConnection())
            {
                var trans = connection.BeginTransaction();
                try
                {
                    foreach (var entity in entities)
                        connection.Delete(entity, trans);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }

                return true;
            }
        }

        public T Get<T>(T entity) where T : class, IEntity
        {
            if (IfTrans())
            {
                var result = _conn.Get<T>(entity,_trans);
                return result;
            }
            
            using (var connection = GetConnection())
            {
                var result = connection.Get<T>(entity);
                return result;
            }
        }

        public void SetKey<T>(string key, T obj)
        {
            var json = Json.GetJson(obj);
            if (!ExistKey(key))
            {
                Execute($"insert into SysKeyValues(Key_,Values_) values('{key}','{json}')");
            }
            else
            {
                Execute($"update SysKeyValues set Values_='{json}' where Key_='{key}'");
            }
        }

        public T GetKey<T>(string key)
        {
            var checker = QueryDynamicList($"select * from SysKeyValues where Key_='{key}'");
            if (checker != null && checker.Count >= 0)
            {
                var json = checker[0].Values_;
                return Json.GetObject<T>(json);
            }

            return default;
        }

        public bool ExistKey(string key)
        {
            var checker = QueryDynamicList($"select * from SysKeyValues where Key_='{key}'");
            if (checker == null || checker.Count == 0)
            {
                return false;
            }

            return true;
        }

        public void DeleteKey(string key)
        {
            Execute($"DELETE FROM SysKeyValues where Key_='{key}'");
        }

        //TODO: Need to be verified
        public IEnumerable<T> GetList<T>(object p) where T : class, IEntity
        {
            if (IfTrans())
            {
                return _conn.GetList<T>(p,null,_trans);
            }
            
            using (var conn = GetConnection())
            {
                return conn.GetList<T>(p);
            }
        }

        public void BeginTrans()
        {
            if (_conn != null)
                throw new Exception("Transaction has already began.");
            _conn = GetConnection();
            _trans = _conn.BeginTransaction();
        }

        public bool Commit()
        {
            try
            {
                _trans.Commit();
                return true;
            }
            finally
            {
                _trans.Dispose();
                _trans = null;
                _conn.Dispose();
                _conn = null;
            }
        }

        public bool Rollback()
        {
            try
            {
                _trans.Rollback();
                return true;
            }
            finally
            {
                _trans.Dispose();
                _trans = null;
                _conn.Dispose();
                _conn = null;
            }
        }

        private bool IfTrans()
        {
            if (_conn != null && _trans != null)
                return true;

            return false;
        }
    }
}