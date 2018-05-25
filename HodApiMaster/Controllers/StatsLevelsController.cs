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
    public class StatsLevelsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/StatsLevels
        public IQueryable<StatsLevel> GetStatsLevels()
        {
            return db.StatsLevels;
        }

        // GET: api/StatsLevels/5
        [ResponseType(typeof(StatsLevel))]
        public async Task<IHttpActionResult> GetStatsLevel(int id)
        {
            StatsLevel statsLevel = await db.StatsLevels.FindAsync(id);
            if (statsLevel == null)
            {
                return NotFound();
            }

            return Ok(statsLevel);
        }

        // PUT: api/StatsLevels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStatsLevel(int id, StatsLevel statsLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statsLevel.StatsLevelId)
            {
                return BadRequest();
            }

            db.Entry(statsLevel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatsLevelExists(id))
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

        // POST: api/StatsLevels
        [ResponseType(typeof(StatsLevel))]
        public async Task<IHttpActionResult> PostStatsLevel(StatsLevel statsLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatsLevels.Add(statsLevel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = statsLevel.StatsLevelId }, statsLevel);
        }

        // DELETE: api/StatsLevels/5
        [ResponseType(typeof(StatsLevel))]
        public async Task<IHttpActionResult> DeleteStatsLevel(int id)
        {
            StatsLevel statsLevel = await db.StatsLevels.FindAsync(id);
            if (statsLevel == null)
            {
                return NotFound();
            }

            db.StatsLevels.Remove(statsLevel);
            await db.SaveChangesAsync();

            return Ok(statsLevel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatsLevelExists(int id)
        {
            return db.StatsLevels.Count(e => e.StatsLevelId == id) > 0;
        }
    }
}