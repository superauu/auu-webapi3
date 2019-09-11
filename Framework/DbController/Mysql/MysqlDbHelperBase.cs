using DapperExtensions.Sql;
using MySql.Data.MySqlClient;

namespace Auu.Framework.DbControllers.Mysql
{
    public abstract class MysqlDbHelperBase
    {
        private string _connString;

        protected MysqlDbHelperBase(string connString)
        {
            _connString = connString;
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
        }

        protected MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(_connString);
            connection.Open();
            return connection;
        }

        protected void SetConnString(string connString)
        {
            _connString = connString;
        }
    }
}