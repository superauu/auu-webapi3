namespace  Auu.Models.System.Backup.Admin.SystemSetup
{
    /// <summary>
    ///     账号角色实体类
    /// </summary>
    public class T_Account_Role
    {
        /// <summary>
        ///     编号自增长
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     账号名称
        /// </summary>
        /// <returns></returns>
        public string AccountName { get; set; }

        /// <summary>
        ///     角色ID
        /// </summary>
        /// <returns></returns>
        public int RoleId { get; set; }
    }
}