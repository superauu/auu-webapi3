using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace Auu.Framework.Common
{
    /// <summary>
    ///     全局变量类
    /// </summary>
    public static class GlobalVar
    {
        /// <summary>
        ///     数据库连接字符串
        /// </summary>
        public static string ConnString;

        public static string DbName;
        public static bool UseRedis;
        public static string RedisIp;
        public static string RedisPassword;

        public static string HttpPort;
        public static string HttpsPort;
        public static bool EnableHttps;
        public static string SslPfxFile;
        public static string SslPfxPassword;
        public static string StaticFilesDirectory;
        public static string StaticFilesRequestPath;
        public static string Version;
        public static string RegionID;
        public const int MaxRdsDbNumbers=500;
        public static string RdsAdminAccount = "ttt";//TODO 

        //AcSeller8
        public const string EbayAppId = "ACSELLER-ACSeller-PRD-3ea94fa4c-390825cd";//TODO 回头放配置文件里 都放数据库里
        public const string EbayDevId = "bf3b6f4c-c761-402e-b848-8a56b3d22976";//TODO 回头放配置文件里
        public const string EbayCertId = "PRD-ea94fa4ca6f1-1ee6-4071-a534-a165";//TODO 回头放配置文件里
        public const string EbayRuName = "AC_SELLER_TECHN-ACSELLER-ACSell-jyjfrmwim";//TODO 回头放配置文件里

        //Yibo Li
        //public const string EbayAppId = "YiboLi-AuuERP-PRD-d91c6ad5c-a0883e49";//TODO 回头放配置文件里 都放数据库里
        //public const string EbayDevId = "3bee2bf1-5280-4c42-b011-58154ec94ebf";//TODO 回头放配置文件里
        //public const string EbayCertId = "PRD-91c6ad5c476e-8559-4710-84a9-fa97";//TODO 回头放配置文件里
        //public const string EbayRuName = "Yibo_Li-YiboLi-AuuERP-P-pdxyrpj";//TODO 回头放配置文件里

        public const string EbaySiteId = "15";//Australia
        public const string EbayTradingApiUrl = "https://api.ebay.com/ws/api.dll";
        
        public static List<SessionCheckWhiteList> SessionCheckWhiteList;

        public static string CurrentPath => Thread.GetDomain().BaseDirectory;

        /// <summary>
        ///     初始化全局变量
        /// </summary>
        public static void InitVar()
        {
            RegionID = "123345";//TODO 确定一个区域ID
            DbName = Config.Configuration["DbConnectionString:DbName"];
            ConnString =
                $"server={Config.Configuration["DbConnectionString:DbServer"]};User Id={Config.Configuration["DbConnectionString:DbUser"]};password={Config.Configuration["DbConnectionString:DbPassword"]};Database={DbName};{Config.Configuration["DbConnectionString:DbSetup"]}";
            HttpPort = Config.Configuration["WebServer:HttpPort"];
            HttpsPort = Config.Configuration["WebServer:HttpsPort"];
            RedisIp = Config.Configuration["Redis:RedisServerIp"];
            RedisPassword = Config.Configuration["Redis:RedisPassword"];
            bool.TryParse(Config.Configuration["Redis:UseRedis"], out UseRedis);
            SslPfxFile = Config.Configuration["WebServer:SslPfxFile"];
            SslPfxPassword = Config.Configuration["WebServer:SslPfxPassword"];
            bool.TryParse(Config.Configuration["WebServer:EnableHttps"], out EnableHttps);
            StaticFilesDirectory = Config.Configuration["StaticFiles:Directory"];
            StaticFilesRequestPath = Config.Configuration["StaticFiles:RequestPath"];
            Version = Config.Configuration["Version"];
            if (string.IsNullOrEmpty(Version))
                Version = "v1";

            var sessionWhiteList = Config.Configuration.GetSection("SessionWhiteList").GetChildren();
            SessionCheckWhiteList = new List<SessionCheckWhiteList>();
            foreach (var section in sessionWhiteList)
            {
                var compare = section.GetValue<string>("Compare");
                var uri = section.GetValue<string>("Url");
                SessionCheckWhiteList.Add(new SessionCheckWhiteList {Compare = compare, Url = uri});
            }
        }
    }

    public class SessionCheckWhiteList
    {
        public string Compare { get; set; }
        public string Url { get; set; }
    }
}