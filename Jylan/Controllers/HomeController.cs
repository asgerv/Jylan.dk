using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Jylan.Models;

namespace Jylan.Controllers
{
    public class HomeController : Controller
    {
        // Måske ikke helt optimalt.
        private readonly JylanContext db = new JylanContext();

        public ActionResult Index()
        {
            //var landingPageViewModel = db.Signups.ToLandingPageViewModel(db.Events.ToList().LastOrDefault());
            var currentEvent = from e in db.Events
                orderby e.StartDateTime
                select e;
            var testEvent = new Event
            {
                StartDateTime = DateTime.Now.AddDays(-5),
                EndDateTime = DateTime.Now.AddDays(-2),
                MaxSignups = 100,
                Name = "Jylan #5",
                Signups = new List<Signup>()
            };

            //return View(currentEvent.FirstOrDefault());
            return View(db.Events.OrderBy(e => e.StartDateTime).FirstOrDefault());
        }

        [Route("Information")]
        public ActionResult About()
        {
            var currentEvent = db.Events.ToList().LastOrDefault();
            ViewBag.EventPrice = 0;
            if (currentEvent != null) ViewBag.EventPrice = currentEvent.Price;
            return View();
        }

        [Route("Kontakt")]
        public ActionResult Contact()
        {
            return View();
        }
    }
}