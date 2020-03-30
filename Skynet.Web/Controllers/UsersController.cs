using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;

namespace Skynet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public UsersController(IUnitOfWork db)
        {
            _db = db;
        }



        [HttpGet]
        public ActionResult<User> GetAllUsers()
        {
            var users = _db.Users.GetAll();
            return Ok(users);
        }



        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _db.Users.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }



        [HttpPost]
        public ActionResult<User> PostUser([FromBody] User user)
        {
            _db.Users.Add(user);
            _db.Complete();

            return CreatedAtAction("GetUserById", new { id = user.Id }, user);
        }



        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _db.Users.Update(user);

            try
            {
                _db.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id, user))
                {
                    return NotFound(user);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var user = _db.Users.Get(id);
            if (user == null)
            {
                return NotFound(user);
            }
            _db.Users.Remove(user);
            _db.Complete();
            return user;

        }


        private bool UserExists(int id, User user)
        {
            if (_db.Users.Find(a => a.Id.Equals(user.Id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}