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
    public class CharacterTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CharacterTypes
        public ActionResult Index()
        {
            return View(db.CharacterTypes.ToList());
        }

        // GET: CharacterTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterType characterType = db.CharacterTypes.Find(id);
            if (characterType == null)
            {
                return HttpNotFound();
            }
            return View(characterType);
        }

        // GET: CharacterTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharacterTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharacterTypeId,CharacterClass")] CharacterType characterType)
        {
            if (ModelState.IsValid)
            {
                db.CharacterTypes.Add(characterType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(characterType);
        }

        // GET: CharacterTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterType characterType = db.CharacterTypes.Find(id);
            if (characterType == null)
            {
                return HttpNotFound();
            }
            return View(characterType);
        }

        // POST: CharacterTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacterTypeId,CharacterClass")] CharacterType characterType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(characterType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(characterType);
        }

        // GET: CharacterTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterType characterType = db.CharacterTypes.Find(id);
            if (characterType == null)
            {
                return HttpNotFound();
            }
            return View(characterType);
        }

        // POST: CharacterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharacterType characterType = db.CharacterTypes.Find(id);
            db.CharacterTypes.Remove(characterType);
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
