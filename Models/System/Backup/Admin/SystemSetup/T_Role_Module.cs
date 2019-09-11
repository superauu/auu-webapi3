namespace  Auu.Models.System.Backup.Admin.SystemSetup
{
    /// <summary>
    ///     角色权限表实体类
    /// </summary>
    public class T_Role_Module
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     角色编号
        /// </summary>
        /// <returns></returns>
        public int RoleId { get; set; }

        /// <summary>
        ///     模块编号
        /// </summary>
        /// <returns></returns>
        public int ModuleId { get; set; }

        /// <summary>
        ///     查询权限
        /// </summary>
        /// <returns></returns>
        public int IsInquire { get; set; }

        /// <summary>
        ///     添加权限
        /// </summary>
        /// <returns></returns>
        public int IsAdd { get; set; }

        /// <summary>
        ///     编辑权限
        /// </summary>
        /// <returns></returns>
        public int IsUpdate { get; set; }

        /// <summary>
        ///     删除权限
        /// </summary>
        /// <returns></returns>
        public int IsDelete { get; set; }

        /// <summary>
        ///     导出权限
        /// </summary>
        /// <returns></returns>
        public int IsExport { get; set; }

        /// <summary>
        ///     导入权限
        /// </summary>
        /// <returns></returns>
        public int IsImport { get; set; }

        /// <summary>
        ///     其它权限
        /// </summary>
        /// <returns></returns>
        public int IsOther { get; set; }
    }
}