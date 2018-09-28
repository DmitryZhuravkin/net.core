using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DZzzz.Learning.Core.App.Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger) // custom logging
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            logger.LogDebug($"Request: {Request.Path}, handled at {DateTime.Now}");

            return View(new Dictionary<string, string>
            {
                ["Message"] = "First"
            });
        }
    }
}