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
    public class paymentsController : ApiController
    {
        private travelstartEntities db = new travelstartEntities();

        // GET: api/payments
        public IQueryable<payment> Getpayments()
        {
            return db.payments;
        }

   

        // GET: api/payments/5
        [ResponseType(typeof(payment))]
        public IHttpActionResult Getpayment(int users_user_id)
        {
            var payment = db.payments.Where(x => x.users_user_id == users_user_id);
            if (payment == null)
            {
                return null;
            }

            return Ok(payment);
        }

        // PUT: api/payments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpayment(int id, payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment.payment_id)
            {
                return BadRequest();
            }

            db.Entry(payment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paymentExists(id))
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
        // POST: api/Employes
        [ResponseType(typeof(payment))]
        public IHttpActionResult PostEmploye(payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.payments.Add(payment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = payment.payment_id }, payment);
        }


    

        // DELETE: api/payments/5
        [ResponseType(typeof(payment))]
        public IHttpActionResult Deletepayment(int id)
        {
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            db.payments.Remove(payment);
            db.SaveChanges();

            return Ok(payment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool paymentExists(int id)
        {
            return db.payments.Count(e => e.payment_id == id) > 0;
        }
    }
}