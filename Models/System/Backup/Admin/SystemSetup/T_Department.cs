namespace  Auu.Models.System.Backup.Admin.SystemSetup
{
    /// <summary>
    ///     部门信息实体类
    /// </summary>
    public class T_Department
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     部门名称
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        ///     部门职责
        /// </summary>
        /// <returns></returns>
        public string Descr { get; set; }

        /// <summary>
        ///     部门负责人编号
        /// </summary>
        /// <returns></returns>
        public int LeaderOid { get; set; }

        /// <summary>
        ///     是否启用0启用1停用
        /// </summary>
        /// <returns></returns>
        public int Visible { get; set; }

        /// <summary>
        ///     上级部门编号
        /// </summary>
        /// <returns></returns>
        public int Parent { get; set; }

        /// <summary>
        ///     部门类型
        /// </summary>
        /// <returns></returns>
        public string Type { get; set; }

        /// <summary>
        ///     组织结构层级
        /// </summary>
        /// <returns></returns>
        public int Layers { get; set; }

        /// <summary>
        ///     排序
        /// </summary>
        /// <returns></returns>
        public int Sequence { get; set; }
    }
}