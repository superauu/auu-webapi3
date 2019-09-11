namespace  Auu.Models.System.Backup.Admin.SystemSetup
{
    /// <summary>
    ///     模块实体类
    /// </summary>
    public class T_Module
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        ///     中文显示名
        /// </summary>
        /// <returns></returns>
        public string DisplayName { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        /// <returns></returns>
        public string Descr { get; set; }

        /// <summary>
        ///     模块是否可用1可用0删除
        /// </summary>
        /// <returns></returns>
        public int Visible { get; set; }
    }
}