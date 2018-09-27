using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

// mininum for processing HTTP requests and generate responses ussing controllers and actions
namespace DZzzz.Learning.Core.Configuration
{
    public class MvcStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // built-in MVC services
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvcWithDefaultRoute();
        }
    }
}