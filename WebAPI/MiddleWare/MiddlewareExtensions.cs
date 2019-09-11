using System;
using System.Threading.Tasks;
using Auu.Framework.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Auu.WebAPI.MiddleWare
{
    /// <summary>
    ///     注册中间件的类
    /// </summary>
    public static class MiddlewareExtensions
    {
//        public static IApplicationBuilder UsePermissionCheck(this IApplicationBuilder app)
//        {
//            if (app == null)
//                throw new ArgumentNullException(nameof(app));
//            return app.UseMiddleware<PermissionCheckMiddleware>();
//        }

        /// <summary>
        ///     注册验证session中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestSessionCheck(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            return app.UseMiddleware<SessionCheckMiddleware>();
        }

        public static IApplicationBuilder UseGlobalErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            return app.UseMiddleware<GlobalErrorHandlerMiddleware>();
        }

        public static Task HandleExceptionAsync(HttpContext context, int statusCode, string msg)
        {
            var data = new { code = statusCode.ToString(), is_success = false, msg };
            var result = Json.GetJson(new {data });
            context.Response.ContentType = "application/json;charset=utf-8";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}