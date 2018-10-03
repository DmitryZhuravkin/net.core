using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DZzzz.Learning.Core.Routing.RouteConstraints
{
    public class WeekDayConstraint : IRouteConstraint
    {
        private static readonly string[] days = { "mon", "tue", "web", "thu", "fri", "sat", "sun" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}