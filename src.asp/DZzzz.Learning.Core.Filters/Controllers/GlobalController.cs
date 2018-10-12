using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Filters.Controllers
{
    public class GlobalController : Controller
    {
        public IActionResult Index() => View("Message",
            $"This is {ControllerContext.ActionDescriptor.ActionName} from {nameof(GlobalController)}");
    }
}