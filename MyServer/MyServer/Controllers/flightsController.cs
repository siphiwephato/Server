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
    public class flightsController : ApiController
    {
        private travelstartEntities db = new travelstartEntities();

        // GET: api/flights
        [AllowAnonymous]
        public IQueryable<flight> Getflights()
        {
            return db.flights;
        }




        // GET: api/flights/5
        [AllowAnonymous]
        [ResponseType(typeof(flight))]
        public IHttpActionResult Getflight(string from_Location)
        {
            var flight = db.flights.Where(x => x.from_Location == from_Location);
          
            if (flight == null)
            {
                return null;
            }

            return Ok(flight);
        }

        // PUT: api/flights/5
        [AllowAnonymous]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putflight(int id, flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flight.flights_Id)
            {
                return BadRequest();
            }

            db.Entry(flight).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!flightExists(id))
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

        // POST: api/flights
        [AllowAnonymous]
        [ResponseType(typeof(flight))]
        public IHttpActionResult Postflight(flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.flights.Add(flight);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flight.flights_Id }, flight);
        }

        // DELETE: api/flights/5
        [AllowAnonymous]
        [ResponseType(typeof(flight))]
        public IHttpActionResult Deleteflight(int id)
        {
            flight flight = db.flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }

            db.flights.Remove(flight);
            db.SaveChanges();

            return Ok(flight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool flightExists(int id)
        {
            return db.flights.Count(e => e.flights_Id == id) > 0;
        }
    }
}