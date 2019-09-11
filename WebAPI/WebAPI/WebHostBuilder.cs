using System;
using System.Net;
using Auu.Framework.Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Auu.WebApi
{
    /// <summary>
    ///     创建web服务器
    /// </summary>
    public static class WebHostBuilder
    {
        //dotnet publish --configuration Release -o publish
        //dotnet build --configuration Release --no-dependencies --no-incremental
        //dotnet publish -c Release -r win10-x64 -o "c:\publish"
        /// <summary>
        ///     创建服务
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(option =>
                {
                    option.Listen(IPAddress.Any, Convert.ToInt32(GlobalVar.HttpPort));
                    if (GlobalVar.EnableHttps)
                        option.Listen(IPAddress.Any, Convert.ToInt32(GlobalVar.HttpsPort),
                            lop => { lop.UseHttps(GlobalVar.SslPfxFile, GlobalVar.SslPfxPassword); });
                })
                .UseStartup<Startup>()
                .Build();
        }
    }
}