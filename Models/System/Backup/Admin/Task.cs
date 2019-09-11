using System;

namespace  Auu.Models.System.Backup.Admin
{
    /// <summary>
    ///     工单实体类
    /// </summary>
    public class Task
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     客户编号
        /// </summary>
        /// <returns></returns>
        public int CustomerId { get; set; }

        /// <summary>
        ///     客户名称
        /// </summary>
        /// <returns></returns>
        public string CustomerName { get; set; }

        /// <summary>
        ///     提问人账号
        /// </summary>
        /// <returns></returns>
        public string UserAccount { get; set; }

        /// <summary>
        ///     问题类别编号
        /// </summary>
        /// <returns></returns>
        public int ModalId { get; set; }

        /// <summary>
        ///     问题类别名称
        /// </summary>
        /// <returns></returns>
        public string ModalName { get; set; }

        /// <summary>
        ///     工单标题
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }

        /// <summary>
        ///     工单正文内容
        /// </summary>
        /// <returns></returns>
        public string Content { get; set; }

        /// <summary>
        ///     工单创建日期时间
        /// </summary>
        /// <returns></returns>
        public DateTime CreateDatetime { get; set; }

        /// <summary>
        ///     工单状态 0开启，1进行中，2已解决，3关闭，4重新打开
        /// </summary>
        /// <returns></returns>
        public int Status { get; set; }
    }

    /// <summary>
    ///     单条工单结果
    /// </summary>
    public class TaskResult : CommonResult
    {
        /// <summary>
        ///     工单
        /// </summary>
        /// <returns></returns>
        public Task task { get; set; }
    }

    /// <summary>
    ///     多条工单结果
    /// </summary>
    public class TasksResult : CommonResult
    {
        /// <summary>
        ///     工单列表
        /// </summary>
        /// <returns></returns>
        public Task[] tasks { get; set; }

        /// <summary>
        ///     总数量
        /// </summary>
        /// <returns></returns>
        public long Count { get; set; }
    }

    /// <summary>
    ///     工单回复追问实体类
    /// </summary>
    public class Task_Answer
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     工单编号
        /// </summary>
        /// <returns></returns>
        public int TaskId { get; set; }

        /// <summary>
        ///     回复或追问内容
        /// </summary>
        /// <returns></returns>
        public string Answer { get; set; }

        /// <summary>
        ///     回复或追问人账号
        /// </summary>
        /// <returns></returns>
        public string User { get; set; }

        /// <summary>
        ///     标记追问还是回复，0回复，1追问
        /// </summary>
        /// <returns></returns>
        public int Flag { get; set; }

        /// <summary>
        ///     回复日期时间
        /// </summary>
        /// <returns></returns>
        public DateTime CreateDatetime { get; set; }
    }

    /// <summary>
    ///     回答列表
    /// </summary>
    public class TaskAnswersResult : CommonResult
    {
        /// <summary>
        ///     回答列表
        /// </summary>
        /// <returns></returns>
        public Task_Answer[] task_Answer { get; set; }
    }

    /// <summary>
    ///     回答
    /// </summary>
    public class TaskAnswerResult : CommonResult
    {
        /// <summary>
        ///     回答
        /// </summary>
        /// <returns></returns>
        public Task_Answer task_Answer { get; set; }
    }

    /// <summary>
    ///     工单日志实体类
    /// </summary>
    public class Task_Log
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     工单编号
        /// </summary>
        /// <returns></returns>
        public int TaskId { get; set; }

        /// <summary>
        ///     工单日志发生时间
        /// </summary>
        /// <returns></returns>
        public DateTime CreateDatetime { get; set; }

        /// <summary>
        ///     工单状态
        /// </summary>
        /// <returns></returns>
        public int Status { get; set; }

        /// <summary>
        ///     工单日志描述
        /// </summary>
        /// <returns></returns>
        public string Descr { get; set; }
    }


    /// <summary>
    ///     单条工单集合结果
    /// </summary>
    public class TaskMainResult : CommonResult
    {
        /// <summary>
        ///     工单
        /// </summary>
        /// <returns></returns>
        public Task task { get; set; }

        /// <summary>
        ///     工单日志集合
        /// </summary>
        /// <returns></returns>
        public Task_Log[] task_logs { get; set; }

        /// <summary>
        ///     回答列表
        /// </summary>
        /// <returns></returns>
        public Task_Answer[] task_answer { get; set; }
    }
}