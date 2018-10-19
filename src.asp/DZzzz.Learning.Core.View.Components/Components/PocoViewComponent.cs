using System.Linq;
using DZzzz.Learning.Core.View.Components.Model.Base;

namespace DZzzz.Learning.Core.View.Components.Components
{
    public class PocoViewComponent // should follow {0}ViewComponent pattern
    {
        private readonly ICityRepository repository;

        public PocoViewComponent(ICityRepository repo)
        {
            repository = repo;
        }

        public string Invoke() // will be called to render, string will be converter automatically to ContentViewComponentResult class
        {
            return $"{repository.Cities.Count()} cities, " + $"{repository.Cities.Sum(c => c.Population)} people";
        }
    }
}