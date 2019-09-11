using System;
using System.Threading;

namespace Auu.Framework.Notification
{
    /// <summary>
    ///     通知实体类
    /// </summary>
    public class NotificationModule
    {
        /// <summary>
        ///     通知的Oid主键
        /// </summary>
        /// <returns></returns>
        public long Oid { get; set; }

        /// <summary>
        ///     唯一Id用来后续的状态查询
        /// </summary>
        /// <returns></returns>
        public string Guid { get; set; }

        /// <summary>
        ///     通知标题
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }

        /// <summary>
        ///     通知正文
        /// </summary>
        /// <returns></returns>
        public string Message { get; set; }

        /// <summary>
        ///     发送人
        /// </summary>
        /// <returns></returns>
        public string Sender { get; set; }

        /// <summary>
        ///     接收人列表，可以一次性发送给多个人 登陆后只用登陆账号 未登陆 可传 电话
        /// </summary>
        /// <returns></returns>
        public string[] Receiver { get; set; }

        /// <summary>
        ///     通知方式，可以多选，pcsystem，pcapp，mobileapp不选也会通知到
        /// </summary>
        /// <returns></returns>
        public SendMethod[] SendMethods { get; set; }

        /// <summary>
        ///     发送时间
        /// </summary>
        /// <returns></returns>
        public DateTime SendDate { get; set; }

        /// <summary>
        ///     如果是有反馈的通知方式，那么记录读信息的时间,记录最早的阅读时间
        /// </summary>
        /// <returns></returns>
        public DateTime ReadDate { get; set; }

        /// <summary>
        ///     同ReadDate，记录是否已读，无论何种通知方式读了，都算已读
        /// </summary>
        /// <returns></returns>
        public bool IfRead { get; set; }

        /// <summary>
        ///     隐藏信息，保存跳转地址，详细信息id等内容
        /// </summary>
        /// <returns></returns>
        public string HideInformation { get; set; }

        /// <summary>
        ///     电话专用
        /// </summary>
        /// <returns></returns>
        public bool Voicebo { get; set; }

        /// 以下参数 个推专用
        /// <summary>
        ///     功能编号
        /// </summary>
        public string WOid { get; set; }

        /// <summary>
        ///     一类
        /// </summary>
        public string QiYong { get; set; }

        /// <summary>
        ///     二类
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     组织编号
        /// </summary>
        public string GroupOid { get; set; }

        /// <summary>
        ///     根据本类中的数据发送通知
        /// </summary>
        /// <param name="dbName">要把企业数据库名传进来</param>
        public void Push(string dbName)
        {
            var notifications = NotificationFactory.GetNotifications(SendMethods);
            //开启一个线程执行推送任务，避免阻塞主进程
            var task = new Thread(() =>
            {
                foreach (var notification in notifications) notification.Push(this);
            });
            task.Start();

            //Save(dbName);
        }

        //public string Push2 (string dbName)
        //{
        //    string vvv = "";
        //    var notifications = NotificationFactory.GetNotifications (this.SendMethods);
        //    foreach (var notification in notifications)
        //    {
        //        vvv = notification.Push2 (this);
        //    }
        //    return vvv;
        //}

        private void Save()
        {
//            var db = new DbEntityHelper();
//            db.Insert(this);
        }
    }
}