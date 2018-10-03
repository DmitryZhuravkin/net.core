using System;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Routing.Controllers
{
    // Route Attribute can be applyed to controller (with constraint)
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    public class AttributeRoutingTestController : Controller
    {
        // never will be reached based on DEFAULT routing
        [Route("attr-test-route")] // fixed route name
        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        [Route("[controller]/attr-test-route")] // [controller] = AttributeRoutingTest, this is like a placeholder
        public IActionResult IndexWithController()
        {
            throw new NotImplementedException();
        }
    }
}