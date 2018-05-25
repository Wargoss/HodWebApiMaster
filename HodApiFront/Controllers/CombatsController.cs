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
    public class CombatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Combats
        public ActionResult Index()
        {
            return View(db.Combats.ToList());
        }

        // GET: Combats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combat combat = db.Combats.Find(id);
            if (combat == null)
            {
                return HttpNotFound();
            }
            return View(combat);
        }

        // GET: Combats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Combats/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CombatId,CombatDate,Winner")] Combat combat)
        {
            if (ModelState.IsValid)
            {
                db.Combats.Add(combat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(combat);
        }

        // GET: Combats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combat combat = db.Combats.Find(id);
            if (combat == null)
            {
                return HttpNotFound();
            }
            return View(combat);
        }

        // POST: Combats/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CombatId,CombatDate,Winner")] Combat combat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(combat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(combat);
        }

        // GET: Combats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combat combat = db.Combats.Find(id);
            if (combat == null)
            {
                return HttpNotFound();
            }
            return View(combat);
        }

        // POST: Combats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Combat combat = db.Combats.Find(id);
            db.Combats.Remove(combat);
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
