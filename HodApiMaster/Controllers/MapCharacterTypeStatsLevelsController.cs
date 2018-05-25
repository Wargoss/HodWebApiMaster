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
    public class MapCharacterTypeStatsLevelsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/MapCharacterTypeStatsLevels
        public IQueryable<MapCharacterTypeStatsLevel> GetMapCharacterTypeStatsLevels()
        {
            return db.MapCharacterTypeStatsLevels;
        }

        // GET: api/MapCharacterTypeStatsLevels/5
        [ResponseType(typeof(MapCharacterTypeStatsLevel))]
        public async Task<IHttpActionResult> GetMapCharacterTypeStatsLevel(int id)
        {
            MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel = await db.MapCharacterTypeStatsLevels.FindAsync(id);
            if (mapCharacterTypeStatsLevel == null)
            {
                return NotFound();
            }

            return Ok(mapCharacterTypeStatsLevel);
        }

        // PUT: api/MapCharacterTypeStatsLevels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMapCharacterTypeStatsLevel(int id, MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapCharacterTypeStatsLevel.MapCharacterTypeStatsLevelId)
            {
                return BadRequest();
            }

            db.Entry(mapCharacterTypeStatsLevel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapCharacterTypeStatsLevelExists(id))
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

        // POST: api/MapCharacterTypeStatsLevels
        [ResponseType(typeof(MapCharacterTypeStatsLevel))]
        public async Task<IHttpActionResult> PostMapCharacterTypeStatsLevel(MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MapCharacterTypeStatsLevels.Add(mapCharacterTypeStatsLevel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mapCharacterTypeStatsLevel.MapCharacterTypeStatsLevelId }, mapCharacterTypeStatsLevel);
        }

        // DELETE: api/MapCharacterTypeStatsLevels/5
        [ResponseType(typeof(MapCharacterTypeStatsLevel))]
        public async Task<IHttpActionResult> DeleteMapCharacterTypeStatsLevel(int id)
        {
            MapCharacterTypeStatsLevel mapCharacterTypeStatsLevel = await db.MapCharacterTypeStatsLevels.FindAsync(id);
            if (mapCharacterTypeStatsLevel == null)
            {
                return NotFound();
            }

            db.MapCharacterTypeStatsLevels.Remove(mapCharacterTypeStatsLevel);
            await db.SaveChangesAsync();

            return Ok(mapCharacterTypeStatsLevel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapCharacterTypeStatsLevelExists(int id)
        {
            return db.MapCharacterTypeStatsLevels.Count(e => e.MapCharacterTypeStatsLevelId == id) > 0;
        }
    }
}