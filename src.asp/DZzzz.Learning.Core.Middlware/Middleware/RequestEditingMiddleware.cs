using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DZzzz.Learning.Core.Middlware.Middleware
{
    public class RequestEditingMiddleware
    {
        private readonly RequestDelegate next;

        public RequestEditingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["Edge"] = httpContext.Request.Headers["User-Agent"]
                .Any(c => c.ToLower().Contains("edge"));

            await next.Invoke(httpContext);
        }
    }
}