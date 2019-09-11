using Auu.Framework.Common.Log;
using Auu.Framework.DbControllers.Base;
using Auu.Framework.Session;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Auu.WebApi.Controllers.Base
{
    /// <summary>
    ///     有session功能的控制器
    /// </summary>
    [EnableCors("AllowAllOrigins")]
    public abstract class BaseController : Controller
    {
        private string _connString;
        private IDbHelper _userDbHelper;
        public IDbHelper SysDbHelper { get; set; }

        public IDbHelper UserDbHelper
        {
            set => _userDbHelper = value;
            get
            {
                if (_connString == null)
                {
                    if (Session == null || SessionId == null) return null;

                    _connString = Session.GetUserBySessionId(SessionId).ConnString;
                    if (_connString == null)
                        return null;
                }

                _userDbHelper.SetConnString(_connString);
                return _userDbHelper;
            }
        }

        public ISessionBase Session { get; set; }
        public ILogHelper Logger { get; set; }

        /// <summary>
        ///     保存用户实例的sessionId
        /// </summary>
        /// <returns></returns>
        protected string SessionId => HttpContext.Items["SessionId"].ToString();

        /// <summary>
        ///     基于sessionId的全局session存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void SessionSet(string key, string value)
        {
            Session.Set(SessionId, key, value);
        }

        /// <summary>
        ///     基于sessionId的全局session取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string SessionGet(string key)
        {
            return Session.Get(SessionId, key);
        }
    }
}