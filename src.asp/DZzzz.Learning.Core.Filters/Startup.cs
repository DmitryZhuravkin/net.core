using DZzzz.Learning.Core.Filters.Common;
using DZzzz.Learning.Core.Filters.Filters;
using DZzzz.Learning.Core.Filters.Filters.Injection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Filters
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>(); // this if for DI controller
            services.AddSingleton<IFilterDiagnostics, DefaultFilterDiagnostics>(); // this if for DI2 controller
            services.AddSingleton<TimeFilter>(); // this if for DI2 controller

            services.AddSingleton<ViewResultDetailsFilterAttribute>();// we need this for global filter registration because this will be a part of DI
            //services.AddMvc();

            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.AddService(typeof(ViewResultDetailsFilterAttribute)); // global filter registrations (for all actions and controllers)
                options.Filters.Add(new MessageFilterAttribute("Global message filter"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            //TODO: browser link

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
