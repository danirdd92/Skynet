using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;
using System.Threading.Tasks;

namespace Skynet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public FlightsController(IUnitOfWork db)
        {
            _db = db;
        }



        [HttpGet]
        public async Task<ActionResult<Flight>> GetAllFlights()
        {
            var flights = await _db.Flights.GetAllAsync();
            return Ok(flights);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlightById(int id)
        {
            var flight = await _db.Flights.GetAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }



        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight([FromBody] Flight flight)
        {
            await _db.Flights.AddAsync(flight);
            await _db.CompleteAsync();

            return CreatedAtAction("GetFlightById", new { id = flight.Id }, flight);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Flight>> UpdateFlight(int id, [FromBody] Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }

            await _db.Flights.UpdateAsync(flight);

            try
            {
                await _db.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id, flight))
                {
                    return NotFound(flight);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Flight>> DeleteAirline(int id)
        {
            var flight = await _db.Flights.GetAsync(id);
            if (flight == null)
            {
                return NotFound(flight);
            }
            await _db.Flights.RemoveAsync(flight);
            await _db.CompleteAsync();
            return flight;

        }


        private bool FlightExists(int id, Flight flight)
        {
            if (_db.Flights.FindAsync(a => a.Id.Equals(flight.Id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}