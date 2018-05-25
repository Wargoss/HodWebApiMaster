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
    public class MapPlayerGuildsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MapPlayerGuilds
        public ActionResult Index()
        {
            var mapPlayerGuilds = db.MapPlayerGuilds.Include(m => m.Guild).Include(m => m.Player);
            return View(mapPlayerGuilds.ToList());
        }

        // GET: MapPlayerGuilds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerGuild mapPlayerGuild = db.MapPlayerGuilds.Find(id);
            if (mapPlayerGuild == null)
            {
                return HttpNotFound();
            }
            return View(mapPlayerGuild);
        }

        // GET: MapPlayerGuilds/Create
        public ActionResult Create()
        {
            ViewBag.GuildId = new SelectList(db.Guilds, "GuildId", "Name");
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name");
            return View();
        }

        // POST: MapPlayerGuilds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapPlayerGuildId,PlayerId,GuildId")] MapPlayerGuild mapPlayerGuild)
        {
            if (ModelState.IsValid)
            {
                db.MapPlayerGuilds.Add(mapPlayerGuild);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuildId = new SelectList(db.Guilds, "GuildId", "Name", mapPlayerGuild.GuildId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerGuild.PlayerId);
            return View(mapPlayerGuild);
        }

        // GET: MapPlayerGuilds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerGuild mapPlayerGuild = db.MapPlayerGuilds.Find(id);
            if (mapPlayerGuild == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuildId = new SelectList(db.Guilds, "GuildId", "Name", mapPlayerGuild.GuildId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerGuild.PlayerId);
            return View(mapPlayerGuild);
        }

        // POST: MapPlayerGuilds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapPlayerGuildId,PlayerId,GuildId")] MapPlayerGuild mapPlayerGuild)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapPlayerGuild).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuildId = new SelectList(db.Guilds, "GuildId", "Name", mapPlayerGuild.GuildId);
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerGuild.PlayerId);
            return View(mapPlayerGuild);
        }

        // GET: MapPlayerGuilds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerGuild mapPlayerGuild = db.MapPlayerGuilds.Find(id);
            if (mapPlayerGuild == null)
            {
                return HttpNotFound();
            }
            return View(mapPlayerGuild);
        }

        // POST: MapPlayerGuilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapPlayerGuild mapPlayerGuild = db.MapPlayerGuilds.Find(id);
            db.MapPlayerGuilds.Remove(mapPlayerGuild);
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
