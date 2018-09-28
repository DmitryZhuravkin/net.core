using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.App.Configuration
{
    // this class will be used in case of loading using .UseStatup(asseblyName) for Development mode
    public class StartupDevelopment
    {
        private readonly IConfiguration configuration;

        public StartupDevelopment(IConfiguration configuration) // NOTE: we can pass IConfiguration object to startup class
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}