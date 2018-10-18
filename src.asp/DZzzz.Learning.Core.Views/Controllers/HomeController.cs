using System;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello, World";
            ViewBag.Time = DateTime.UtcNow.ToString("HH:mm:ss");

            return View("DebugData");
        }

        public ViewResult List() => View();
    }
}