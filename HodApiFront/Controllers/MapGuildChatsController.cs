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
    public class MapGuildChatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MapGuildChats
        public ActionResult Index()
        {
            var mapGuildChats = db.MapGuildChats.Include(m => m.Chat).Include(m => m.Guild);
            return View(mapGuildChats.ToList());
        }

        // GET: MapGuildChats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapGuildChat mapGuildChat = db.MapGuildChats.Find(id);
            if (mapGuildChat == null)
            {
                return HttpNotFound();
            }
            return View(mapGuildChat);
        }

        // GET: MapGuildChats/Create
        public ActionResult Create()
        {
            ViewBag.ChatId = new SelectList(db.Chats, "ChatId", "TextMessage");
            ViewBag.GuildId = new SelectList(db.Guilds, "GuildId", "Name");
            return View();
        }

        // POST: MapGuildChats/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapGuildChatId,ChatId,GuildId")] MapGuildChat mapGuildChat)
        {
            if (ModelState.IsValid)
            {
                db.MapGuildChats.Add(mapGuildChat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChatId = new SelectList(db.Chats, "ChatId", "TextMessage", mapGuildChat.ChatId);
            ViewBag.GuildId = new SelectList(db.Guilds, "GuildId", "Name", mapGuildChat.GuildId);
            return View(mapGuildChat);
        }

        // GET: MapGuildChats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapGuildChat mapGuildChat = db.MapGuildChats.Find(id);
            if (mapGuildChat == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChatId = new SelectList(db.Chats, "ChatId", "TextMessage", mapGuildChat.ChatId);
            ViewBag.GuildId = new SelectList(db.Guilds, "GuildId", "Name", mapGuildChat.GuildId);
            return View(mapGuildChat);
        }

        // POST: MapGuildChats/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapGuildChatId,ChatId,GuildId")] MapGuildChat mapGuildChat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapGuildChat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChatId = new SelectList(db.Chats, "ChatId", "TextMessage", mapGuildChat.ChatId);
            ViewBag.GuildId = new SelectList(db.Guilds, "GuildId", "Name", mapGuildChat.GuildId);
            return View(mapGuildChat);
        }

        // GET: MapGuildChats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapGuildChat mapGuildChat = db.MapGuildChats.Find(id);
            if (mapGuildChat == null)
            {
                return HttpNotFound();
            }
            return View(mapGuildChat);
        }

        // POST: MapGuildChats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapGuildChat mapGuildChat = db.MapGuildChats.Find(id);
            db.MapGuildChats.Remove(mapGuildChat);
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
