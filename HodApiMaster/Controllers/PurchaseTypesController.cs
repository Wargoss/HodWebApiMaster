using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HodApiMaster.Models;

namespace HodApiMaster.Controllers
{
    public class PurchaseTypesController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/PurchaseTypes
        public IQueryable<PurchaseType> GetPurchaseTypes()
        {
            return db.PurchaseTypes;
        }

        // GET: api/PurchaseTypes/5
        [ResponseType(typeof(PurchaseType))]
        public async Task<IHttpActionResult> GetPurchaseType(int id)
        {
            PurchaseType purchaseType = await db.PurchaseTypes.FindAsync(id);
            if (purchaseType == null)
            {
                return NotFound();
            }

            return Ok(purchaseType);
        }

        // PUT: api/PurchaseTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPurchaseType(int id, PurchaseType purchaseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseType.PurchaseTypeId)
            {
                return BadRequest();
            }

            db.Entry(purchaseType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PurchaseTypes
        [ResponseType(typeof(PurchaseType))]
        public async Task<IHttpActionResult> PostPurchaseType(PurchaseType purchaseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseTypes.Add(purchaseType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = purchaseType.PurchaseTypeId }, purchaseType);
        }

        // DELETE: api/PurchaseTypes/5
        [ResponseType(typeof(PurchaseType))]
        public async Task<IHttpActionResult> DeletePurchaseType(int id)
        {
            PurchaseType purchaseType = await db.PurchaseTypes.FindAsync(id);
            if (purchaseType == null)
            {
                return NotFound();
            }

            db.PurchaseTypes.Remove(purchaseType);
            await db.SaveChangesAsync();

            return Ok(purchaseType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseTypeExists(int id)
        {
            return db.PurchaseTypes.Count(e => e.PurchaseTypeId == id) > 0;
        }
    }
}