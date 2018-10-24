using DZzzz.Learning.Core.Model.Binding.Models;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Model.Binding.Controllers
{
    //The model binding system relies on model binders, which are components responsible for providing
    //data values from one part of the request or application.The default model binders look for data values in
    //these three places:
    //•	 Form data values
    //•	 Routing variables
    //•	 Query strings
    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(int? id)
        {
            Person person;
            if (id.HasValue && (person = repository[id.Value]) != null)
            {
                return View(person);
            }

            return NotFound();
        }

        public IActionResult Create() => View(new Person());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person) => View("Index", person);

        // Bind attribute specify Prefix value which is used on HTML: right now HomeAddress.City can be bound to City property for AddressSummary
        
        public IActionResult DisplaySummary([Bind(Prefix = nameof(Person.HomeAddress))]AddressSummary summary) => View(summary);

        // Also bind can be used to bind only specific list of properties
        //public IActionResult DisplaySummary([Bind(nameof(AddressSummary.City), Prefix = nameof(Person.HomeAddress))]AddressSummary summary) => View(summary);
    }
}