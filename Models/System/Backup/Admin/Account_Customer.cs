namespace  Auu.Models.System.Backup.Admin
{
    /// <summary>
    ///     用户和客户组织对应实体类
    /// </summary>
    public class Account_Customer
    {
        /// <summary>
        ///     用户账号
        /// </summary>
        /// <returns></returns>
        public string UserAccount { get; set; }

        /// <summary>
        ///     客户组织oid
        /// </summary>
        /// <returns></returns>
        public int CustomerOid { get; set; }
    }
}