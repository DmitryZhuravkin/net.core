using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DZzzz.Learning.Core.Filters.Filters
{
    /// <summary>
    /// NOTE: 
    /// the Authorize attribute, which can be used to restrict access to specific users and groups, was
    /// implemented as a filter, but this is no longer the case in asp.Net Core MVC.the Authorize attribute is still
    /// used, but it works in a different way.Behind the scenes, a global filter (i describe global filters later in this
    /// chapter) is used to detect the Authorize attribute and enforce policies defined by asp.Net Core identity
    /// system, but the Authorize attribute isn’t a filter and doesn’t implement the IAuthorizationFilter interface. 
    /// </summary>
    public class HttpsFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.IsHttps)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}