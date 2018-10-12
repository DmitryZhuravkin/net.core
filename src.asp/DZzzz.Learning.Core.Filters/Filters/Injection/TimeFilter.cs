using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DZzzz.Learning.Core.Filters.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DZzzz.Learning.Core.Filters.Filters.Injection
{
    /// <summary>
    /// NOTE: this is not an attribute (because we don`t have a way to use attribute with DI, we need manually specify class object when use attribute)
    /// </summary>
    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private readonly ConcurrentQueue<double> actionTimes = new ConcurrentQueue<double>();
        private readonly ConcurrentQueue<double> resultTimes = new ConcurrentQueue<double>();
        private readonly IFilterDiagnostics diagnostics;

        public TimeFilter(IFilterDiagnostics diags)
        {
            diagnostics = diags;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Stopwatch timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            actionTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
            diagnostics.AddMessage($@"Action time: {timer.Elapsed.TotalMilliseconds} Average: {actionTimes.Average():F2}");
        }

        public async Task OnResultExecutionAsync(
            ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Stopwatch timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            resultTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
            diagnostics.AddMessage($@"Result time: {timer.Elapsed.TotalMilliseconds} Average: {resultTimes.Average():F2}");
        }
    }
}