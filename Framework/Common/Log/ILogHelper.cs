using System;

namespace Auu.Framework.Common.Log
{
    public interface ILogHelper
    {
        void LogError(object msg, Exception exp = null);
        void LogDebug(object msg, Exception exp = null);
        void LogInfo(object msg, Exception exp = null);
        void LogTrace(object msg, Exception exp = null);
        void LogWarn(object msg, Exception exp = null);
        void LogUser(string userId, string moduleName, string operation, string desc);
    }
}