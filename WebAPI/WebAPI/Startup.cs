using Autofac.Extensions.DependencyInjection;
using Auu.Framework.Common;
using Auu.WebAPI.MiddleWare;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Globalization;
using System.IO;

namespace Auu.WebApi
{
    /// <summary>
    ///     Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //使用autofac替换原有的controller生成机制
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            services.AddResponseCompression();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            //处理跨域访问的问题
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(GlobalVar.Version, new OpenApiInfo
                {
                    Version = GlobalVar.Version,
                    Title = "Auu WebApi [" + DateTime.Now.ToString(CultureInfo.CurrentCulture) + "]"
                });

                var basePath = GlobalVar.CurrentPath;
                var xmlPath = Path.Combine(basePath, "Auu.WebApi.xml");
                options.IncludeXmlComments(xmlPath);
            });
            
            //将services中的服务填充到Autofac中.
            LocContainer.ContainerBuilder.Populate(services);
            LocContainer.Main = LocContainer.ContainerBuilder.Build();
            //释放没用的builder
            LocContainer.ContainerBuilder = null;
            //使用容器创建 AutofacServiceProvider 
            return new AutofacServiceProvider(LocContainer.Main);
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="appLifetime"></param>
        // ReSharper disable once UnusedMember.Global
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory,
            IHostApplicationLifetime appLifetime)
        {
            app.UseCors("AllowAllOrigins");
            bool.TryParse(Config.Configuration["WebServer:Compress"], out var ifCompress);
            if(ifCompress)
                app.UseResponseCompression();
            app.UseMvc();

            if (!env.IsDevelopment())
            {
                app.UseGlobalErrorHandlerMiddleware();
                app.UseRequestSessionCheck();
//                app.UsePermissionCheck();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Auu WebApi API {GlobalVar.Version}");
                });
            }
            
            loggerFactory.AddNLog();
            LogManager.LoadConfiguration("nlog.config");
            if (!string.IsNullOrEmpty(GlobalVar.StaticFilesDirectory) &&
                !string.IsNullOrEmpty(GlobalVar.StaticFilesRequestPath))
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), GlobalVar.StaticFilesDirectory)),
                    RequestPath = new PathString(GlobalVar.StaticFilesRequestPath)
                });

            appLifetime.ApplicationStopped.Register(() => { LocContainer.Main.Dispose(); });
        }
    }
}