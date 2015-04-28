﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Jylan.Models;

namespace Jylan.Controllers
{
    public class SignupsController : Controller
    {
        private readonly JylanContext db = new JylanContext();
        // GET: Signups
        [Authorize(Roles = "Admin")]
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "SignupId,EmailAddress,Nick,FirstName,LastName,PhoneNumber,HasPayed")] Signup signup)
        {
            if (ModelState.IsValid)
            {
                db.Signups.Add(signup);
                db.SaveChanges();
                return RedirectToAction("SignupComplete", signup);
            }

            return View(signup);
        }

        // GET: Signups/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
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

        // POST: Signups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(
            [Bind(Include = "SignupId,EmailAddress,Nick,FirstName,LastName,PhoneNumber,HasPayed")] Signup signup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signup);
        }

        // GET: Signups/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
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

        // POST: Signups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            var signup = db.Signups.Find(id);
            db.Signups.Remove(signup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Custom control for custom view
        public ActionResult SignupComplete(Signup signup)
        {
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