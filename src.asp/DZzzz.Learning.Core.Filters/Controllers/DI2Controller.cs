using DZzzz.Learning.Core.Filters.Filters.Injection;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Filters.Controllers
{
    // NOTE:
    // for each HTTP request a new instance DiagnosticsFilter will be created
    // IFilterDiagnostics and TimeFilter will be created by Service Provider (using DI)
    [TypeFilter(typeof(DiagnosticsFilter))]
    [ServiceFilter(typeof(TimeFilter))]
    public class DI2Controller : Controller
    {
        public IActionResult Index() => View("Message",
            $"This is {ControllerContext.ActionDescriptor.ActionName} from {nameof(DI2Controller)}");
    }
}