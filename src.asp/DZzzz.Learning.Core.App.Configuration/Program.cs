using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DZzzz.Learning.Core.App.Configuration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) => // method to configure application
                {
                    config.AddJsonFile("appsettings.json", true, true); // load from external file
                    config.AddEnvironmentVariables();

                    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true,
                        true); // load from external file

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureLogging((hostingContext, logging) => // configure logging
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging")); // load logging
                    logging.AddConsole();
                    logging.AddDebug(); // DEBUG output window when the VS is running
                })
                .UseIISIntegration()
                .UseDefaultServiceProvider(
                    (context, options) => // for Dependency Injection configuration, alternative providers can be used
                    {
                        options.ValidateScopes =
                            context.HostingEnvironment.IsDevelopment(); // for Entity Framework Core ??????
                    })
                .UseStartup("DZzzz.Learning.Core.App.Configuration");
            //.UseStartup<CustomEnvWithMethodsStartup>();
            //.UseStartup<Startup>();
        }
    }
}
