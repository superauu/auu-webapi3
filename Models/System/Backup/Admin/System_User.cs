namespace  Auu.Models.System.Backup.Admin
{
    /// <summary>
    ///     登录结果
    /// </summary>
    public class ALoginResult
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
        ///     SessionId
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        ///     用户信息
        /// </summary>
        public MUser User { get; set; }
    }

    /// <summary>
    ///     登录结果
    /// </summary>
    public class UserResult
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
        ///     用户信息
        /// </summary>
        public System_User[] Users { get; set; }

        /// <summary>
        ///     总用户数
        /// </summary>
        public long Count { get; set; }
    }

    /// <summary>
    ///     用户信息类
    /// </summary>
    public class System_User
    {
        /// <summary>
        ///     系统编号
        /// </summary>
        public string Oid { get; set; }

        /// <summary>
        ///     用户登录名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     角色权限
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     账号状态0正常，1停用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///     账号头像
        /// </summary>
        public string HeadImg { get; set; }

        /// <summary>
        ///     手机号
        /// </summary>
        public string Phone { get; set; }
    }

    /// <summary>
    ///     用户状态信息类
    /// </summary>
    public class System_User_Temp
    {
        /// <summary>
        ///     系统编号
        /// </summary>
        public int Oid { get; set; }

        /// <summary>
        ///     账号状态0正常，1停用
        /// </summary>
        public int Status { get; set; }
    }
}