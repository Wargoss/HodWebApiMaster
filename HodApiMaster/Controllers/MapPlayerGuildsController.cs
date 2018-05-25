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
    public class MapPlayerGuildsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/MapPlayerGuilds
        public IQueryable<MapPlayerGuild> GetMapPlayerGuilds()
        {
            return db.MapPlayerGuilds;
        }

        // GET: api/MapPlayerGuilds/5
        [ResponseType(typeof(MapPlayerGuild))]
        public async Task<IHttpActionResult> GetMapPlayerGuild(int id)
        {
            MapPlayerGuild mapPlayerGuild = await db.MapPlayerGuilds.FindAsync(id);
            if (mapPlayerGuild == null)
            {
                return NotFound();
            }

            return Ok(mapPlayerGuild);
        }

        // PUT: api/MapPlayerGuilds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMapPlayerGuild(int id, MapPlayerGuild mapPlayerGuild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapPlayerGuild.MapPlayerGuildId)
            {
                return BadRequest();
            }

            db.Entry(mapPlayerGuild).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapPlayerGuildExists(id))
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

        // POST: api/MapPlayerGuilds
        [ResponseType(typeof(MapPlayerGuild))]
        public async Task<IHttpActionResult> PostMapPlayerGuild(MapPlayerGuild mapPlayerGuild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MapPlayerGuilds.Add(mapPlayerGuild);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mapPlayerGuild.MapPlayerGuildId }, mapPlayerGuild);
        }

        // DELETE: api/MapPlayerGuilds/5
        [ResponseType(typeof(MapPlayerGuild))]
        public async Task<IHttpActionResult> DeleteMapPlayerGuild(int id)
        {
            MapPlayerGuild mapPlayerGuild = await db.MapPlayerGuilds.FindAsync(id);
            if (mapPlayerGuild == null)
            {
                return NotFound();
            }

            db.MapPlayerGuilds.Remove(mapPlayerGuild);
            await db.SaveChangesAsync();

            return Ok(mapPlayerGuild);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapPlayerGuildExists(int id)
        {
            return db.MapPlayerGuilds.Count(e => e.MapPlayerGuildId == id) > 0;
        }
    }
}