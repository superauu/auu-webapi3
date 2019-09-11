namespace  Auu.Models.System.Backup.Admin
{
    /// <summary>
    ///     工票与问题库类别实体类
    /// </summary>
    public class Modal
    {
        /// <summary>
        ///     主键编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     类别名
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        ///     类别描述
        /// </summary>
        /// <returns></returns>
        public string Desc { get; set; }
    }

    /// <summary>
    ///     类别结果类
    /// </summary>
    public class ModalResult : CommonResult
    {
        /// <summary>
        ///     类别
        /// </summary>
        /// <returns></returns>
        public Modal modal { get; set; }
    }

    /// <summary>
    ///     列别列表结果类
    /// </summary>
    public class ModalsResult : CommonResult
    {
        /// <summary>
        ///     类别
        /// </summary>
        /// <returns></returns>
        public Modal[] modal { get; set; }
    }
}