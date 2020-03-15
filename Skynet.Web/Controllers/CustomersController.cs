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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repo;

        public CustomersController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var customer = _repo.Get(id);
            return Ok(customer);
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var customer = _repo.GetAll();
            return Ok(customer);
        }

        [HttpPost()]
        public IActionResult Post(Customer customer)
        {
            _repo.Add(customer);
            return Ok(customer);
        }

        [HttpPut()]
        public IActionResult Update(Customer customer)
        {
            _repo.Update(customer);
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