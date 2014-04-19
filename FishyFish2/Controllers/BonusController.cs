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
    public class BonusController : Controller
    {
        private FishContext db = new FishContext();

        // GET: /Bonus/
        public ActionResult Index()
        {
            var bonuses = db.Bonuses.Include(b => b.Team);
            return View(bonuses.ToList());
        }

        // GET: /Bonus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonus bonus = db.Bonuses.Find(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            return View(bonus);
        }

        // GET: /Bonus/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View();
        }

        // POST: /Bonus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BonusId,TeamId,Amount,Comment")] Bonus bonus)
        {
            if (ModelState.IsValid)
            {
                db.Bonuses.Add(bonus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", bonus.TeamId);
            return View(bonus);
        }

        // GET: /Bonus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonus bonus = db.Bonuses.Find(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", bonus.TeamId);
            return View(bonus);
        }

        // POST: /Bonus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BonusId,TeamId,Amount,Comment")] Bonus bonus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bonus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", bonus.TeamId);
            return View(bonus);
        }

        // GET: /Bonus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonus bonus = db.Bonuses.Find(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            return View(bonus);
        }

        // POST: /Bonus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bonus bonus = db.Bonuses.Find(id);
            db.Bonuses.Remove(bonus);
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
