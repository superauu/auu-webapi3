namespace Auu.Models.System.Backup.Admin
{
    /// <summary>
    ///     登录信息实体类
    /// </summary>
    public class ClientLoginInfo
    {
        /// <summary>
        ///     账号
        /// </summary>
        /// <returns></returns>
        public string AccountName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        /// <returns></returns>
        public string Password { get; set; }

        /// <summary>
        ///     客户端类型M手机，P电脑
        /// </summary>
        /// <returns></returns>
        public string ClientType { get; set; }

        /// <summary>
        ///     手机端推送编号
        /// </summary>
        /// <returns></returns>
        public string AppId { get; set; }
    }
}