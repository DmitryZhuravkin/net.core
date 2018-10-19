using System.Collections.Generic;
using DZzzz.Learning.Core.View.Components.Model;
using DZzzz.Learning.Core.View.Components.Model.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DZzzz.Learning.Core.View.Components.Controllers
{
    // this is Hybrid Controller/View Component
    [ViewComponent(Name = "ComboComponent")]
    public class CityController : Controller
    {
        private readonly ICityRepository repository;

        public CityController(ICityRepository repo)
        {
            repository = repo;
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(City newCity)
        {
            repository.AddCity(newCity);
            return RedirectToAction("Index", "Home");
        }

        public IViewComponentResult Invoke() => new ViewViewComponentResult()
        {
            ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData,
                repository.Cities)
        };
    }
}