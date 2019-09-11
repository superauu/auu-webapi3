using System;
using Microsoft.AspNetCore.Hosting;

namespace Auu.WebApi
{
    /// <summary>
    ///     程序入口
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     程序入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Initialize.Init();
            WebHostBuilder.BuildWebHost(args).Run();
            Environment.Exit(0);
        }
    }
}