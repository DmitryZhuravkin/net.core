using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DZzzz.Learning.Core.Views.Razor.Configure.Infrastructure
{
    public class ColorExpander : IViewLocationExpander
    {
        private static Dictionary<string, string> Colors
            = new Dictionary<string, string>
            {
                ["red"] = "Red",
                ["green"] = "Green",
                ["blue"] = "Blue"
            };




        /// <summary>
        /// Method is used to populate dynamic ValuesCollection from Context data
        /// NOTE: razor calls the PopulateValues method for every view request but caches the set of search
        ///       locations returned by the ExpandViewLocations method.this means that subsequent requests for which
        ///       the PopulateValues method generates the same set of categorization keys, and values won’t require the
        ///       ExpandViewLocations method to be called.
        /// </summary>
        /// <param name="context"></param>
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //context.Values - property returns an IDictionary<string, string> to which the view location
            //expander adds key / value pairs that uniquely identify the category of request, as
            //explained in the following text.

            var routeValues = context.ActionContext.RouteData.Values;

            string color;

            if (routeValues.ContainsKey("id")
                && Colors.TryGetValue(routeValues["id"] as string, out color)
                && !string.IsNullOrEmpty(color))
            {
                context.Values["color"] = color;
            }

            // id = red
            // Views / Home / Red.cshtml
            // Views / Common / Red.cshtml
            // Pages / Common / Red.cshtml
            // Views / Legacy / Home / Red / View.cshtml
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            string color;

            context.Values.TryGetValue("color", out color);

            foreach (string location in viewLocations)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    yield return location.Replace("{0}", color);
                }
                else
                {
                    yield return location;
                }
            }
        }
    }
}