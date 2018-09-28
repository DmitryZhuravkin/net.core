using System.Text;
using System.Threading.Tasks;

using DZzzz.Learning.Core.Middlware.Services;

using Microsoft.AspNetCore.Http;

namespace DZzzz.Learning.Core.Middlware.Middleware
{
    public class ServiceMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ApplicationService service;

        public ServiceMiddleware(RequestDelegate next, ApplicationService service) // next pipeline component with DI component
        {
            this.next = next;
            this.service = service;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLowerInvariant() == "/servicemiddleware")
            {
                await httpContext.Response.WriteAsync(service.GetAppServiceName(), Encoding.UTF8);
            }
            else
            {
                await next.Invoke(httpContext);
            }
        }
    }
}