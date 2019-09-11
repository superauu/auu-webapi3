namespace  Auu.Models.System.Backup.Admin
{
    /// <summary>
    ///     知识库实体类
    /// </summary>
    public class Knowledge
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     类别编号
        /// </summary>
        /// <returns></returns>
        public int ModalId { get; set; }

        /// <summary>
        ///     类别名称
        /// </summary>
        /// <returns></returns>
        public string ModalName { get; set; }

        /// <summary>
        ///     标题
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }

        /// <summary>
        ///     正文
        /// </summary>
        /// <returns></returns>
        public string Content { get; set; }
    }

    /// <summary>
    ///     添加用的实体类
    /// </summary>
    public class Knowledge2
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     类别编号
        /// </summary>
        /// <returns></returns>
        public int ModalId { get; set; }

        /// <summary>
        ///     标题
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }

        /// <summary>
        ///     正文
        /// </summary>
        /// <returns></returns>
        public string Content { get; set; }
    }

    /// <summary>
    ///     知识库详情结果类
    /// </summary>
    public class KnowledgeResult : CommonResult
    {
        /// <summary>
        ///     知识库详情
        /// </summary>
        /// <returns></returns>
        public Knowledge Knowledge { get; set; }
    }

    /// <summary>
    ///     知识库列表类
    /// </summary>
    public class KnowledgesResult : CommonResult
    {
        /// <summary>
        ///     总条数
        /// </summary>
        /// <returns></returns>
        public long Count { get; set; }

        /// <summary>
        ///     知识库列表
        /// </summary>
        /// <returns></returns>
        public Knowledge[] Knowledges { get; set; }
    }
}