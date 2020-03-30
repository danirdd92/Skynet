using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;

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
        public ActionResult<Flight> GetAllFlights()
        {
            var flights = _db.Flights.GetAll();
            return Ok(flights);
        }



        [HttpGet("{id}")]
        public ActionResult<Flight> GetFlightById(int id)
        {
            var flight = _db.Flights.Get(id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }



        [HttpPost]
        public ActionResult<Flight> PostFlight([FromBody] Flight flight)
        {
            _db.Flights.Add(flight);
            _db.Complete();

            return CreatedAtAction("GetFlightById", new { id = flight.Id }, flight);
        }



        [HttpPut("{id}")]
        public ActionResult<Flight> UpdateFlight(int id, [FromBody] Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }

            _db.Flights.Update(flight);

            try
            {
                _db.Complete();
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
        public ActionResult<Flight> DeleteAirline(int id)
        {
            var flight = _db.Flights.Get(id);
            if (flight == null)
            {
                return NotFound(flight);
            }
            _db.Flights.Remove(flight);
            _db.Complete();
            return flight;

        }


        private bool FlightExists(int id, Flight flight)
        {
            if (_db.Flights.Find(a => a.Id.Equals(flight.Id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}