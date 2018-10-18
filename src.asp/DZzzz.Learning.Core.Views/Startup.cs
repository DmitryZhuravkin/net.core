using DZzzz.Learning.Core.Views.Infrasctructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Views
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // note: this method add Razor as default view engine

            // MVC has colletion of view engines, they are called by order
            services.Configure<MvcViewOptions>(options =>
            {
                //options.ViewEngines.Clear(); // a way to clear view engines collection
                options.ViewEngines.Insert(0, new DebugDataViewEngine()); // init custom engine
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
