using System;
using System.Threading.Tasks;
using System.Linq;

using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.Routing.Advanced.Custom
{
    public class LegacyToMvcRouter : IRouter
    {
        private readonly string[] urls;
        private readonly IRouter mvcRoute;

        public LegacyToMvcRouter(IServiceProvider services, params string[] targetUrls)
        {
            this.urls = targetUrls;
            mvcRoute = services.GetRequiredService<MvcRouteHandler>();
        }

        public async Task RouteAsync(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path
                .Value.TrimEnd('/');

            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                // fill in route table
                context.RouteData.Values["controller"] = "Legacy";
                context.RouteData.Values["action"] = "GetLegacyUrl";
                context.RouteData.Values["legacyUrl"] = requestedUrl;
                await mvcRoute.RouteAsync(context);
            }
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            // this is for outgoing URLS
            // will be called for by TagHelper, for example, for each link in view
            if (context.Values.ContainsKey("legacyUrl")) // only legacyurl is used, we don`t need controller and action to generate
            {
                string url = context.Values["legacyUrl"] as string;
                if (urls.Contains(url))
                {
                    return new VirtualPathData(this, url);
                }
            }
            return null;
        }
    }
}