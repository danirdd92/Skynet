using Microsoft.AspNetCore.Mvc;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;
using System.Collections.Generic;

namespace Skynet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly IUnitOfWork _unit;

        public AirlinesController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET: api/Airlines
        [HttpGet]
        public ActionResult<Airline> Get()
        {
            var airlines = _unit.Airlines.GetAll();
            return Ok(airlines);
        }

        // GET: api/Airlines/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Airlines
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Airlines/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Airlines/5
        [HttpDelete("{id}")]
        public ActionResult<Airline> DeleteAirline(int id)
        {
            var airline = _unit.Airlines.Get(id);
            if (airline == null)
            {
                return NotFound(airline);
            }
            _unit.Airlines.Remove(airline);
            _unit.Complete();
            return airline;

        }

        [HttpGet("/{country}")]
        public ActionResult<IEnumerable<Airline>> GetAirlineByCountry([FromRoute] Country country)
        {
            var airlines = _unit.Airlines.GetAirlineByCountry(country);
            return Ok(airlines);
        }
    }
}
