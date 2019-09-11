using System.Collections.Generic;

namespace Auu.Framework.Notification
{
    public interface INotification
    {
        void Push(NotificationModule notification);
    }

    public enum SendMethod
    {
        PcSystem,
        PcApp,
        MobileApp,
        Sms,
        PhoneCall
    }

    /// <summary>
    ///     如果增加了新的通知方式，修改这里就可以了,当然还有上面的枚举
    /// </summary>
    public static class NotificationFactory
    {
        public static INotification[] GetNotifications(SendMethod[] sendMethods)
        {
            var sms = new List<SendMethod>();
            //以下两种通知方式是默认值，必须有
            // sms.Add(SendMethod.MobileApp);
            // sms.Add(SendMethod.PcApp);
            //去掉重复的通知方式
            foreach (var sendMethod in sendMethods)
                if (!sms.Contains(sendMethod))
                    sms.Add(sendMethod);
            var notifications = new List<INotification>();
            foreach (var sendMethod in sms)
                switch (sendMethod)
                {
                    case SendMethod.MobileApp: //APP内推送
                        notifications.Add(new MoAppNotification());
                        break;
//                    case SendMethod.PcApp:
//                        notifications.Add(new PcAppNotification());
//                        break;
//                    //PcSystem和PcApp公用一个方法即可
//                    case SendMethod.PcSystem:
//                        notifications.Add(new PcAppNotification());
//                        break;
                    case SendMethod.PhoneCall: //电话
                        notifications.Add(new PhCaNotification());
                        break;
                    case SendMethod.Sms: //短信
                        notifications.Add(new SmsNotification());
                        break;
                }

            return notifications.ToArray();
        }
    }
}