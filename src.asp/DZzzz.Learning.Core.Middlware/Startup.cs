using DZzzz.Learning.Core.Middlware.Middleware;
using DZzzz.Learning.Core.Middlware.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Middlware
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ApplicationService>();
            //services.AddMvc();// MVC services
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // IApplicationBuilder - configure pipeline
            // IHostingEnvironment - for defining environment specific 

            // EnvironmentName is set up based on environment variable ASPNETCORE_ENVIRONMENT

            if (env.IsDevelopment()) // ASPNETCORE_ENVIRONMENT = Development
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsEnvironment("Custom")) // ASPNETCORE_ENVIRONMENT = Custom
            {
                app.UseDeveloperExceptionPage();
            }

            //NOTE: order definition is important!
            // Middleware definition
            app.UseMiddleware<ErrorMiddleware>();
            app.UseMiddleware<RequestEditingMiddleware>();
            app.UseMiddleware<ContentMiddleware>();
            app.UseMiddleware<ServiceMiddleware>();


            // app.UseMvcWithDefaultRoute(); // MVC middleware with default routing
            // app.UseMvc(); // MVC middleware with custom routing
        }
    }
}
