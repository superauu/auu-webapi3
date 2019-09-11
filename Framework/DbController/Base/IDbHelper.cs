using System.Collections.Generic;
using SqlKata;
using SqlKata.Compilers;

namespace Auu.Framework.DbControllers.Base
{
    public interface IDbHelper
    {
        void SetConnString(string connString);
        /// <summary>
        ///     单条插入更新或删除
        /// </summary>
        /// <param name="query">sql语句</param>
        /// <param name="obj">参数实体类</param>
        /// <returns>影响行数</returns>
        int Execute<T>(string query, T obj = default);

        int Execute(string query);
        object Scalar(string query);

        /// <summary>
        ///     var query = connection.Query(Users)("select * from Users where UserName=@UserName", new { UserName = "jack" });
        ///     返回第一条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        T QueryOne<T>(string sql, object obj = null);

        Compiler GetCompiler();
        Query GetQuery(string tbName);
        /// <summary>
        ///     返回实体类列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<T> QueryList<T>(string sql, object obj = null);

        /// <summary>
        ///     执行sql返回行列表，不用实体类
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="obj"></param>
        /// <returns>dynamic 列表</returns>
        List<dynamic> QueryDynamicList(string sql, object obj = null);

        /// <summary>
        ///     执行事务
        /// </summary>
        /// <param name="trans">sql语句和参数的键值对数组</param>
        /// <returns></returns>
        int ExecuteTransaction(Dictionary<string, object> trans);

        dynamic Insert<T>(T entity) where T : class, IEntity;
        bool Insert<T>(T[] entities) where T : class, IEntity;
        bool Update<T>(T entity) where T : class, IEntity;
        bool Update<T>(T[] entities) where T : class, IEntity;
        bool Delete<T>(T entity) where T : class, IEntity;
        bool Delete<T>(T[] entities) where T : class, IEntity;
        T Get<T>(T entity) where T : class, IEntity;
        void SetKey<T>(string key,T obj);
        T GetKey<T>(string key);
        bool ExistKey(string key);
        void DeleteKey(string key);

        IEnumerable<T> GetList<T>(object p) where T : class, IEntity;

        void BeginTrans();
        bool Commit();
        bool Rollback();
    }
}