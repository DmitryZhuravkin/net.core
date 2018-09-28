using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace DZzzz.Learning.Core.Middlware.Middleware
{
    public class ContentMiddleware
    {
        private readonly RequestDelegate next;

        public ContentMiddleware(RequestDelegate next) // next pipeline component
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLowerInvariant() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware", Encoding.UTF8);
            }
            else
            {
                await next.Invoke(httpContext);
            }
        }
    }
}