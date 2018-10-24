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

        public ViewResult Index(int id) => View(repository[id]);
    }
}