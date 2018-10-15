using DZzzz.Learning.Core.Api.Models;

using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Api.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository { get; }

        public HomeController(IRepository repo) => repository = repo;

        public ViewResult Index() => View(repository.Reservations);

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            repository.AddReservation(reservation);
            // Post/Redirect/Get pattern
            return RedirectToAction("Index");
        }
    }
}