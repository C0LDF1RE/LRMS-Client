using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LRMS.UWP.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IWebHost CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                    .AddCommandLine(args)       // 接受应用程序参数
                    .Build();                   // 创建实例？
            string ip = config["ip"];
            string port = config["port"];
            Console.WriteLine($"ip={ip}, port={port}");
            Console.WriteLine(DateTime.Now);

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls($"http://{ip}:{port}")
                .Build();
        }

    }
}
