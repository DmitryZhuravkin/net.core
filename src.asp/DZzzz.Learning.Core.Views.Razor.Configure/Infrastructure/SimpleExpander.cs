using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DZzzz.Learning.Core.Views.Razor.Configure.Infrastructure
{
    // IViewLocationExpander - way to extend Rasor locations
    public class SimpleExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // do nothing - not required
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="viewLocations">Default list of locations by Razor Engine</param>
        /// <returns></returns>
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (string location in viewLocations)
            {
                yield return location.Replace("Shared", "Common");
            }
            // {0} - placeholder for action
            // {1} - placeholder for controller
            yield return "/Views/Legacy/{1}/{0}/View.cshtml";
        }
    }
}