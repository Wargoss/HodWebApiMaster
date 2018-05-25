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
    public class CombatsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/Combats
        public IQueryable<Combat> GetCombats()
        {
            return db.Combats;
        }

        // GET: api/Combats/5
        [ResponseType(typeof(Combat))]
        public async Task<IHttpActionResult> GetCombat(int id)
        {
            Combat combat = await db.Combats.FindAsync(id);
            if (combat == null)
            {
                return NotFound();
            }

            return Ok(combat);
        }

        // PUT: api/Combats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCombat(int id, Combat combat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != combat.CombatId)
            {
                return BadRequest();
            }

            db.Entry(combat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CombatExists(id))
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

        // POST: api/Combats
        [ResponseType(typeof(Combat))]
        public async Task<IHttpActionResult> PostCombat(Combat combat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Combats.Add(combat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = combat.CombatId }, combat);
        }

        // DELETE: api/Combats/5
        [ResponseType(typeof(Combat))]
        public async Task<IHttpActionResult> DeleteCombat(int id)
        {
            Combat combat = await db.Combats.FindAsync(id);
            if (combat == null)
            {
                return NotFound();
            }

            db.Combats.Remove(combat);
            await db.SaveChangesAsync();

            return Ok(combat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CombatExists(int id)
        {
            return db.Combats.Count(e => e.CombatId == id) > 0;
        }
    }
}