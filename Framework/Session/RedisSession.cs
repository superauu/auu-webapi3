using System;
using Auu.Framework.Common;

namespace Auu.Framework.Session
{
    public class RedisSession : ISessionBase
    {
        public bool CheckSession(string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
                return false;
            return Redis.Exist(sessionId);
        }

        public string Register(ISessionUser sessionUser)
        {
            var key = sessionUser.ClientType + "Session-" + sessionUser.UserId;
            if (Redis.Exist(key))
            {
                var sessionId = Redis.Get(key);
                if (Redis.Exist(sessionId))
                    Redis.Del(sessionId);
                if (Redis.Exist("Data-" + sessionId))
                    Redis.Del("Data-" + sessionId);
            }

            var sessionIdNew = Guid.NewGuid().ToString();

            sessionUser.SessionId = sessionIdNew;
            Redis.Set(key, sessionIdNew);
            Redis.Set(sessionIdNew, Json.GetJson(sessionUser));
            return sessionUser.SessionId;
        }

        public ISessionUser GetUserBySessionId(string sessionId)
        {
            if (Redis.Exist(sessionId))
                return Json.GetObject<SessionUser>(Redis.Get(sessionId));
            return null;
        }

        /// <summary>
        ///     写自有数据
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string sessionId, string key, string value)
        {
            Redis.HashSet("Data-" + sessionId, key, value);
        }

        /// <summary>
        ///     读自有数据
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string sessionId, string key)
        {
            return Redis.HashGet("Data-" + sessionId, key);
        }

        /// <summary>
        ///     删除自有数据
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="key"></param>
        public void Del(string sessionId, string key)
        {
            Redis.HashDel("Data-" + sessionId, key);
        }
    }
}