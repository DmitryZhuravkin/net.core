using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.View.Components.Components
{
    public class PageSize : ViewComponent
    {
        // async view component
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://apress.com");

            // await Task.Delay(10000); page load will wait until this delay is finished

            return View(response.Content.Headers.ContentLength.GetValueOrDefault());
        }
    }
}