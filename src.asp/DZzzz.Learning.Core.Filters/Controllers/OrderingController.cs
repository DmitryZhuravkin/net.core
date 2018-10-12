using DZzzz.Learning.Core.Filters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Filters.Controllers
{
    //Before Result:Global message filter
    //Before Result:Controller message filter
    //Before Result:First action message filter
    //Before Result:Second action message filter

    //After Result:Second action message filter
    //After Result:First action message filter
    //After Result:Controller message filter
    //After Result:Global message filter

    // NOTE: ordering can be changed using Order value

    [MessageFilter("Controller message filter")]
    public class OrderingController : Controller
    {
        [MessageFilter("First action message filter")]
        [MessageFilter("Second action message filter")]
        public IActionResult Index() => View("Message",
            $"This is {ControllerContext.ActionDescriptor.ActionName} from {nameof(OrderingController)}");
    }
}