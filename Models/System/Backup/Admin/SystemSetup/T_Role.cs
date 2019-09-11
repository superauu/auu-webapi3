namespace  Auu.Models.System.Backup.Admin.SystemSetup
{
    /// <summary>
    ///     角色表实体类
    /// </summary>
    public class T_Role
    {
        /// <summary>
        ///     编号自增长
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     角色名
        ///     ///
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        ///     角色描述
        /// </summary>
        /// <returns></returns>
        public string Descr { get; set; }

        /// <summary>
        ///     角色是否可用0为可用1为不可用默认0
        ///     目前预留，实际没用，删除就是真的删除了
        ///     否则读取权限时候麻烦而且会产生大量垃圾
        ///     数据。
        /// </summary>
        /// <returns></returns>
        public int Visible { get; set; }
    }
}