using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Views.Razor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(new[] { "Apple", "Orange", "Pear" });

        public ViewResult List() => View();
    }
}