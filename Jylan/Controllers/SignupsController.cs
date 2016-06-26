using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using Jylan.Models;

namespace Jylan.Controllers
{
    public class SignupsController : Controller
    {
        private readonly JylanContext db = new JylanContext();
        // GET: Signups
        [Authorize(Roles = "Admin")]
        [Route("Tilmeldinger")]
        public ActionResult Index()
        {
            return View(db.Signups.ToList());
        }

        // GET: Signups/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var signup = db.Signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // GET: Signups/Create
        [Route("Tilmelding")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Tilmelding")]
        public ActionResult Create(
            [Bind(Include = "SignupId,EmailAddress,Nick,FirstName,LastName,PhoneNumber,HasPayed")] Signup signup)
        {
            if (ModelState.IsValid)
            {
                var currentEvent = db.Events.OrderByDescending(e => e.StartDateTime).FirstOrDefault();
                currentEvent.Signups.Add(signup);
                db.SaveChanges();
                var client = new SmtpClient();
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("noreply@jylan.dk", "JYLAN", Encoding.UTF8);
                mailMessage.To.Add(signup.EmailAddress);
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "Tak for din tilmelding";
                mailMessage.Body = "<strong>Hej " + signup.FirstName + "</strong> <br />" +
                                   "Dette er en bekræftelse for din tilmelding til " + currentEvent.Name + "<br />" +
                                   "Information omkring eventet og betaling kan findes på jylan.dk/Information <br />" +
                                   "Husk at du kun har sikret din plads, ved at betale på forhånd! <br />" +
                                   "Vi glæder os til at se dig d. " + currentEvent.StartDateTime.ToString("d. MMM yyyy") +
                                   ", kl. " + currentEvent.StartDateTime.ToString("HH:mm") + "<br /> <br />" +
                                   "Venlig hilsen <br />" +
                                   "<strong>JYLAN</strong><br />";
                client.Send(mailMessage);
                return RedirectToAction("SignupComplete", signup);
            }

            return View(signup);
        }

        // GET: Signups/Edit/5
        [Authorize(Roles = "Admin")]
        [Route("Tilmeldinger/{id:int}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentEvent = db.Events.OrderByDescending(e => e.StartDateTime).FirstOrDefault();
            if (currentEvent == null)
            {
                return HttpNotFound();
            }
            var signup = currentEvent.Signups.FirstOrDefault(s => s.SignupId == id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // POST: Signups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Tilmeldinger/{id:int}")]
        public ActionResult Edit(
            [Bind(Include = "SignupId,EmailAddress,Nick,FirstName,LastName,PhoneNumber,HasPayed")] Signup signup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Events");
            }
            return View(signup);
        }

        // GET: Signups/Delete/5
        [Authorize(Roles = "Admin")]
        [Route("Tilmeldinger/Slet/{id:int}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentEvent = db.Events.OrderByDescending(e => e.StartDateTime).FirstOrDefault();
            if (currentEvent == null)
                return HttpNotFound();
            var signup = currentEvent.Signups.FirstOrDefault(s => s.SignupId == id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // POST: Signups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Tilmeldinger/Slet/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            var currentEvent = db.Events.OrderByDescending(e => e.StartDateTime).FirstOrDefault();
            var signup = currentEvent.Signups.FirstOrDefault(s => s.SignupId == id);
            currentEvent.Signups.Remove(signup);
            db.SaveChanges();
            return RedirectToAction("Index", "Events");
        }

        // Custom control for custom view
        public ActionResult SignupComplete(Signup signup)
        {
            var currentEvent = db.Events.OrderByDescending(e => e.StartDateTime).FirstOrDefault();
            ViewBag.EventPrice = 0;
            if (currentEvent != null) ViewBag.EventPrice = currentEvent.Price;
            return View(signup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}