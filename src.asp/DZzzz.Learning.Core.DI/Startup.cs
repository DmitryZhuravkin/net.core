using DZzzz.Learning.Core.DI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.DI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // configure dependecy injection
            services.AddTransient<IProductRepository, ProductRespository>(); // new instance for each dependency request
            //services.AddScoped<IProductRepository, ProductRespository>(); // one instance for scope (one HTTP request processing)
            //services.AddSingleton<IProductRepository, ProductRespository>();// single instance

            services.AddTransient<IActionProductRepository, ProductRespository>();

            services.AddMvc();
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
