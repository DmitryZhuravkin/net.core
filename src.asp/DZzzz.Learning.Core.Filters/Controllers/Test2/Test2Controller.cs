using DZzzz.Learning.Core.Filters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Filters.Controllers.Test2
{
    /// <summary>
    /// Apply authorization filter to action
    /// </summary>
    public class Test2Controller : Controller
    {
        [HttpsFilter]
        public IActionResult Index() => View("Message",
            $"This is {ControllerContext.ActionDescriptor.DisplayName} from {nameof(Test2Controller)}. Available only using via HTTPS.");
    }
}