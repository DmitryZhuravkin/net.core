using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DZzzz.Learning.Core.Filters.Filters
{
    /// <inheritdoc />
    /// <summary>
    /// Custom Action filter example
    /// </summary>
    public class ProfileFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch timer;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            timer = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            timer.Stop();

            string result = "<div>Elapsed time: "
                            + $"{timer.Elapsed.TotalMilliseconds} ms</div>";

            byte[] bytes = Encoding.ASCII.GetBytes(result);
            context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
        }
    }
}