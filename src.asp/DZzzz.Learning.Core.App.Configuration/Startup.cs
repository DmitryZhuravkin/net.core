﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.App.Configuration
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration) // NOTE: we can pass IConfiguration object to startup class
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // reading configuration
            bool boolValue = configuration.GetSection("CustomTestConfiguration").GetValue<bool>("Option1");
            int intValue = configuration.GetSection("CustomTestConfiguration").GetValue<int>("Option2");
            string stringValue = configuration.GetSection("CustomTestConfiguration").GetValue<string>("Option3");

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