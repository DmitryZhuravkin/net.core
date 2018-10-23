using DZzzz.Learning.Core.BuiltIn.Tag.Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.BuiltIn.Tag.Helpers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Cities);

        public ViewResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {
            repository.AddCity(city);

            return RedirectToAction("Index");
        }
    }
}