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
    public class MapCombatTurnsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/MapCombatTurns
        public IQueryable<MapCombatTurn> GetMapCombatTurns()
        {
            return db.MapCombatTurns;
        }

        // GET: api/MapCombatTurns/5
        [ResponseType(typeof(MapCombatTurn))]
        public async Task<IHttpActionResult> GetMapCombatTurn(int id)
        {
            MapCombatTurn mapCombatTurn = await db.MapCombatTurns.FindAsync(id);
            if (mapCombatTurn == null)
            {
                return NotFound();
            }

            return Ok(mapCombatTurn);
        }

        // PUT: api/MapCombatTurns/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMapCombatTurn(int id, MapCombatTurn mapCombatTurn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapCombatTurn.MapCombatTurnId)
            {
                return BadRequest();
            }

            db.Entry(mapCombatTurn).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapCombatTurnExists(id))
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

        // POST: api/MapCombatTurns
        [ResponseType(typeof(MapCombatTurn))]
        public async Task<IHttpActionResult> PostMapCombatTurn(MapCombatTurn mapCombatTurn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MapCombatTurns.Add(mapCombatTurn);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mapCombatTurn.MapCombatTurnId }, mapCombatTurn);
        }

        // DELETE: api/MapCombatTurns/5
        [ResponseType(typeof(MapCombatTurn))]
        public async Task<IHttpActionResult> DeleteMapCombatTurn(int id)
        {
            MapCombatTurn mapCombatTurn = await db.MapCombatTurns.FindAsync(id);
            if (mapCombatTurn == null)
            {
                return NotFound();
            }

            db.MapCombatTurns.Remove(mapCombatTurn);
            await db.SaveChangesAsync();

            return Ok(mapCombatTurn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapCombatTurnExists(int id)
        {
            return db.MapCombatTurns.Count(e => e.MapCombatTurnId == id) > 0;
        }
    }
}