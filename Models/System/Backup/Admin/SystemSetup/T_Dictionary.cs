namespace  Auu.Models.System.Backup.Admin.SystemSetup
{
    /// <summary>
    ///     字典表主表
    /// </summary>
    public class T_Dictionary
    {
        /// <summary>
        ///     字典主表Oid
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     字典表键
        ///     ///
        /// </summary>
        /// <returns></returns>
        public string Key { get; set; }

        /// <summary>
        ///     键的名称
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        ///     键的描述
        /// </summary>
        /// <returns></returns>
        public string Desc { get; set; }

        /// <summary>
        ///     指点表值
        /// </summary>
        /// <returns></returns>
        public T_Dictionary_Value[] Values { get; set; }
    }

    /// <summary>
    ///     字典表字表
    /// </summary>
    public class T_Dictionary_Value
    {
        /// <summary>
        ///     字典表字表Oid
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     字典表键
        /// </summary>
        /// <returns></returns>
        public string DKey { get; set; }

        /// <summary>
        ///     字典表值
        /// </summary>
        /// <returns></returns>
        public string DValue { get; set; }
    }
}