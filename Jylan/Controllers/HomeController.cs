using System.Linq;
using System.Web.Mvc;
using Jylan.Extensions;
using Jylan.Models;

namespace Jylan.Controllers
{
    public class HomeController : Controller
    {
        // Måske ikke helt optimalt.
        private readonly JylanContext db = new JylanContext();

        public ActionResult Index()
        {
            var landingPageViewModel = db.Signups.ToLandingPageViewModel(db.Events.ToList().LastOrDefault());

            return View(landingPageViewModel);
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