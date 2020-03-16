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
    public class AirlineCompaniesController : ControllerBase
    {
        private readonly IAirlineCompanyRepository _repo;

        public AirlineCompaniesController(IAirlineCompanyRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var airline = _repo.Get(id);
            return Ok(airline);
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var airline = _repo.GetAll();
            return Ok(airline);
        }

        [HttpPost()]
        public IActionResult Post(AirlineCompany airline)
        {
            _repo.Add(airline);
            return Ok(airline);
        }

        [HttpPut()]
        public IActionResult Update(AirlineCompany airline)
        {
            _repo.Update(airline);
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