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
            return View(db.Signups.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}