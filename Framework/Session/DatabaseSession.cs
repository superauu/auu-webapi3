//Author: Nathan Li
//Create Time: Wednesday, 26 June 2019

using System;
using System.Collections.Generic;
using Auu.Framework.DbControllers.Base;

namespace Auu.Framework.Session
{
    public class DatabaseSession:ISessionBase
    {
        public IDbHelper DbHelper { get; set; }
        public bool CheckSession(string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
                return false;
            return DbHelper.ExistKey(sessionId);
        }

        public string Register(ISessionUser sessionUser)
        {
            var key = sessionUser.ClientType + "Session-" + sessionUser.UserId;
            if (DbHelper.ExistKey(key))
            {
                var sessionId = DbHelper.GetKey<string>(key);
                if (DbHelper.ExistKey(sessionId))
                    DbHelper.DeleteKey(sessionId);
                if (DbHelper.ExistKey("Data-" + sessionId))
                    DbHelper.DeleteKey("Data-" + sessionId);

                var sessionIdNew = Guid.NewGuid().ToString();
                sessionUser.SessionId = sessionIdNew;
                DbHelper.SetKey(key,sessionIdNew);
                DbHelper.SetKey(sessionIdNew,sessionUser);
                return sessionUser.SessionId;
            }
            else
            {
                var sessionIdNew = Guid.NewGuid().ToString();
                sessionUser.SessionId = sessionIdNew;
                DbHelper.SetKey(key,sessionIdNew);
                DbHelper.SetKey(sessionIdNew,sessionUser);
                return sessionUser.SessionId;
            }
        }

        public ISessionUser GetUserBySessionId(string sessionId)
        {
            if (DbHelper.ExistKey(sessionId))
                return DbHelper.GetKey<SessionUser>(sessionId);
            return null;
        }

        public void Set(string sessionId, string key, string value)
        {
            if (DbHelper.ExistKey($"Data-{sessionId}"))
            {
                var subDict = DbHelper.GetKey<Dictionary<string, string>>($"Data-{sessionId}");
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
                
                DbHelper.SetKey($"Data-{sessionId}",subDict);
            }
            else
            {
                var subDict = new Dictionary<string, string> {{key, value}};
                DbHelper.SetKey($"Data-{sessionId}",subDict);
            }
        }

        public string Get(string sessionId, string key)
        {
            if (!DbHelper.ExistKey($"Data-{sessionId}")) return null;
            var subDict = DbHelper.GetKey<Dictionary<string, string>>($"Data-{sessionId}");
            return subDict?[key];
        }

        public void Del(string sessionId, string key)
        {
            DbHelper.DeleteKey($"Data-{sessionId}");
        }
    }
}