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
    public class MapCharacterTypeStatsLevelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MapCharacterTypeStatsLevels
        public ActionResult Index()
        {
            var mapCharacterTypeStatsLevels = db.MapCharacterTypeStatsLevels.Include(m => m.CharacterType).Include(m => m.StatsLevel);
            return View(mapCharacterTypeStatsLevels.ToList());
        }

        // GET: MapCharacterTypeStatsLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel = db.MapCharacterTypeStatsLevels.Find(id);
            if (mapCharacterTypeStatsLevel == null)
            {
                return HttpNotFound();
            }
            return View(mapCharacterTypeStatsLevel);
        }

        // GET: MapCharacterTypeStatsLevels/Create
        public ActionResult Create()
        {
            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "CharacterTypeId", "CharacterClass");
            ViewBag.StatsLevelIId = new SelectList(db.StatsLevels, "StatsLevelId", "CharacterClass");
            return View();
        }

        // POST: MapCharacterTypeStatsLevels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapCharacterTypeStatsLevelId,CharacterTypeId,StatsLevelIId")] MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel)
        {
            if (ModelState.IsValid)
            {
                db.MapCharacterTypeStatsLevels.Add(mapCharacterTypeStatsLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "CharacterTypeId", "CharacterClass", mapCharacterTypeStatsLevel.CharacterTypeId);
            ViewBag.StatsLevelIId = new SelectList(db.StatsLevels, "StatsLevelId", "CharacterClass", mapCharacterTypeStatsLevel.StatsLevelIId);
            return View(mapCharacterTypeStatsLevel);
        }

        // GET: MapCharacterTypeStatsLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel = db.MapCharacterTypeStatsLevels.Find(id);
            if (mapCharacterTypeStatsLevel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "CharacterTypeId", "CharacterClass", mapCharacterTypeStatsLevel.CharacterTypeId);
            ViewBag.StatsLevelIId = new SelectList(db.StatsLevels, "StatsLevelId", "CharacterClass", mapCharacterTypeStatsLevel.StatsLevelIId);
            return View(mapCharacterTypeStatsLevel);
        }

        // POST: MapCharacterTypeStatsLevels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapCharacterTypeStatsLevelId,CharacterTypeId,StatsLevelIId")] MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapCharacterTypeStatsLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "CharacterTypeId", "CharacterClass", mapCharacterTypeStatsLevel.CharacterTypeId);
            ViewBag.StatsLevelIId = new SelectList(db.StatsLevels, "StatsLevelId", "CharacterClass", mapCharacterTypeStatsLevel.StatsLevelIId);
            return View(mapCharacterTypeStatsLevel);
        }

        // GET: MapCharacterTypeStatsLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel = db.MapCharacterTypeStatsLevels.Find(id);
            if (mapCharacterTypeStatsLevel == null)
            {
                return HttpNotFound();
            }
            return View(mapCharacterTypeStatsLevel);
        }

        // POST: MapCharacterTypeStatsLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel = db.MapCharacterTypeStatsLevels.Find(id);
            db.MapCharacterTypeStatsLevels.Remove(mapCharacterTypeStatsLevel);
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
