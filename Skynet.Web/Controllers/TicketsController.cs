using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skynet.Data;
using Skynet.Domain.Models;

namespace Skynet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _repo;

        public TicketsController(ITicketRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var ticket = _repo.Get(id);
            return Ok(ticket);
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var tickets = _repo.GetAll();
            return Ok(tickets);
        }

        [HttpPost()]
        public IActionResult Post(Ticket ticket)
        {
            _repo.Add(ticket);
            return Ok(ticket);
        }

        [HttpPut()]
        public IActionResult Update(Ticket ticket)
        {
            _repo.Update(ticket);
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