using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;
using System.Collections.Generic;

namespace Skynet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public AirlinesController(IUnitOfWork db)
        {
            _db = db;
        }

        /// <summary>
        /// Get all airlines from the database
        /// </summary>
        /// <returns>Returns All Airlines</returns>
        [HttpGet]
        public ActionResult<Airline> GetAllAirlines()
        {
            var airlines = _db.Airlines.GetAll();
            return Ok(airlines);
        }


        /// <summary>
        /// Gets an airline from the database
        /// </summary>
        /// <param name="id">Id of the airline</param>
        /// <returns>Airline object with said id</returns>
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Airline> GetAirlineById(int id)
        {
            var airline = _db.Airlines.Get(id);

            if (airline == null)
            {
                return NotFound();
            }

            return Ok(airline);
        }

        /// <summary>
        /// Gets a list of airlines from a specific country
        /// </summary>
        /// <param name="id">The id of the country</param>
        /// <returns>List of airlines from specific country</returns>
        [HttpGet("/Country/{id}")]
        public ActionResult<IEnumerable<Airline>> GetAirlineByCountry(int id)
        {
            var country = _db.Countries.Get(id);
            var airlines = _db.Airlines.GetAirlineByCountry(country);
            return Ok(airlines);
        }

        /// <summary>
        /// Post an airline into the database
        /// </summary>
        /// <param name="airline">json representation of the airline object</param>
        /// <returns>Returns 204</returns>
        [HttpPost]
        public ActionResult<Airline> PostAirline([FromBody] Airline airline)
        {
            _db.Airlines.Add(airline);
            _db.Complete();

            return CreatedAtAction("GetAirlineById", new { id = airline.Id }, airline);
        }


        /// <summary>
        /// Update a specific airline 
        /// </summary>
        /// <param name="id">if of the airline to change</param>
        /// <param name="airline">specify all changes into the object</param>
        [HttpPut("{id}")]
        public ActionResult<Airline> UpdateAirline(int id, [FromBody] Airline airline)
        {
            if (id != airline.Id)
            {
                return BadRequest();
            }

            _db.Airlines.Update(airline);

            try
            {
                _db.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineExists(id, airline))
                {
                    return NotFound(airline);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes an airline from the database
        /// </summary>
        /// <param name="id">Id of the airline to delete</param>
        /// <returns>Returns the deleted airlines for further manupulation</returns>
        [HttpDelete("{id}")]
        public ActionResult<Airline> DeleteAirline(int id)
        {
            var airline = _db.Airlines.Get(id);
            if (airline == null)
            {
                return NotFound(airline);
            }
            _db.Airlines.Remove(airline);
            _db.Complete();
            return airline;

        }

        private bool AirlineExists(int id, Airline airline)
        {
            if (_db.Airlines.Find(a => a.Id.Equals(airline.Id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}
