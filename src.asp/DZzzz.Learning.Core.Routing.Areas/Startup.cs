using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Routing.Areas
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseMvc(router =>
            {
                router.MapRoute("areas", "{area:exists}/{controller=Home}/{action=Index}");
                router.MapRoute("default", "{controller=Home}/{action=Index}"); // we need this because if area segment isn`t presented in URL, we will have 404 error code
            });
        }
    }
}
