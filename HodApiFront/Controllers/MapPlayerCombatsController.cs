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
    public class MapPlayerCombatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MapPlayerCombats
        public ActionResult Index()
        {
            var mapPlayerCombats = db.MapPlayerCombats.Include(m => m.Combat).Include(m => m.Player);
            return View(mapPlayerCombats.ToList());
        }

        // GET: MapPlayerCombats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerCombat mapPlayerCombat = db.MapPlayerCombats.Find(id);
            if (mapPlayerCombat == null)
            {
                return HttpNotFound();
            }
            return View(mapPlayerCombat);
        }

        // GET: MapPlayerCombats/Create
        public ActionResult Create()
        {
            ViewBag.CombatId = new SelectList(db.Combats, "CombatId", "CombatId");
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name");
            return View();
        }

        // POST: MapPlayerCombats/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapPlayerCombatId,PlayerId,CombatId")] MapPlayerCombat mapPlayerCombat)
        {
            if (ModelState.IsValid)
            {
                db.MapPlayerCombats.Add(mapPlayerCombat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CombatId = new SelectList(db.Combats, "CombatId", "CombatId", mapPlayerCombat.CombatId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerCombat.PlayerId);
            return View(mapPlayerCombat);
        }

        // GET: MapPlayerCombats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerCombat mapPlayerCombat = db.MapPlayerCombats.Find(id);
            if (mapPlayerCombat == null)
            {
                return HttpNotFound();
            }
            ViewBag.CombatId = new SelectList(db.Combats, "CombatId", "CombatId", mapPlayerCombat.CombatId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerCombat.PlayerId);
            return View(mapPlayerCombat);
        }

        // POST: MapPlayerCombats/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapPlayerCombatId,PlayerId,CombatId")] MapPlayerCombat mapPlayerCombat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapPlayerCombat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CombatId = new SelectList(db.Combats, "CombatId", "CombatId", mapPlayerCombat.CombatId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerCombat.PlayerId);
            return View(mapPlayerCombat);
        }

        // GET: MapPlayerCombats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerCombat mapPlayerCombat = db.MapPlayerCombats.Find(id);
            if (mapPlayerCombat == null)
            {
                return HttpNotFound();
            }
            return View(mapPlayerCombat);
        }

        // POST: MapPlayerCombats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapPlayerCombat mapPlayerCombat = db.MapPlayerCombats.Find(id);
            db.MapPlayerCombats.Remove(mapPlayerCombat);
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
