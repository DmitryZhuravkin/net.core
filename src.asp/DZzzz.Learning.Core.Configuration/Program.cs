using System.IO;
using System.Reflection;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DZzzz.Learning.Core.Configuration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build() // process all configuration and create an instance of IWebHost
                .Run(); // Run is used to start handling HTTP requests
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            // WebHost class is used to configure ASP.NET core app
            WebHost.CreateDefaultBuilder(args) // init most-common settings for ASP application
                //.UseKestrel()
                //.UseContentRoot(Directory.GetCurrentDirectory())
                //.UseIISIntegration()
                .UseStartup<Startup>(); // init application-specific logic

        // method show how we can customize WebHostBuilder
        public static IWebHostBuilder CustomWebHostBuilder(string[] args)
        {
            // A builder for IWebHost
            // where IWebHost - Represents a configured web host.
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true,
                            reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                            optional: true, reloadOnChange: true);
                    if (env.IsDevelopment())
                    {
                        var appAssembly =
                            Assembly.Load(new AssemblyName(env.ApplicationName));
                        if (appAssembly != null)
                        {
                            config.AddUserSecrets(appAssembly, optional: true);
                        }
                    }
                    config.AddEnvironmentVariables();
                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(
                        hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .UseIISIntegration()
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes =
                        context.HostingEnvironment.IsDevelopment();
                }) // this method is used to configure Dependency Injection
                .UseStartup<Startup>();
        }
    }
}
