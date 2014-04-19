using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FishyFish2.Models;
using FishyFish2.DAL;

namespace FishyFish2.Controllers
{
    public class CatchController : Controller
    {
        private FishContext db = new FishContext();

        // GET: /Catch/
        public ActionResult Index()
        {
            return View(db.Catches.ToList());
        }

        // GET: /Catch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catch @catch = db.Catches.Find(id);
            if (@catch == null)
            {
                return HttpNotFound();
            }
            return View(@catch);
        }

        // GET: /Catch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Catch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CatchId,PersonId,Inches,DateSubmitted,Photo1,Photo2,Verified,DateVerified,Posted,Species")] Catch @catch)
        {
            if (ModelState.IsValid)
            {
                db.Catches.Add(@catch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@catch);
        }

        // GET: /Catch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catch @catch = db.Catches.Find(id);
            if (@catch == null)
            {
                return HttpNotFound();
            }
            return View(@catch);
        }

        // POST: /Catch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CatchId,PersonId,Inches,DateSubmitted,Photo1,Photo2,Verified,DateVerified,Posted,Species")] Catch @catch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@catch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@catch);
        }

        // GET: /Catch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catch @catch = db.Catches.Find(id);
            if (@catch == null)
            {
                return HttpNotFound();
            }
            return View(@catch);
        }

        // POST: /Catch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catch @catch = db.Catches.Find(id);
            db.Catches.Remove(@catch);
            db.SaveChanges();
            return RedirectToAction("Index");
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
