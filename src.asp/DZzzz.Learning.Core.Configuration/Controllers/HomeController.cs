using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Configuration.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(new Dictionary<string, string>
        {
            ["Message"] = "First"
        });
    }
}