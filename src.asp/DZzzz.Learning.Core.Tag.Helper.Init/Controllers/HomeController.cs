using DZzzz.Learning.Core.Tag.Helper.Init.Models;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Tag.Helper.Init.Controllers
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
        public IActionResult Create(City city)
        {
            repository.AddCity(city);

            return RedirectToAction("Index");
        }
    }
}