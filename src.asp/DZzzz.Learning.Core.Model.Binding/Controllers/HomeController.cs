using System.Collections.Generic;
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

        //public IActionResult DisplaySummary([Bind(Prefix = nameof(Person.HomeAddress))]AddressSummary summary) => View(summary);

        // Also bind can be used to bind only specific list of properties
        public IActionResult DisplaySummary([Bind(nameof(AddressSummary.City), Prefix = nameof(Person.HomeAddress))]AddressSummary summary) => View(summary);

        public IActionResult Names(string[] names) => View(names ?? new string[0]); // we can use IList<>

        public IActionResult Address(IList<AddressSummary> addresses) => View(addresses ?? new List<AddressSummary>());

        // /home/DisplaySummaryFromQuery?City=1&Country = 22 - will be successfully parsed and processed with this action
        public IActionResult DisplaySummaryFromQuery(AddressSummary summary) => View("DisplaySummary", summary);


        // customize modl binding system
        public string Header([FromHeader] string accept, [FromHeader(Name = "Accept-Language")] string acceptLanguage) =>
            $"Accept: {accept}, Accept-Language: {acceptLanguage}";

        public string HeaderModel(HeaderModel headerModel) => headerModel?.ToString();


        // need to understand, FromBody - data is from HTML body, but data isn`t form-encoded
        public ViewResult Body() => View();

        [HttpPost]
        public Person Body([FromBody]Person model) => model;
    }
}