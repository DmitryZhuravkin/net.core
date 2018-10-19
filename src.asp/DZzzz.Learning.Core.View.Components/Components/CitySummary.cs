using System.Linq;
using DZzzz.Learning.Core.View.Components.Model;
using DZzzz.Learning.Core.View.Components.Model.Base;

using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.View.Components.Components
{
    public class CitySummary : ViewComponent
    {
        private readonly ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }

        //public string Invoke() // will be called to render, string will be converter automatically to ContentViewComponentResult class
        //{
        //    return $"{repository.Cities.Count()} cities, " + $"{repository.Cities.Sum(c => c.Population)} people";
        //}

        //public IViewComponentResult Invoke() will be converter automatically to ContentViewComponentResult class
        //{
        //    return Content("This is a <h3><i>string</i></h3>");
        //}

        //public IViewComponentResult Invoke()
        //{
        //    // Default locations for this:
        //    // Views / Home / Components / CitySummary / Default.cshtml
        //    // Views / Shared / Components / CitySummary / Default.cshtml
        //    // Pages / Shared / Components / CitySummary / Default.cshtml

        //    return View(new CityViewModel
        //    {
        //        Cities = repository.Cities.Count(),
        //        Population = repository.Cities.Sum(c => c.Population)
        //    }); // converter to ViewViewComponentResult class
        //}

        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
            {
                return View("CityList", repository.Cities);
            }

            return View(new CityViewModel
            {
                Cities = repository.Cities.Count(),
                Population = repository.Cities.Sum(c => c.Population)
            }); // converter to ViewViewComponentResult class
        }
    }
}