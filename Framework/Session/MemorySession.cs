using System;
using System.Collections.Generic;
using Auu.Framework.Common;

namespace Auu.Framework.Session
{
    //内存session,如果服务器重启,则所有session信息将丢失
    public class MemorySession:ISessionBase
    {
        private static Dictionary<string, string> _session;

        public MemorySession()
        {
            if(_session==null)
                _session=new Dictionary<string, string>();
        }

        public bool CheckSession(string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
                return false;
            return _session.ContainsKey(sessionId);
        }

        public string Register(ISessionUser sessionUser)
        {
            var key = sessionUser.ClientType + "Session-" + sessionUser.UserId;
            if (_session.ContainsKey(key))
            {
                var sessionId = _session[key];
                if (_session.ContainsKey(sessionId))
                    _session.Remove(sessionId);
                if (_session.ContainsKey("Data-" + sessionId))
                    _session.Remove("Data-" + sessionId);

                var sessionIdNew = Guid.NewGuid().ToString();
                sessionUser.SessionId = sessionIdNew;
                _session[key]= sessionIdNew;
                _session[sessionIdNew] = Json.GetJson(sessionUser);
                return sessionUser.SessionId;
            }
            else
            {
                var sessionIdNew = Guid.NewGuid().ToString();
                sessionUser.SessionId = sessionIdNew;
                _session.Add(key, sessionIdNew);
                _session.Add(sessionIdNew, Json.GetJson(sessionUser));
                return sessionUser.SessionId;
            }
        }

        public ISessionUser GetUserBySessionId(string sessionId)
        {
            if (_session.ContainsKey(sessionId))
                return Json.GetObject<SessionUser>(_session[sessionId]);
            return null;
        }

        public void Set(string sessionId, string key, string value)
        {
            if (_session.ContainsKey($"Data-{sessionId}"))
            {
                var subDict = Json.GetObject<Dictionary<string, string>>(_session[$"Data-{sessionId}"]);
                if (subDict == null)
                {
                    subDict = new Dictionary<string, string> {{key, value}};
                    subDict.Add(key,value);
                }
                else
                {
                    if (subDict.ContainsKey(key))
                    {
                        subDict[key] = value;
                    }
                    else
                    {
                        subDict.Add(key,value);
                    }
                }
                _session[$"Data-{sessionId}"] = Json.GetJson(subDict);
            }
            else
            {
                var subDict = new Dictionary<string, string> {{key, value}};
                _session[$"Data-{sessionId}"] = Json.GetJson(subDict);
            }
        }

        public string Get(string sessionId, string key)
        {
            if (!_session.ContainsKey($"Data-{sessionId}")) return null;
            var subDict = Json.GetObject<Dictionary<string, string>>(_session[$"Data-{sessionId}"]);
            return subDict?[key];

        }

        public void Del(string sessionId, string key)
        {
            if (_session.ContainsKey($"Data-{sessionId}"))
                _session.Remove($"Data-{sessionId}");
        }
    }
}
