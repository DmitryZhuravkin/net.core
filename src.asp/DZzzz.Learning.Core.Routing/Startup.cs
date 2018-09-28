using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Routing
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                //routes.MapRoute("default", "{controller}/{action}");
                //routes.MapRoute("default", "{controller}/{action}", new { action = "Index" }); // with defaults (if action isn`t specified)
                //routes.MapRoute("default", "{controller=Home}/{action=Index}"); // inline defaults
                routes.MapRoute("default", "public/X{controller=Home}/{action=Index}"); // with static URL segment
            });
        }
    }
}
