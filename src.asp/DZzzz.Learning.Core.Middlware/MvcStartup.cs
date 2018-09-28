using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DZzzz.Learning.Core.Middlware
{
    public class MvcStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // to display stacktrace
                app.UseStatusCodePages(); // not all browsers show page for error status code. this is default pages for error status codes
                app.UseBrowserLink(); // enable cross-browser editing and verifications, VS plugin
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
    }
}