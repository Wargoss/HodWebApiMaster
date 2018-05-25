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
    public class GuildsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/Guilds
        public IQueryable<Guild> GetGuilds()
        {
            return db.Guilds;
        }

        // GET: api/Guilds/5
        [ResponseType(typeof(Guild))]
        public async Task<IHttpActionResult> GetGuild(int id)
        {
            Guild guild = await db.Guilds.FindAsync(id);
            if (guild == null)
            {
                return NotFound();
            }

            return Ok(guild);
        }

        // PUT: api/Guilds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGuild(int id, Guild guild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guild.GuildId)
            {
                return BadRequest();
            }

            db.Entry(guild).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuildExists(id))
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

        // POST: api/Guilds
        [ResponseType(typeof(Guild))]
        public async Task<IHttpActionResult> PostGuild(Guild guild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guilds.Add(guild);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = guild.GuildId }, guild);
        }

        // DELETE: api/Guilds/5
        [ResponseType(typeof(Guild))]
        public async Task<IHttpActionResult> DeleteGuild(int id)
        {
            Guild guild = await db.Guilds.FindAsync(id);
            if (guild == null)
            {
                return NotFound();
            }

            db.Guilds.Remove(guild);
            await db.SaveChangesAsync();

            return Ok(guild);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuildExists(int id)
        {
            return db.Guilds.Count(e => e.GuildId == id) > 0;
        }
    }
}