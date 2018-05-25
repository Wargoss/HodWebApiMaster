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
    public class MapPlayerPurchasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MapPlayerPurchases
        public ActionResult Index()
        {
            var mapPlayerPurchases = db.MapPlayerPurchases.Include(m => m.Player).Include(m => m.Purchase);
            return View(mapPlayerPurchases.ToList());
        }

        // GET: MapPlayerPurchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerPurchase mapPlayerPurchase = db.MapPlayerPurchases.Find(id);
            if (mapPlayerPurchase == null)
            {
                return HttpNotFound();
            }
            return View(mapPlayerPurchase);
        }

        // GET: MapPlayerPurchases/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name");
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseId", "PurchaseId");
            return View();
        }

        // POST: MapPlayerPurchases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapPlayerPurchaseId,PlayerId,PurchaseId")] MapPlayerPurchase mapPlayerPurchase)
        {
            if (ModelState.IsValid)
            {
                db.MapPlayerPurchases.Add(mapPlayerPurchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerPurchase.PlayerId);
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseId", "PurchaseId", mapPlayerPurchase.PurchaseId);
            return View(mapPlayerPurchase);
        }

        // GET: MapPlayerPurchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerPurchase mapPlayerPurchase = db.MapPlayerPurchases.Find(id);
            if (mapPlayerPurchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerPurchase.PlayerId);
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseId", "PurchaseId", mapPlayerPurchase.PurchaseId);
            return View(mapPlayerPurchase);
        }

        // POST: MapPlayerPurchases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapPlayerPurchaseId,PlayerId,PurchaseId")] MapPlayerPurchase mapPlayerPurchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapPlayerPurchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "Name", mapPlayerPurchase.PlayerId);
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseId", "PurchaseId", mapPlayerPurchase.PurchaseId);
            return View(mapPlayerPurchase);
        }

        // GET: MapPlayerPurchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPlayerPurchase mapPlayerPurchase = db.MapPlayerPurchases.Find(id);
            if (mapPlayerPurchase == null)
            {
                return HttpNotFound();
            }
            return View(mapPlayerPurchase);
        }

        // POST: MapPlayerPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapPlayerPurchase mapPlayerPurchase = db.MapPlayerPurchases.Find(id);
            db.MapPlayerPurchases.Remove(mapPlayerPurchase);
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
