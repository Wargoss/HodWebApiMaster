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
    public class MapPlayerCharactersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MapPlayerCharacters
        public ActionResult Index()
        {
            var mapPlayerCharacters = db.MapPlayerCharacters.Include(m => m.Character).Include(m => m.Player);
            return View(mapPlayerCharacters.ToList());
        }

        // GET: MapPlayerCharacters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerCharacter mapPlayerCharacter = db.MapPlayerCharacters.Find(id);
            if (mapPlayerCharacter == null)
            {
                return HttpNotFound();
            }
            return View(mapPlayerCharacter);
        }

        // GET: MapPlayerCharacters/Create
        public ActionResult Create()
        {
            ViewBag.CharacterId = new SelectList(db.Characters, "CharacterId", "CharacterId");
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name");
            return View();
        }

        // POST: MapPlayerCharacters/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapPlayerCharacterId,PlayerId,CharacterId")] MapPlayerCharacter mapPlayerCharacter)
        {
            if (ModelState.IsValid)
            {
                db.MapPlayerCharacters.Add(mapPlayerCharacter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharacterId = new SelectList(db.Characters, "CharacterId", "CharacterId", mapPlayerCharacter.CharacterId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerCharacter.PlayerId);
            return View(mapPlayerCharacter);
        }

        // GET: MapPlayerCharacters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerCharacter mapPlayerCharacter = db.MapPlayerCharacters.Find(id);
            if (mapPlayerCharacter == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterId = new SelectList(db.Characters, "CharacterId", "CharacterId", mapPlayerCharacter.CharacterId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerCharacter.PlayerId);
            return View(mapPlayerCharacter);
        }

        // POST: MapPlayerCharacters/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapPlayerCharacterId,PlayerId,CharacterId")] MapPlayerCharacter mapPlayerCharacter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapPlayerCharacter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterId = new SelectList(db.Characters, "CharacterId", "CharacterId", mapPlayerCharacter.CharacterId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerCharacter.PlayerId);
            return View(mapPlayerCharacter);
        }

        // GET: MapPlayerCharacters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerCharacter mapPlayerCharacter = db.MapPlayerCharacters.Find(id);
            if (mapPlayerCharacter == null)
            {
                return HttpNotFound();
            }
            return View(mapPlayerCharacter);
        }

        // POST: MapPlayerCharacters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapPlayerCharacter mapPlayerCharacter = db.MapPlayerCharacters.Find(id);
            db.MapPlayerCharacters.Remove(mapPlayerCharacter);
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
