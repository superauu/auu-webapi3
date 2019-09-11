namespace  Auu.Models.System.Backup.Admin
{
    /// <summary>
    ///     数据库脚本实体类
    /// </summary>
    public class Db_script
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        /// <returns></returns>
        public string Desc { get; set; }

        /// <summary>
        ///     脚本正文
        /// </summary>
        /// <returns></returns>
        public string Script { get; set; }

        /// <summary>
        ///     版本号
        /// </summary>
        /// <returns></returns>
        public float Version { get; set; }
    }

    /// <summary>
    ///     数据库脚本列表
    /// </summary>
    public class DbScriptResult
    {
        /// <summary>
        ///     状态码
        /// </summary>
        public string Scode { get; set; }

        /// <summary>
        ///     状态描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     客户详情
        /// </summary>
        public Db_script[] db_script { get; set; }
    }

    /// <summary>
    ///     数据库脚本单条返回
    /// </summary>
    public class DbScriptResultSingle
    {
        /// <summary>
        ///     状态码
        /// </summary>
        public string Scode { get; set; }

        /// <summary>
        ///     状态描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     客户详情
        /// </summary>
        public Db_script db_script { get; set; }
    }
}