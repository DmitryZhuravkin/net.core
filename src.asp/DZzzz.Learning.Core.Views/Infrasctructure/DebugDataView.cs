using System;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace DZzzz.Learning.Core.Views.Infrasctructure
{
    public class DebugDataView : IView
    {
        public string Path { get; } = String.Empty; // path to view (if it is file on disk)

        public async Task RenderAsync(ViewContext context) // generate response to client
        {
            context.HttpContext.Response.ContentType = "text/plain";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---Routing Data---");
            foreach (var kvp in context.RouteData.Values)
            {
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            sb.AppendLine("---View Data---");
            foreach (var kvp in context.ViewData)
            {
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            await context.Writer.WriteAsync(sb.ToString());
        }
    }
}