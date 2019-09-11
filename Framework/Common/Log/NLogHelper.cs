using System;
using NLog;

namespace Auu.Framework.Common.Log
{
    /// <summary>
    ///     Nlog日志类
    /// </summary>
    public class NLogHelper : ILogHelper
    {
        private static Logger _log;

        public NLogHelper()
        {
            if (_log == null)
                _log = LogManager.GetLogger("DefaultLogger");
        }

        public void LogError(object msg, Exception exp = null)
        {
            if (exp == null)
                _log.Error("#" + msg);
            else
                _log.Error(exp,"#" + msg);
        }

        public void LogDebug(object msg, Exception exp = null)
        {
            if (exp == null)
                _log.Debug("#" + msg);
            else
                _log.Debug(exp,"#" + msg);
        }

        public void LogInfo(object msg, Exception exp = null)
        {
            if (exp == null)
                _log.Info("#" + msg);
            else
                _log.Info(exp,"#" + msg);
        }

        public void LogTrace(object msg, Exception exp = null)
        {
            if (exp == null)
                _log.Trace("#" + msg);
            else
                _log.Trace(exp,"#" + msg);
        }

        public void LogWarn(object msg, Exception exp = null)
        {
            if (exp == null)
                _log.Warn("#" + msg);
            else
                _log.Warn(exp,"#" + msg);
        }

        public void LogUser(string userId, string moduleName, string operation, string desc)
        {
            LogTrace($"{userId}::{moduleName}::{operation}::{desc}");
        }
    }
}