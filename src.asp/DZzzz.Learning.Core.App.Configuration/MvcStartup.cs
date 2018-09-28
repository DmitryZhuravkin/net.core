using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.App.Configuration
{
    public class MvcStartup
    {
        private readonly IConfiguration configuration;

        public MvcStartup(IConfiguration configuration) // NOTE: we can pass IConfiguration object to startup class
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()// return IMvcBuilder
                .AddJsonOptions(options => { })
                .AddFormatterMappings(mappings => { })
                .AddViewOptions(options => { }) // configure how MVChandles views, including view engine
                .AddMvcOptions(options =>
                {
                    // convetions
                    // filters
                    // formatterMappings
                    // ...
                });
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
    }
}