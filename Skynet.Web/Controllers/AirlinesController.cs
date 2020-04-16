using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<Airline>> GetAllAirlines()
        {
            var airlines = await _db.Airlines.GetAllAsync();
            return Ok(airlines);
        }


        /// <summary>
        /// Gets an airline from the database
        /// </summary>
        /// <param name="id">Id of the airline</param>
        /// <returns>Airline object with said id</returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Airline>> GetAirlineById(int id)
        {
            var airline = await _db.Airlines.GetAsync(id);

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
        public async Task<ActionResult<IEnumerable<Airline>>> GetAirlineByCountry(int id)
        {
            var country = await _db.Countries.GetAsync(id);
            var airlines = await _db.Airlines.GetAirlineByCountryAsync(country);
            return Ok(airlines);
        }

        /// <summary>
        /// Post an airline into the database
        /// </summary>
        /// <param name="airline">json representation of the airline object</param>
        /// <returns>Returns 204</returns>
        [HttpPost]
        public async Task<ActionResult<Airline>> PostAirline([FromBody] Airline airline)
        {
            await _db.Airlines.AddAsync(airline);
            await _db.CompleteAsync();

            return CreatedAtAction("GetAirlineById", new { id = airline.Id }, airline);
        }


        /// <summary>
        /// Update a specific airline 
        /// </summary>
        /// <param name="id">if of the airline to change</param>
        /// <param name="airline">specify all changes into the object</param>
        [HttpPut("{id}")]
        public async Task<ActionResult<Airline>> UpdateAirline(int id, [FromBody] Airline airline)
        {
            if (id != airline.Id)
            {
                return BadRequest();
            }

            await _db.Airlines.UpdateAsync(airline);

            try
            {
                await _db.CompleteAsync();
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
        public async Task<ActionResult<Airline>> DeleteAirline(int id)
        {
            var airline = await _db.Airlines.GetAsync(id);
            if (airline == null)
            {
                return NotFound(airline);
            }
            await _db.Airlines.RemoveAsync(airline);
            await _db.CompleteAsync();
            return airline;

        }

        private bool AirlineExists(int id, Airline airline)
        {
            if (_db.Airlines.FindAsync(a => a.Id.Equals(airline.Id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}
