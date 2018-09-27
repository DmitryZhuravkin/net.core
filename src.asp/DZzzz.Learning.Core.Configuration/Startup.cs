using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Configuration
{
    public class Startup
    {
        // this method is called by environment
        // used to configure application services (DI)
        public void ConfigureServices(IServiceCollection services) // #1, called before Configure
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)// #2, called after ConfigureServices
        {
            // this is for Middleware

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
