using System.Linq;
using DZzzz.Learning.Core.Form.Tag.Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Form.Tag.Helpers.Controllers
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

        public ViewResult Edit() => View("Create", repository.Cities.FirstOrDefault());

        [HttpPost]
        [ValidateAntiForgeryToken] // don`t forget to do this for ALL port request
        public IActionResult Create(City city)
        {
            repository.AddCity(city);

            return RedirectToAction("Index");
        }
    }
}