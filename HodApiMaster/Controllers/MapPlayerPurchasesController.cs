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
    public class MapPlayerPurchasesController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/MapPlayerPurchases
        public IQueryable<MapPlayerPurchase> GetMapPlayerPurchases()
        {
            return db.MapPlayerPurchases;
        }

        // GET: api/MapPlayerPurchases/5
        [ResponseType(typeof(MapPlayerPurchase))]
        public async Task<IHttpActionResult> GetMapPlayerPurchase(int id)
        {
            MapPlayerPurchase mapPlayerPurchase = await db.MapPlayerPurchases.FindAsync(id);
            if (mapPlayerPurchase == null)
            {
                return NotFound();
            }

            return Ok(mapPlayerPurchase);
        }

        // PUT: api/MapPlayerPurchases/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMapPlayerPurchase(int id, MapPlayerPurchase mapPlayerPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapPlayerPurchase.MapPlayerPurchaseId)
            {
                return BadRequest();
            }

            db.Entry(mapPlayerPurchase).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapPlayerPurchaseExists(id))
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

        // POST: api/MapPlayerPurchases
        [ResponseType(typeof(MapPlayerPurchase))]
        public async Task<IHttpActionResult> PostMapPlayerPurchase(MapPlayerPurchase mapPlayerPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MapPlayerPurchases.Add(mapPlayerPurchase);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mapPlayerPurchase.MapPlayerPurchaseId }, mapPlayerPurchase);
        }

        // DELETE: api/MapPlayerPurchases/5
        [ResponseType(typeof(MapPlayerPurchase))]
        public async Task<IHttpActionResult> DeleteMapPlayerPurchase(int id)
        {
            MapPlayerPurchase mapPlayerPurchase = await db.MapPlayerPurchases.FindAsync(id);
            if (mapPlayerPurchase == null)
            {
                return NotFound();
            }

            db.MapPlayerPurchases.Remove(mapPlayerPurchase);
            await db.SaveChangesAsync();

            return Ok(mapPlayerPurchase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapPlayerPurchaseExists(int id)
        {
            return db.MapPlayerPurchases.Count(e => e.MapPlayerPurchaseId == id) > 0;
        }
    }
}