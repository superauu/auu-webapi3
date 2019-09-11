using System.Threading.Tasks;
using Autofac;
using Auu.Framework.Common;
using Auu.Framework.Session;
using Microsoft.AspNetCore.Http;

namespace Auu.WebAPI.MiddleWare
{
    /// <summary>
    ///     验证session的中间件，所有请求进入controller之前都会进到这里验证session
    /// </summary>
    public class SessionCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private ISessionBase _session;

        public SessionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private bool CheckSessionId(string sessionId)
        {
            using (var scope = LocContainer.Main.BeginLifetimeScope())
            {
                if(_session==null)
                    _session = scope.Resolve<ISessionBase>();
                return _session.CheckSession(sessionId);
            }
        }

        private bool CheckSessionWhiteList(string url)
        {
            foreach (var section in GlobalVar.SessionCheckWhiteList)
                if (CheckSessionWhiteList(section.Compare, section.Url, url))
                    return true;
            return false;
        }

        private bool CheckSessionWhiteList(string compare, string url, string currentUrl)
        {
            url = url.ToLower();
            currentUrl = currentUrl.ToLower();
            switch (compare.ToLower())
            {
                case "equals":
                    if (currentUrl.Equals(url))
                        return true;
                    break;
                case "startswith":
                    if (currentUrl.StartsWith(url))
                        return true;
                    break;
                case "endswith":
                    if (currentUrl.EndsWith(url))
                        return true;
                    break;
                case "contains":
                    if (currentUrl.Contains(url))
                        return true;
                    break;
                default:
                    return false;
            }

            return false;
        }

        /// <summary>
        ///     判断Session的地方
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS")
                await _next.Invoke(context);
            var url = context.Request.Path.ToString().ToLower();
            if (CheckSessionWhiteList(url))
            {
                await _next.Invoke(context);
            }
            else
            {
                string sessionId = context.Request.Headers["SessionId"];
                context.Items.Add("SessionId", sessionId);

                var check = CheckSessionId(sessionId);

                if (check)
                    await _next.Invoke(context);
                else
                    await MiddlewareExtensions.HandleExceptionAsync(context, 802, "SessionId 验证失败");
            }
        }
    }
}