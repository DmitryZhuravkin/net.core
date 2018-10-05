using DZzzz.Learning.Core.Routing.Advanced.Model;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Routing.Advanced.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });
        }

        public IActionResult CustomVariable()
        {
            return View("Result", new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            });
        }
    }
}