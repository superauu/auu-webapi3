//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Auu.Framework.Common;
//using Auu.Framework.Common.Session;
//
//namespace Auu.WebAPI.MiddleWare
//{
//    /// <summary>
//    ///     验证当前的请求是否有权限，通过sessionid和请求的地址来判断
//    /// </summary>
//    public class PermissionCheckMiddleware
//    {
//        private readonly RequestDelegate _next;
//
//        /// <summary>
//        ///     构造函数
//        /// </summary>
//        /// <param name="next"></param>
//        public PermissionCheckMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }
//
//        /// <summary>
//        ///     判断权限
//        /// </summary>
//        /// <param name="context"></param>
//        /// <returns></returns>
//        public async Task Invoke(HttpContext context)
//        {
//            if (context.Request.Method == "OPTIONS")
//                await _next.Invoke(context);
//            var url = context.Request.Path.ToString().ToLower();
//            //用户名密码登录的请求，忽略session验证
//
//            if (PermissionWhiteList(url))
//                await _next.Invoke(context);
//            else
//                try
//                {
//                    var sessionId = context.Items["SessionId"].ToString();
//                    var dbName = RedisSession.Get(sessionId, "__dbname__");
//                    var permission = new Permission(sessionId);
//                    if (permission.CheckUserPermission(url))
//                        await _next.Invoke(context);
//                    else
//                        await context.Response.WriteAsync("{\"scode\":\"403\",\"remark\":\"没有访问权限\"}");
//                }
//                catch (Exception ex)
//                {
//                    await context.Response.WriteAsync("{\"scode\":\"505\",\"remark\":\"服务端发生错误:" + ex.Message + "\"}");
//                }
//        }
//
//        //如果某些模块不需要权限控制，需要加入白名单
//        private bool PermissionWhiteList(string url)
//        {
//            return false;
//        }
//    }
//}