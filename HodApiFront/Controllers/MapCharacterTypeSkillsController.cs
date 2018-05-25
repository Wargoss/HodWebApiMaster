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
    public class MapCharacterTypeSkillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MapCharacterTypeSkills
        public ActionResult Index()
        {
            var mapCharacterTypeSkills = db.MapCharacterTypeSkills.Include(m => m.CharacterType).Include(m => m.Skill);
            return View(mapCharacterTypeSkills.ToList());
        }

        // GET: MapCharacterTypeSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapCharacterTypeSkill mapCharacterTypeSkill = db.MapCharacterTypeSkills.Find(id);
            if (mapCharacterTypeSkill == null)
            {
                return HttpNotFound();
            }
            return View(mapCharacterTypeSkill);
        }

        // GET: MapCharacterTypeSkills/Create
        public ActionResult Create()
        {
            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "CharacterTypeId", "CharacterClass");
            ViewBag.SkillId = new SelectList(db.Skills, "SkillId", "SkillText");
            return View();
        }

        // POST: MapCharacterTypeSkills/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapCharacterTypeSkillId,CharacterTypeId,SkillId")] MapCharacterTypeSkill mapCharacterTypeSkill)
        {
            if (ModelState.IsValid)
            {
                db.MapCharacterTypeSkills.Add(mapCharacterTypeSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "CharacterTypeId", "CharacterClass", mapCharacterTypeSkill.CharacterTypeId);
            ViewBag.SkillId = new SelectList(db.Skills, "SkillId", "SkillText", mapCharacterTypeSkill.SkillId);
            return View(mapCharacterTypeSkill);
        }

        // GET: MapCharacterTypeSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapCharacterTypeSkill mapCharacterTypeSkill = db.MapCharacterTypeSkills.Find(id);
            if (mapCharacterTypeSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "CharacterTypeId", "CharacterClass", mapCharacterTypeSkill.CharacterTypeId);
            ViewBag.SkillId = new SelectList(db.Skills, "SkillId", "SkillText", mapCharacterTypeSkill.SkillId);
            return View(mapCharacterTypeSkill);
        }

        // POST: MapCharacterTypeSkills/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapCharacterTypeSkillId,CharacterTypeId,SkillId")] MapCharacterTypeSkill mapCharacterTypeSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapCharacterTypeSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "CharacterTypeId", "CharacterClass", mapCharacterTypeSkill.CharacterTypeId);
            ViewBag.SkillId = new SelectList(db.Skills, "SkillId", "SkillText", mapCharacterTypeSkill.SkillId);
            return View(mapCharacterTypeSkill);
        }

        // GET: MapCharacterTypeSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapCharacterTypeSkill mapCharacterTypeSkill = db.MapCharacterTypeSkills.Find(id);
            if (mapCharacterTypeSkill == null)
            {
                return HttpNotFound();
            }
            return View(mapCharacterTypeSkill);
        }

        // POST: MapCharacterTypeSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapCharacterTypeSkill mapCharacterTypeSkill = db.MapCharacterTypeSkills.Find(id);
            db.MapCharacterTypeSkills.Remove(mapCharacterTypeSkill);
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
