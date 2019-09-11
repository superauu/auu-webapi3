namespace  Auu.Models.System.Backup.Admin.SystemSetup
{
    /// <summary>
    ///     T_User_WR
    /// </summary>
    public class T_User_WR
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Oid { get; set; }

        /// <summary>
        ///     部门状态 1-正常, 0-停用
        /// </summary>
        /// ///
        /// <returns></returns>
        public string DepartmentVisible { get; set; }

        /// <summary>
        ///     注册日期
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Regdate { get; set; }

        /// <summary>
        ///     头像地址
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Headimg { get; set; }

        /// <summary>
        ///     1-IM登录过, 0-未使用IM登录过
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Imlogin { get; set; }

        /// <summary>
        ///     性别  男, 女
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Sex { get; set; }

        /// <summary>
        ///     组织名称
        /// </summary>
        /// ///
        /// <returns></returns>
        public string GroupName { get; set; }

        /// <summary>
        ///     昵称
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        ///     组织编号
        /// </summary>
        /// ///
        /// <returns></returns>
        public string GroupOid { get; set; }

        /// <summary>
        ///     个人简介
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Info { get; set; }

        /// <summary>
        ///     手机号码
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Phone { get; set; }

        /// <summary>
        ///     是否有查看管理权限 1-有, 0-没有
        /// </summary>
        /// ///
        /// <returns></returns>
        public string IsManage { get; set; }

        /// <summary>
        ///     SessionID
        /// </summary>
        /// ///
        /// <returns></returns>
        public string SessionID { get; set; }

        /// <summary>
        ///     用户状态 1-正常, 0-停用
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Visible { get; set; }

        /// <summary>
        ///     组织状态  编号 1-正常, 0-停用
        /// </summary>
        /// ///
        /// <returns></returns>
        public string GroupVisible { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Username { get; set; }

        /// <summary>
        ///     部门编号
        /// </summary>
        /// ///
        /// <returns></returns>
        public string DepartmentOid { get; set; }

        /// <summary>
        ///     朋友圈背景图片地址
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Bjimg { get; set; }

        /// <summary>
        ///     邮箱
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Email { get; set; }

        /// <summary>
        ///     部门名称
        /// </summary>
        /// ///
        /// <returns></returns>
        public string DepartmentName { get; set; }

        /// <summary>
        ///     出生日期
        /// </summary>
        /// ///
        /// <returns></returns>
        public string Birthday { get; set; }

        /// <summary>
        ///     im用编号
        /// </summary>
        /// ///
        /// <returns></returns>
        public string ImUid { get; set; }
    }
}