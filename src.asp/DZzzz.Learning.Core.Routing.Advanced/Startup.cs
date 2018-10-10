using DZzzz.Learning.Core.Routing.Advanced.Custom;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Routing.Advanced
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // for custom routing configuration

            services.Configure<RouteOptions>(options =>
            {
                //options.ConstraintMap
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                // custom route
                //routes.Routes.Add(new LegacyRouter(
                //    "/articles/Windows_3.1_Overview.html",
                //    "/old/.NET_1.0_Class_Library"));


                routes.Routes.Add(new LegacyToMvcRouter(app.ApplicationServices,
                        "/articles/Windows_3.1_Overview.html",
                        "/old/.NET_1.0_Class_Library"));

                // configure route table
                // each MapRoute call add Router class to routes table
                routes.MapRoute("NewRoute", "App/Do{action}", new { controller = "Home" });
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("out", "outbound/{controller=Home}/{action=Index}");
            });
        }
    }
}
