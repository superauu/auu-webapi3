using Auu.Framework.DbControllers.Base;

namespace Auu.Models.System
{
    public class SysUsers:IEntity
    {
        /// <summary>
        ///     系统编号
        /// </summary>
        public string Id { get; set; }

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
        public SysUserStatus Status { get; set; }

        /// <summary>
        ///     账号头像
        /// </summary>
        public string HeadImg { get; set; }

        /// <summary>
        ///     手机号
        /// </summary>
        public string Phone { get; set; }
    }
}