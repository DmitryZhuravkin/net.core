using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.App.Configuration
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration) // NOTE: we can pass IConfiguration object to startup class
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async context =>
            {
                bool boolValue = configuration.GetSection("CustomTestConfiguration").GetValue<bool>("Option1");
                int intValue = configuration.GetSection("CustomTestConfiguration").GetValue<int>("Option2");
                string stringValue = configuration.GetSection("CustomTestConfiguration").GetValue<string>("Option3");

                await context.Response.WriteAsync($"Hello World! App config: {boolValue}, {intValue}, {stringValue}");
            });
        }
    }
}