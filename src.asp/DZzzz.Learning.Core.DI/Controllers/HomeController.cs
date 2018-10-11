using DZzzz.Learning.Core.DI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Microsoft.Extensions.DependencyInjection;

namespace DZzzz.Learning.Core.DI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository repository;

        // property injection

        [ControllerContext]
        public ControllerContext CContext { get; set; }

        [ActionContext]
        public ActionContext AContext { get; set; }

        [ViewContext]
        public ViewContext VContext { get; set; }

        [ViewComponentContext]
        public ViewComponentContext VcContext { get; set; }

        [ViewDataDictionary]
        public ViewDataDictionary ViewDataDictionary { get; set; }

        public HomeController(IProductRepository repository) // normal injection
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var products = repository.GetProducts();

            return new ObjectResult(products);
        }

        public IActionResult ActionInjection([FromServices]IActionProductRepository actionRepository)
        {
            var products = actionRepository.GetProducts();

            return new ObjectResult(products);
        }

        public IActionResult ManualServiceRequest()
        {
            var products = HttpContext.RequestServices.GetService<IProductRepository>(); // service locator pattern

            return new ObjectResult(products);
        }
    }
}