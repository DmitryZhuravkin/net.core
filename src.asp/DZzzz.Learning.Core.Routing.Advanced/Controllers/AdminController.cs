using DZzzz.Learning.Core.Routing.Advanced.Model;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Routing.Advanced.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(AdminController),
                Action = nameof(Index)
            });
        }
    }
}