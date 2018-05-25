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
    public class MapGuildChatsController : ApiController
    {
        private HodApiMasterContext db = new HodApiMasterContext();

        // GET: api/MapGuildChats
        public IQueryable<MapGuildChat> GetMapGuildChats()
        {
            return db.MapGuildChats;
        }

        // GET: api/MapGuildChats/5
        [ResponseType(typeof(MapGuildChat))]
        public async Task<IHttpActionResult> GetMapGuildChat(int id)
        {
            MapGuildChat mapGuildChat = await db.MapGuildChats.FindAsync(id);
            if (mapGuildChat == null)
            {
                return NotFound();
            }

            return Ok(mapGuildChat);
        }

        // PUT: api/MapGuildChats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMapGuildChat(int id, MapGuildChat mapGuildChat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapGuildChat.MapGuildChatId)
            {
                return BadRequest();
            }

            db.Entry(mapGuildChat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapGuildChatExists(id))
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

        // POST: api/MapGuildChats
        [ResponseType(typeof(MapGuildChat))]
        public async Task<IHttpActionResult> PostMapGuildChat(MapGuildChat mapGuildChat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MapGuildChats.Add(mapGuildChat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mapGuildChat.MapGuildChatId }, mapGuildChat);
        }

        // DELETE: api/MapGuildChats/5
        [ResponseType(typeof(MapGuildChat))]
        public async Task<IHttpActionResult> DeleteMapGuildChat(int id)
        {
            MapGuildChat mapGuildChat = await db.MapGuildChats.FindAsync(id);
            if (mapGuildChat == null)
            {
                return NotFound();
            }

            db.MapGuildChats.Remove(mapGuildChat);
            await db.SaveChangesAsync();

            return Ok(mapGuildChat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MapGuildChatExists(int id)
        {
            return db.MapGuildChats.Count(e => e.MapGuildChatId == id) > 0;
        }
    }
}