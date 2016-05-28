using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // Get latest event
            var currentEvent = db.Events.OrderByDescending(e => e.StartDateTime).FirstOrDefault();
            return View(currentEvent);
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