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
    public class TurnsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/Turns
        public IQueryable<Turn> GetTurns()
        {
            return db.Turns;
        }

        // GET: api/Turns/5
        [ResponseType(typeof(Turn))]
        public async Task<IHttpActionResult> GetTurn(int id)
        {
            Turn turn = await db.Turns.FindAsync(id);
            if (turn == null)
            {
                return NotFound();
            }

            return Ok(turn);
        }

        // PUT: api/Turns/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTurn(int id, Turn turn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turn.TurnId)
            {
                return BadRequest();
            }

            db.Entry(turn).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnExists(id))
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

        // POST: api/Turns
        [ResponseType(typeof(Turn))]
        public async Task<IHttpActionResult> PostTurn(Turn turn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Turns.Add(turn);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = turn.TurnId }, turn);
        }

        // DELETE: api/Turns/5
        [ResponseType(typeof(Turn))]
        public async Task<IHttpActionResult> DeleteTurn(int id)
        {
            Turn turn = await db.Turns.FindAsync(id);
            if (turn == null)
            {
                return NotFound();
            }

            db.Turns.Remove(turn);
            await db.SaveChangesAsync();

            return Ok(turn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurnExists(int id)
        {
            return db.Turns.Count(e => e.TurnId == id) > 0;
        }
    }
}