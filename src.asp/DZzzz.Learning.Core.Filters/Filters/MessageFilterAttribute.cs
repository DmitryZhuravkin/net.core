using System.Text;

using Microsoft.AspNetCore.Mvc.Filters;

namespace DZzzz.Learning.Core.Filters.Filters
{
    public class MessageFilterAttribute : ResultFilterAttribute
    {
        private readonly string message;

        public MessageFilterAttribute(string msg)
        {
            message = msg;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            WriteMessage(context, $"<div>Before Result:{message}</div>");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            WriteMessage(context, $"<div>After Result:{message}</div>");
        }

        private void WriteMessage(FilterContext context, string msg)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"<div>{msg}</div>");
            context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
        }
    }
}