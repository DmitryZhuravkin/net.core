using DZzzz.Learning.Core.Routing.RouteConstraints;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Routing
{
    public class AttributeRoutingStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint))); // define custom inline constraint
            // only inline custom constraint, obviously, can be used with attribute routing
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            // attribute routing is enabled when you call UseMvc
            app.UseMvcWithDefaultRoute(); // the same like {controller}/{action}/{id?}
        }
    }
}