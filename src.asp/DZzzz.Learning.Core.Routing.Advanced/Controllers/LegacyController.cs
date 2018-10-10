using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Routing.Advanced.Controllers
{
    public class LegacyController : Controller
    {
        public ViewResult GetLegacyUrl(string legacyUrl) => View((object)legacyUrl);
    }
}