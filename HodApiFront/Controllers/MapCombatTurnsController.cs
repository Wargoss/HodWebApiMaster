using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HodApiFront.Models;

namespace HodApiFront.Controllers
{
    public class MapCombatTurnsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MapCombatTurns
        public ActionResult Index()
        {
            var mapCombatTurns = db.MapCombatTurns.Include(m => m.Combat).Include(m => m.Turn);
            return View(mapCombatTurns.ToList());
        }

        // GET: MapCombatTurns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapCombatTurn mapCombatTurn = db.MapCombatTurns.Find(id);
            if (mapCombatTurn == null)
            {
                return HttpNotFound();
            }
            return View(mapCombatTurn);
        }

        // GET: MapCombatTurns/Create
        public ActionResult Create()
        {
            ViewBag.CombatId = new SelectList(db.Combats, "CombatId", "CombatId");
            ViewBag.TurnId = new SelectList(db.Turns, "TurnId", "TurnId");
            return View();
        }

        // POST: MapCombatTurns/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapCombatTurnId,CombatId,TurnId")] MapCombatTurn mapCombatTurn)
        {
            if (ModelState.IsValid)
            {
                db.MapCombatTurns.Add(mapCombatTurn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CombatId = new SelectList(db.Combats, "CombatId", "CombatId", mapCombatTurn.CombatId);
            ViewBag.TurnId = new SelectList(db.Turns, "TurnId", "TurnId", mapCombatTurn.TurnId);
            return View(mapCombatTurn);
        }

        // GET: MapCombatTurns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapCombatTurn mapCombatTurn = db.MapCombatTurns.Find(id);
            if (mapCombatTurn == null)
            {
                return HttpNotFound();
            }
            ViewBag.CombatId = new SelectList(db.Combats, "CombatId", "CombatId", mapCombatTurn.CombatId);
            ViewBag.TurnId = new SelectList(db.Turns, "TurnId", "TurnId", mapCombatTurn.TurnId);
            return View(mapCombatTurn);
        }

        // POST: MapCombatTurns/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapCombatTurnId,CombatId,TurnId")] MapCombatTurn mapCombatTurn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapCombatTurn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CombatId = new SelectList(db.Combats, "CombatId", "CombatId", mapCombatTurn.CombatId);
            ViewBag.TurnId = new SelectList(db.Turns, "TurnId", "TurnId", mapCombatTurn.TurnId);
            return View(mapCombatTurn);
        }

        // GET: MapCombatTurns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapCombatTurn mapCombatTurn = db.MapCombatTurns.Find(id);
            if (mapCombatTurn == null)
            {
                return HttpNotFound();
            }
            return View(mapCombatTurn);
        }

        // POST: MapCombatTurns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapCombatTurn mapCombatTurn = db.MapCombatTurns.Find(id);
            db.MapCombatTurns.Remove(mapCombatTurn);
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
