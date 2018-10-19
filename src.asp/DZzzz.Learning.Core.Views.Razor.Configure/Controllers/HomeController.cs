using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Views.Razor.Configure.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() =>
            View("MyView", new[] { "Apple", "Orange", "Pear" });

        public IActionResult List() => View();
    }
}