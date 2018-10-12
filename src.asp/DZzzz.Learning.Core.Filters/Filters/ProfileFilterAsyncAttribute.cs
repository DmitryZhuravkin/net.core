using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DZzzz.Learning.Core.Filters.Filters
{
    public class ProfileFilterAsyncAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Stopwatch timer = Stopwatch.StartNew();

            await next(); // ACTION DELEGATE

            timer.Stop();

            string result = "<div>Elapsed time: "
                            + $"{timer.Elapsed.TotalMilliseconds} ms</div>";

            byte[] bytes = Encoding.ASCII.GetBytes(result);
            await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}