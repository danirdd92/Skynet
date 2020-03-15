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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _repo;

        public CountriesController(ICountryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var country = _repo.Get(id);
            return Ok(country);
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var country = _repo.GetAll();
            return Ok(country);
        }

        [HttpPost()]
        public IActionResult Post(Country country)
        {
            _repo.Add(country);
            return Ok(country);
        }

        [HttpPut()]
        public IActionResult Update(Country country)
        {
            _repo.Update(country);
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