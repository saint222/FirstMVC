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
    public class WarriorsController : Controller
    {
        private WarriorsContext db = new WarriorsContext();
        

        // GET: Warriors
        public ActionResult Index()
        {
            return View(db.Warriors.ToList());
        }

        // GET: Warriors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warrior warrior = db.Warriors.Find(id);
            if (warrior == null)
            {
                return HttpNotFound();
            }
            return View(warrior);
        }

        // GET: Warriors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warriors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WarriorName,HP,AttackStrength,BlockStrength,Price,SquadId")] Warrior warrior)
        {
            if (ModelState.IsValid)
            {
                db.Warriors.Add(warrior);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warrior);
        }

        // GET: Warriors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warrior warrior = db.Warriors.Find(id);
            if (warrior == null)
            {
                return HttpNotFound();
            }
            return View(warrior);
        }

        // POST: Warriors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WarriorName,HP,AttackStrength,BlockStrength,Price,SquadId")] Warrior warrior)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warrior).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warrior);
        }

        // GET: Warriors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warrior warrior = db.Warriors.Find(id);
            if (warrior == null)
            {
                return HttpNotFound();
            }
            return View(warrior);
        }

        // POST: Warriors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warrior warrior = db.Warriors.Find(id);
            db.Warriors.Remove(warrior);
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
