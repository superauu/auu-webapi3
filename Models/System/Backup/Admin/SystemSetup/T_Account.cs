namespace  Auu.Models.System.Backup.Admin.SystemSetup
{
    /// <summary>
    ///     账号表实体类
    /// </summary>
    public class T_Account
    {
        /// <summary>
        ///     编号自增长
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     账号名
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        /// <returns></returns>
        public string Password { get; set; }

        /// <summary>
        ///     员工ID
        /// </summary>
        /// <returns></returns>
        public int Employeeid { get; set; }

        /// <summary>
        ///     账号标识位：0为可用，1：不可用
        /// </summary>
        /// <returns></returns>
        public int Visible { get; set; }
    }
}