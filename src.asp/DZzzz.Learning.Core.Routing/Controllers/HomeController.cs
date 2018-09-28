using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Routing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}