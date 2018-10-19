using DZzzz.Learning.Core.View.Components.Model;
using DZzzz.Learning.Core.View.Components.Model.Base;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.View.Components.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository repository;

        public HomeController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);
        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product newProduct) // post-redirect
        {
            repository.AddProduct(newProduct);

            return RedirectToAction("Index");
        }
    }
}