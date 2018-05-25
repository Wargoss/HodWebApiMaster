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
    public class MapPlayerCombatsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/MapPlayerCombats
        public IQueryable<MapPlayerCombat> GetMapPlayerCombats()
        {
            return db.MapPlayerCombats;
        }

        // GET: api/MapPlayerCombats/5
        [ResponseType(typeof(MapPlayerCombat))]
        public async Task<IHttpActionResult> GetMapPlayerCombat(int id)
        {
            MapPlayerCombat mapPlayerCombat = await db.MapPlayerCombats.FindAsync(id);
            if (mapPlayerCombat == null)
            {
                return NotFound();
            }

            return Ok(mapPlayerCombat);
        }

        // PUT: api/MapPlayerCombats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMapPlayerCombat(int id, MapPlayerCombat mapPlayerCombat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapPlayerCombat.MapPlayerCombatId)
            {
                return BadRequest();
            }

            db.Entry(mapPlayerCombat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapPlayerCombatExists(id))
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

        // POST: api/MapPlayerCombats
        [ResponseType(typeof(MapPlayerCombat))]
        public async Task<IHttpActionResult> PostMapPlayerCombat(MapPlayerCombat mapPlayerCombat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MapPlayerCombats.Add(mapPlayerCombat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mapPlayerCombat.MapPlayerCombatId }, mapPlayerCombat);
        }

        // DELETE: api/MapPlayerCombats/5
        [ResponseType(typeof(MapPlayerCombat))]
        public async Task<IHttpActionResult> DeleteMapPlayerCombat(int id)
        {
            MapPlayerCombat mapPlayerCombat = await db.MapPlayerCombats.FindAsync(id);
            if (mapPlayerCombat == null)
            {
                return NotFound();
            }

            db.MapPlayerCombats.Remove(mapPlayerCombat);
            await db.SaveChangesAsync();

            return Ok(mapPlayerCombat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapPlayerCombatExists(int id)
        {
            return db.MapPlayerCombats.Count(e => e.MapPlayerCombatId == id) > 0;
        }
    }
}