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
    public class StatsLevelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StatsLevels
        public ActionResult Index()
        {
            return View(db.StatsLevels.ToList());
        }

        // GET: StatsLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatsLevel statsLevel = db.StatsLevels.Find(id);
            if (statsLevel == null)
            {
                return HttpNotFound();
            }
            return View(statsLevel);
        }

        // GET: StatsLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatsLevels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatsLevelId,CharacterClass,Level,Int,Str,Res")] StatsLevel statsLevel)
        {
            if (ModelState.IsValid)
            {
                db.StatsLevels.Add(statsLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statsLevel);
        }

        // GET: StatsLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatsLevel statsLevel = db.StatsLevels.Find(id);
            if (statsLevel == null)
            {
                return HttpNotFound();
            }
            return View(statsLevel);
        }

        // POST: StatsLevels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatsLevelId,CharacterClass,Level,Int,Str,Res")] StatsLevel statsLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statsLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statsLevel);
        }

        // GET: StatsLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatsLevel statsLevel = db.StatsLevels.Find(id);
            if (statsLevel == null)
            {
                return HttpNotFound();
            }
            return View(statsLevel);
        }

        // POST: StatsLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatsLevel statsLevel = db.StatsLevels.Find(id);
            db.StatsLevels.Remove(statsLevel);
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
