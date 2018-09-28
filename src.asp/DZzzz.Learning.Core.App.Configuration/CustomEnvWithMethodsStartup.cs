using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.App.Configuration
{
    // method with appropriate environment name will be used
    public class CustomEnvWithMethodsStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // this method will be used except ConfigureServices method for Development environment
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // navigate to error page
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // this method will be used except Configure method for Development environment
        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        {
            
        }
    }
}