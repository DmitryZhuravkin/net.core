using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DZzzz.Learning.Core.Routing.Advanced.Custom
{
    /// <summary>
    /// Customize routing system
    /// </summary>
    public class LegacyRouter : IRouter
    {
        private readonly string[] urls;

        public LegacyRouter(params string[] targetUrls)
        {
            this.urls = targetUrls;
        }

        /// <summary>
        /// RouteAsync is called by routing system.
        /// We need to set Handler property to mark a handler for this route
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>

        public Task RouteAsync(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path
                .Value.TrimEnd('/');

            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.Handler = async ctx => {
                    HttpResponse response = ctx.Response;
                    byte[] bytes = Encoding.ASCII.GetBytes($"URL: {requestedUrl}");
                    await response.Body.WriteAsync(bytes, 0, bytes.Length);
                };
            }

            return Task.CompletedTask; // !!!! Good way to return empty task
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            // this is for outgoing URLS
            return null;
        }
    }
}