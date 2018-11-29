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
    public class EmployesController : ApiController
    {
        private travelstartEntities4 db = new travelstartEntities4();

        // GET: api/Employes
        public IQueryable<Employe> GetEmployes()
        {
            return db.Employes;
        }

        // GET: api/Employes/5
        [ResponseType(typeof(Employe))]
        public IHttpActionResult GetEmploye(int id)
        {
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            return Ok(employe);
        }



        [ResponseType(typeof(Employe))]
        public IQueryable<Employe> GetEmployee(string Lname)
        {
            /////var employe = db.Employes.Where(x => x.Lname == Lname && x.Fname == Fname);
           var employe = db.Employes.Where(x => x.Lname == Lname);
            //Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return null;
            }
            

            return employe;
        }


        [AllowAnonymous]
        // PUT: api/Employes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(Employe employe)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new travelstartEntities4())
            {
                var existingStudent = ctx.Employes.Where(s => s.ID == employe.ID).FirstOrDefault<Employe>();

                if (existingStudent != null)
                {
                    existingStudent.Fname = employe.Fname;
                    existingStudent.Lname = employe.Lname;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }





        //    if (id != employe.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(employe).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        [AllowAnonymous]
        // POST: api/Employes
        [ResponseType(typeof(Employe))]
        public IHttpActionResult PostEmploye(Employe employe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employes.Add(employe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employe.ID }, employe);
        }

        // DELETE: api/Employes/5
        [ResponseType(typeof(Employe))]
        public IHttpActionResult DeleteEmploye(int id)
        {
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            db.Employes.Remove(employe);
            db.SaveChanges();

            return Ok(employe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeExists(int id)
        {
            return db.Employes.Count(e => e.ID == id) > 0;
        }
    }
}