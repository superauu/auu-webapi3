using System.IO;
using Autofac;
using Auu.Framework.Common;
using Auu.Framework.Common.Log;
using Auu.Framework.DbControllers.Base;
using Auu.Framework.DbControllers.Mysql;
using Auu.Framework.Session;
using Microsoft.Extensions.Configuration;

namespace Auu.WebApi
{
    /// <summary>
    /// 初始化服务器
    /// </summary>
    public static class Initialize
    {
        /// <summary>
        /// 所有的初始化内容都放到这里
        /// </summary>
        public static void Init()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(GlobalVar.CurrentPath)
                .AddJsonFile("config.json", false, true)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("whitelist.json", true, true)
                .AddEnvironmentVariables();
            Config.Configuration = builder.Build();

            //初始化全局变量
            GlobalVar.InitVar();
            //初始化静态文件夹
            if (!Directory.Exists(GlobalVar.StaticFilesDirectory))
                Directory.CreateDirectory(GlobalVar.StaticFilesDirectory);
            //初始化Redis
            if (GlobalVar.UseRedis)
                Redis.InitRedis(GlobalVar.RedisIp, GlobalVar.RedisPassword);

            LocContainer.ContainerBuilder = new ContainerBuilder();
            //Controller组件注册
            LocContainer.ContainerBuilder.RegisterModule<PluginRegister>();

            //注册数据库处理类
            LocContainer.ContainerBuilder.Register(c => new MysqlDbHelper(GlobalVar.ConnString)).As<IDbHelper>();

            //注册Session处理类，默认使用内存来存储session信息
            LocContainer.ContainerBuilder.Register(c => new SessionUser()).As<ISessionUser>();
            LocContainer.ContainerBuilder.RegisterType<DatabaseSession>().As<ISessionBase>().PropertiesAutowired();

            //注册日志类
            LocContainer.ContainerBuilder.Register(c => new NLogHelper()).As<ILogHelper>();
            //TODO 其它需要注册的组件在这里写就可以了

        }
    }
}