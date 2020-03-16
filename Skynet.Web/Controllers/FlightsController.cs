using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skynet.Data.DataAccessRepositories;
using Skynet.Domain.Models;

namespace Skynet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightRepository _repo;

        public FlightsController(IFlightRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var flight = _repo.Get(id);
            return Ok(flight);
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var flight = _repo.GetAll();
            return Ok(flight);
        }

        [HttpPost()]
        public IActionResult Post(Flight flight)
        {
            _repo.Add(flight);
            return Ok(flight);
        }

        [HttpPut()]
        public IActionResult Update(Flight flight)
        {
            _repo.Update(flight);
            return Ok();
        }


        [HttpDelete()]
        public IActionResult Delete(int id)
        {
            _repo.Remove(id);
            return Ok();
        }
    }
}