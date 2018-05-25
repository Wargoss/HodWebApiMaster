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
    public class MapPlayerCharactersController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/MapPlayerCharacters
        public IQueryable<MapPlayerCharacter> GetMapPlayerCharacters()
        {
            return db.MapPlayerCharacters;
        }

        // GET: api/MapPlayerCharacters/5
        [ResponseType(typeof(MapPlayerCharacter))]
        public async Task<IHttpActionResult> GetMapPlayerCharacter(int id)
        {
            MapPlayerCharacter mapPlayerCharacter = await db.MapPlayerCharacters.FindAsync(id);
            if (mapPlayerCharacter == null)
            {
                return NotFound();
            }

            return Ok(mapPlayerCharacter);
        }

        // PUT: api/MapPlayerCharacters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMapPlayerCharacter(int id, MapPlayerCharacter mapPlayerCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapPlayerCharacter.MapPlayerCharacterId)
            {
                return BadRequest();
            }

            db.Entry(mapPlayerCharacter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapPlayerCharacterExists(id))
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

        // POST: api/MapPlayerCharacters
        [ResponseType(typeof(MapPlayerCharacter))]
        public async Task<IHttpActionResult> PostMapPlayerCharacter(MapPlayerCharacter mapPlayerCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MapPlayerCharacters.Add(mapPlayerCharacter);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mapPlayerCharacter.MapPlayerCharacterId }, mapPlayerCharacter);
        }

        // DELETE: api/MapPlayerCharacters/5
        [ResponseType(typeof(MapPlayerCharacter))]
        public async Task<IHttpActionResult> DeleteMapPlayerCharacter(int id)
        {
            MapPlayerCharacter mapPlayerCharacter = await db.MapPlayerCharacters.FindAsync(id);
            if (mapPlayerCharacter == null)
            {
                return NotFound();
            }

            db.MapPlayerCharacters.Remove(mapPlayerCharacter);
            await db.SaveChangesAsync();

            return Ok(mapPlayerCharacter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapPlayerCharacterExists(int id)
        {
            return db.MapPlayerCharacters.Count(e => e.MapPlayerCharacterId == id) > 0;
        }
    }
}