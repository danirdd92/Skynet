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



        [HttpGet]
        public ActionResult<Airline> GetAllAirlines()
        {
            var airlines = _db.Airlines.GetAll();
            return Ok(airlines);
        }



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



        [HttpPost]
        public ActionResult<Airline> PostAirline([FromBody] Airline airline)
        {
            _db.Airlines.Add(airline);
            _db.Complete();

            return CreatedAtAction("GetAirlineById", new { id = airline.Id }, airline);
        }



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


        [HttpGet("/Country/{id}")]
        public ActionResult<IEnumerable<Airline>> GetAirlineByCountry(int id)
        {
            var country = _db.Countries.Get(id);
            var airlines = _db.Airlines.GetAirlineByCountry(country);
            return Ok(airlines);
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
