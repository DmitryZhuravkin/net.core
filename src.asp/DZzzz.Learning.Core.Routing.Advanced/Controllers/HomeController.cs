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

        public IActionResult CustomVariable(string id)
        {
            Result result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            };

            result.Data["ID"] = id ?? "<no value>";
            result.Data["Url"] = Url.Action("CustomVariable", "Home", new { id = 100 }); // generate in action method

            return View("Result", result);
        }
    }
}