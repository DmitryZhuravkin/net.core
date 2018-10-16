using DZzzz.Learning.Core.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace DZzzz.Learning.Core.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository, MemoryRepository>();

            services.AddMvc()
                .AddXmlDataContractSerializerFormatters() // add XML serialization
                .AddMvcOptions(opts =>
                {
                    opts.FormatterMappings.SetMediaTypeMappingForFormat("xml", new MediaTypeHeaderValue("application/xml")); // apply "Data Format from the Route or Query String"

                    // this is for FULL content negotiation (using Accept header)
                    // opts.RespectBrowserAcceptHeader = true;
                    // opts.ReturnHttpNotAcceptable = true;
                });

            //.AddJsonOptions(); additional to configure custom JSON options
            // Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter - for custom formatters
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
