using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Routing.Areas.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        public async Task Index()
        {
            Response.StatusCode = 200;
            Response.ContentType = "text/html";

            byte[] content = Encoding.ASCII.GetBytes("<html><body>Home from ADMIN area</body>");

            await Response.Body.WriteAsync(content, 0, content.Length);
        }
    }
}