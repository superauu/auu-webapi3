using System;

namespace Auu.Framework.Common.CustomAttributes
{

    [AttributeUsage(AttributeTargets.Method)]
    public class LogHandlerAttribute:Attribute
    {
        public string LogMessage { get; set; }
        public string UserId { get; set; }

        public LogHandlerAttribute(string logMessage, string userId)
        {
            LogMessage = logMessage;
            UserId = userId;
        }
    }
}
