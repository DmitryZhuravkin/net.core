using DZzzz.Learning.Core.Routing.RouteConstraints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Routing
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint))); // define custom inline constraint

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            // convention-based routing
            app.UseMvc(routes =>
            {
                routes.MapRoute("test1", "{controller}/{action}");
                routes.MapRoute("test2", "{controller}/{action}", new { action = "Index" }); // with defaults (if action isn`t specified)
                routes.MapRoute("test3", "{controller=Home}/{action=Index}"); // inline defaults
                routes.MapRoute("test4", "public/X{controller=Home}/{action=Index}"); // with static URL segment
                routes.MapRoute("test5", "{controller=Home}/{action=Index}/{id?}"); // with optional custom segment - ID
                routes.MapRoute("test6", "{controller=Home}/{action=Index}/{id?}/{*catchall}"); // will catch all URLs, where catchall will contain tail of unsupported 

                // constaining routes (constraints are checked AFTER applying defaults)

                routes.MapRoute("test7", "{controller=Home}/{action=Index}/{id:int?}");// with optional custom segment - ID, and ID should be INT. If it is non-int, route will be skipped
                routes.MapRoute("test8", "{controller}/{action}/{id?}",
                    new { controller = "Home", action = "Index" },
                    new { id = new IntRouteConstraint() });// with outside constraints (all constraints in Microsoft.AspNetCore.Routing.Constraints)
                routes.MapRoute("test9", "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id:int?}");// regex constraints
                routes.MapRoute("test10", "{controller=Home}/{action=Index}/{id:range(10, 20)?}");// value range constraint

                // combine constraints (inline)
                routes.MapRoute("test11", "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");
                // combine constraints (outside)
                routes.MapRoute(
                    name: "test12",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: new
                    {
                        id = new CompositeRouteConstraint(
                        new IRouteConstraint[]
                        {
                            new AlphaRouteConstraint(),
                            new MinLengthRouteConstraint(6),
                        })
                    });


                // custom constraint (inline)
                routes.MapRoute("test13", "{controller=Home}/{action=Index}/{id:weekday?}");
                // custom constraint (outside)
                routes.MapRoute(
                    name: "test14",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: new
                    {
                        id = new WeekDayConstraint()
                    });
            });
            // app.UseMvcWithDefaultRoute() is the equivalent 
        }
    }
}
