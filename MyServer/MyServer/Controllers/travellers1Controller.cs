using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyServer.Models;

namespace MyServer.Controllers
{
    public class travellers1Controller : ApiController
    {
        private travelstartEntities db = new travelstartEntities();

        // GET: api/travellers1
        public IQueryable<traveller> Gettravellers()
        {
            return db.travellers;
        }

        // GET: api/travellers1/5
        [ResponseType(typeof(traveller))]
        public IHttpActionResult Gettraveller(int id)
        {
            traveller traveller = db.travellers.Find(id);
            if (traveller == null)
            {
                return NotFound();
            }

            return Ok(traveller);
        }

        // PUT: api/travellers1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttraveller(int id, traveller traveller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != traveller.traveller_id)
            {
                return BadRequest();
            }

            db.Entry(traveller).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!travellerExists(id))
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
        [AllowAnonymous]
        // POST: api/travellers1
        [ResponseType(typeof(traveller))]
        public IHttpActionResult Posttraveller(traveller traveller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.travellers.Add(traveller);
            db.SaveChanges();


            return CreatedAtRoute("DefaultApi", new { id = traveller.traveller_id }, traveller);
        }

        // DELETE: api/travellers1/5
        [ResponseType(typeof(traveller))]
        public IHttpActionResult Deletetraveller(int id)
        {
            traveller traveller = db.travellers.Find(id);
            if (traveller == null)
            {
                return NotFound();
            }

            db.travellers.Remove(traveller);
            db.SaveChanges();

            return Ok(traveller);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool travellerExists(int id)
        {
            return db.travellers.Count(e => e.traveller_id == id) > 0;
        }
    }
}