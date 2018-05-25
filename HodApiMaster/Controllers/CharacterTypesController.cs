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
    [Authorize]
    public class CharacterTypesController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/CharacterTypes
        public IQueryable<CharacterType> GetCharacterTypes()
        {
            return db.CharacterTypes;
        }

        // GET: api/CharacterTypes/5
        [ResponseType(typeof(CharacterType))]
        public async Task<IHttpActionResult> GetCharacterType(int id)
        {
            CharacterType characterType = await db.CharacterTypes.FindAsync(id);
            if (characterType == null)
            {
                return NotFound();
            }

            return Ok(characterType);
        }

        // PUT: api/CharacterTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCharacterType(int id, CharacterType characterType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characterType.CharacterTypeId)
            {
                return BadRequest();
            }

            db.Entry(characterType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterTypeExists(id))
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

        // POST: api/CharacterTypes
        [ResponseType(typeof(CharacterType))]
        public async Task<IHttpActionResult> PostCharacterType(CharacterType characterType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CharacterTypes.Add(characterType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = characterType.CharacterTypeId }, characterType);
        }

        // DELETE: api/CharacterTypes/5
        [ResponseType(typeof(CharacterType))]
        public async Task<IHttpActionResult> DeleteCharacterType(int id)
        {
            CharacterType characterType = await db.CharacterTypes.FindAsync(id);
            if (characterType == null)
            {
                return NotFound();
            }

            db.CharacterTypes.Remove(characterType);
            await db.SaveChangesAsync();

            return Ok(characterType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacterTypeExists(int id)
        {
            return db.CharacterTypes.Count(e => e.CharacterTypeId == id) > 0;
        }
    }
}