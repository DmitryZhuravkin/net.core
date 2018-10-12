using System;
using DZzzz.Learning.Core.Filters.Filters.Injection;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Filters.Controllers
{
    // NOTE:
    // for each HTTP request a new instances of TimeFilter and DiagnosticsFilter will be created
    // IFilterDiagnostics will be created by Service Provider (using DI)
    [TypeFilter(typeof(DiagnosticsFilter))]
    [TypeFilter(typeof(TimeFilter))]
    public class DIController : Controller
    {
        public IActionResult Index() => View("Message",
            $"This is {ControllerContext.ActionDescriptor.ActionName} from {nameof(DIController)}");

        public ViewResult GenerateException(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return View("Message", $"The value is {id}");
        }
    }
}