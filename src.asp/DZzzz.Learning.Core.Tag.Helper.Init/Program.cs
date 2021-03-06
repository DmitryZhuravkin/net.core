﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DZzzz.Learning.Core.Tag.Helper.Init
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
