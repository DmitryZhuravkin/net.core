using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DZzzz.Learning.Core.Filters.Controllers.Test1
{
    /// <summary>
    /// Controller is an Action Filter
    /// And implement all required methods for that
    /// </summary>
    public class Test1Controller : Controller
    {
        public IActionResult Index() => View("Message",
            $"This is {ControllerContext.ActionDescriptor.DisplayName} from {nameof(Test1Controller)}");

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            // TODO: action filters for controller
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            // TODO: action filters for controller
        }
    }
}