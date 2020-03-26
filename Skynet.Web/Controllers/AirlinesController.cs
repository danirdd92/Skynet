using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
    }
}
