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
using System.Web.Http.Cors;
using System.Security.Claims;

namespace MyServer.Controllers
{
    public class UsersController : ApiController
    {
        private travelstartEntities db = new travelstartEntities();

        // GET: api/Users
        [AllowAnonymous]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        [Authorize]
        public User GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            User model = new User()
            {
           UserId = Convert.ToInt32(identityClaims.FindFirst("UserId").Value),
             UserName =  identityClaims.FindFirst("UserName").Value,
           Email = identityClaims.FindFirst("Email").Value,
           Password = identityClaims.FindFirst("Password").Value,
            FirstName = identityClaims.FindFirst("FirstName").Value,
           LastName = identityClaims.FindFirst("LastName").Value,
              card_no = identityClaims.FindFirst("card_no").Value,
                account_no = identityClaims.FindFirst("account_no").Value
            };
            return model;
        }

        // PUT: api/Users/5
        [AllowAnonymous]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [AllowAnonymous]
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
          /* if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/{id}
        [AllowAnonymous]
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}