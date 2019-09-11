//using System;
//using System.Collections.Generic;
//using Auu.Framework.Common;
//using Auu.Framework.Common.Interfaces;
//
//namespace Auu.Framework.Notification
//{
//    /// <summary>
//    ///     pc端通知类
//    /// </summary>
//    public class PcAppNotification : INotification,ILogable
//    {
//        /// <summary>
//        ///     Pc端的通知，应用内和系统通知公用这一个方法
//        ///     将通知的内容按照接收人的帐号信息，保存在redis里
//        ///     客户端定时通过API访问通知列表
//        /// </summary>
//        /// <param name="notification"></param>
//        public void Push(NotificationModule notification)
//        {
//            foreach (var user in notification.Receiver)
//            {
//                var module = new PcNotificationModule();
//                module.HideInformation = notification.HideInformation;
//                module.Message = notification.Message;
//                module.Receiver = user;
//                module.SendDate = notification.SendDate;
//                module.Title = notification.Title;
//                module.Guid = notification.Guid;
//                module.Sender = notification.Sender;
//                Redis.HashSet("notice-" + user, module.Guid, Json.GetJson(module));
//            }
//        }
//
//        public PcNotificationModule[] GetUserNotification(string user)
//        {
//            var results = new List<PcNotificationModule>();
//            try
//            {
//                var notices = Redis.HashMultGet("notice-" + user);
//                foreach (var notice in notices)
//                {
//                    results.Add(Json.GetObject<PcNotificationModule>(notice.Value));
//                    Redis.HashDel("notice-" + user, notice.Name);
//                }
//            }
//            catch (Exception ex)
//            {
//                this.LogError("读取用户PC端通知错误", ex);
//            }
//
//            return results.ToArray();
//        }
//    }
//
//    /// <summary>
//    ///     pc端通知实体类，不会保存到数据库，具体字段描述参见NotificationModule类
//    /// </summary>
//    public class PcNotificationModule
//    {
//        public string Title { get; set; }
//        public string Message { get; set; }
//        public string Sender { get; set; }
//        public DateTime SendDate { get; set; }
//        public string Receiver { get; set; }
//        public string HideInformation { get; set; }
//        public string Guid { get; set; }
//    }
//}

