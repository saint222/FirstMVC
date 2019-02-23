using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Helpers;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class WarriorsController : Controller
    {
        private WarriorsContext db = new WarriorsContext();
        //get Fight
        public async Task<ActionResult> Fight () // асинхронный метод Fight
        {
            return View(await db.Warriors.ToListAsync());
        }

        [HttpPost]
        public ActionResult Fight(int[] fighters)
        {
            int rndId = fighters[0];
            var figter_1 = db.Warriors.FirstOrDefault(x => x.Id == rndId);
            rndId = fighters[1];
            var figter_2 = db.Warriors.FirstOrDefault(x => x.Id == rndId);
            int conditionFirst = figter_1.HP;
            int conditionSecond = figter_2.HP;
            while (conditionFirst > 0 && conditionSecond > 0)
            {
                var damage_1 = figter_2.AttackStrength - figter_1.BlockStrength;
                if (damage_1 > 10)
                {
                    conditionFirst = conditionFirst - damage_1;                   
                }
                else
                {
                    conditionFirst = conditionFirst - (MyRandom.Rand.Next(1, 6)); //рандом через статик-класс                    
                }
                var damge_2 = figter_1.AttackStrength - figter_2.BlockStrength;
                if (damge_2 > 10)
                {
                    conditionSecond = conditionSecond - damge_2;                    
                }
                else
                {
                    conditionSecond = conditionSecond - (MyRandom.Rand.Next(1, 6)); //рандом через статик-класс                    
                }
                if (conditionFirst <= 0)
                {                    
                    return View(viewName: "FightRes", model: $"{figter_1.WarriorName} kicked {figter_2.WarriorName}'s ass and robbed his cOrOvan...");
                }
                else if (conditionSecond <= 0)
                {                    
                    return View(viewName: "FightRes", model: $"{figter_2.WarriorName} kicked {figter_1.WarriorName}'s ass and robbed his cOrOvan...");
                }
            }
            return View(model: "bug");
        }


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