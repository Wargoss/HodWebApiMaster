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
    public class PurchaseTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PurchaseTypes
        public ActionResult Index()
        {
            return View(db.PurchaseTypes.ToList());
        }

        // GET: PurchaseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseType purchaseType = db.PurchaseTypes.Find(id);
            if (purchaseType == null)
            {
                return HttpNotFound();
            }
            return View(purchaseType);
        }

        // GET: PurchaseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseTypeId,Gems,SubscriptionId,Name,Price")] PurchaseType purchaseType)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseTypes.Add(purchaseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseType);
        }

        // GET: PurchaseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseType purchaseType = db.PurchaseTypes.Find(id);
            if (purchaseType == null)
            {
                return HttpNotFound();
            }
            return View(purchaseType);
        }

        // POST: PurchaseTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseTypeId,Gems,SubscriptionId,Name,Price")] PurchaseType purchaseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseType);
        }

        // GET: PurchaseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseType purchaseType = db.PurchaseTypes.Find(id);
            if (purchaseType == null)
            {
                return HttpNotFound();
            }
            return View(purchaseType);
        }

        // POST: PurchaseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseType purchaseType = db.PurchaseTypes.Find(id);
            db.PurchaseTypes.Remove(purchaseType);
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
