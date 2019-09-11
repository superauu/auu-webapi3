using System;
using System.Threading.Tasks;
using Auu.Framework.Common.Log;
using Microsoft.AspNetCore.Http;

namespace Auu.WebAPI.MiddleWare
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogHelper _logger;

        public GlobalErrorHandlerMiddleware(RequestDelegate next, ILogHelper logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                    await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await MiddlewareExtensions.HandleExceptionAsync(context, 505, "服务端发生错误:" + ex.Message);
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}