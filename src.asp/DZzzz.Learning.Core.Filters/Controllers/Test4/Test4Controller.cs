using System;
using DZzzz.Learning.Core.Filters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Filters.Controllers.Test4
{
    [ViewResultDetailsFilter]
    [RangeExceptionFilter]
    public class Test4Controller : Controller
    {
        public IActionResult Index() => View("Message",
            $"This is {ControllerContext.ActionDescriptor.DisplayName} from {nameof(Test4Controller)}");


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