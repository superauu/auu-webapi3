////Author: Nathan Li
////Create Time: Tuesday, 26 February 2019
//
//using System;
//using System.Data;
//using AcSeller8.Framework.Common;
//using AcSeller8.Framework.DbControllers.Base;
//using AcSeller8.Framework.DbControllers.SqlServer;
//using Microsoft.Extensions.Configuration;
//using Xunit;
//
//namespace AcSeller8.UnitTest.Log
//{
//    public class DbHandlerTest
//    {
//        private IDbHelper getConn()
//        {
//            var builder = new ConfigurationBuilder()
//                .AddJsonFile("config.json", false, true);
//            Config.Configuration = builder.Build();
//            var DbName = Config.Configuration["DbConnectionString:DbName"];
//            var connString =
//                $"server={Config.Configuration["DbConnectionString:DbServer"]};User Id={Config.Configuration["DbConnectionString:DbUser"]};password={Config.Configuration["DbConnectionString:DbPassword"]};Database={DbName}";
//            SqlServerDbHelper db = new SqlServerDbHelper(connString);
//            return db;
//        }
//
//        [Fact]
//        public void TestCreateTable()
//        {
//            DbHandler db = new DbHandler(getConn());
//            db.CreateDb("test1");
//            db.CreateTable("test", "test4", typeof(LogTest));
//        }
//
//        [Fact]
//        public void TestLogHandler()
//        {
//            DbLogHandler log=DbLogHandler.New(getConn(),typeof(LogTest));
//            for(int i=0;i<1000001;i++)
//                log.SaveLog(new LogTest{Level = LogLevel.Fatal,LogDateTime = DateTime.Now,Message = "ok",User = "haha"+i});
//        }
//
//        [Fact]
//        public void TestInitSettings()
//        {
//            DbHandler db = new DbHandler(getConn());
//            db.InitSettings(typeof(LogTest));
//        }
//    }
//
//    public class TestSqlDbHelper : SqlServerDbHelperBase
//    {
//        public TestSqlDbHelper(string connString) : base(connString)
//        {
//        }
//
//        public IDbConnection GetConn()
//        {
//            return GetConnection();
//        }
//    }
//
//    public class LogTest : ILog
//    {
//        public string Id { get; set; }
//        public DateTime LogDateTime { get; set; }
//        public string Message { get; set; }
//        public LogLevel Level { get; set; }
//        public string User { get; set; }
//        public float test1 { get; set; }
//        public double test2 { get; set; }
//        public bool test3 { get; set; }
//        public int test4 { get; set; }
//        public long test5 { get; set; }
//    }
//}