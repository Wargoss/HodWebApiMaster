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
    public class MapCharacterTypeSkillsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/MapCharacterTypeSkills
        public IQueryable<MapCharacterTypeSkill> GetMapCharacterTypeSkills()
        {
            return db.MapCharacterTypeSkills;
        }

        // GET: api/MapCharacterTypeSkills/5
        [ResponseType(typeof(MapCharacterTypeSkill))]
        public async Task<IHttpActionResult> GetMapCharacterTypeSkill(int id)
        {
            MapCharacterTypeSkill mapCharacterTypeSkill = await db.MapCharacterTypeSkills.FindAsync(id);
            if (mapCharacterTypeSkill == null)
            {
                return NotFound();
            }

            return Ok(mapCharacterTypeSkill);
        }

        // PUT: api/MapCharacterTypeSkills/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMapCharacterTypeSkill(int id, MapCharacterTypeSkill mapCharacterTypeSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapCharacterTypeSkill.MapCharacterTypeSkillId)
            {
                return BadRequest();
            }

            db.Entry(mapCharacterTypeSkill).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapCharacterTypeSkillExists(id))
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

        // POST: api/MapCharacterTypeSkills
        [ResponseType(typeof(MapCharacterTypeSkill))]
        public async Task<IHttpActionResult> PostMapCharacterTypeSkill(MapCharacterTypeSkill mapCharacterTypeSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MapCharacterTypeSkills.Add(mapCharacterTypeSkill);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mapCharacterTypeSkill.MapCharacterTypeSkillId }, mapCharacterTypeSkill);
        }

        // DELETE: api/MapCharacterTypeSkills/5
        [ResponseType(typeof(MapCharacterTypeSkill))]
        public async Task<IHttpActionResult> DeleteMapCharacterTypeSkill(int id)
        {
            MapCharacterTypeSkill mapCharacterTypeSkill = await db.MapCharacterTypeSkills.FindAsync(id);
            if (mapCharacterTypeSkill == null)
            {
                return NotFound();
            }

            db.MapCharacterTypeSkills.Remove(mapCharacterTypeSkill);
            await db.SaveChangesAsync();

            return Ok(mapCharacterTypeSkill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapCharacterTypeSkillExists(int id)
        {
            return db.MapCharacterTypeSkills.Count(e => e.MapCharacterTypeSkillId == id) > 0;
        }
    }
}