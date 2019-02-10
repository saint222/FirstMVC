using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class FactionsController : Controller
    {
        private WarriorsContext db = new WarriorsContext();

        // GET: Factions
        public ActionResult Index()
        {
            return View(db.Factions.ToList());
        }

        // GET: Factions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faction faction = db.Factions.Find(id);
            if (faction == null)
            {
                return HttpNotFound();
            }
            return View(faction);
        }

        // GET: Factions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FactionName")] Faction faction)
        {
            if (ModelState.IsValid)
            {
                db.Factions.Add(faction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faction);
        }

        // GET: Factions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faction faction = db.Factions.Find(id);
            if (faction == null)
            {
                return HttpNotFound();
            }
            return View(faction);
        }

        // POST: Factions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FactionName")] Faction faction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faction);
        }

        // GET: Factions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faction faction = db.Factions.Find(id);
            if (faction == null)
            {
                return HttpNotFound();
            }
            return View(faction);
        }

        // POST: Factions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faction faction = db.Factions.Find(id);
            db.Factions.Remove(faction);
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
