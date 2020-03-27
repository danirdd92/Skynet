using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skynet.Data;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skynet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public CountriesController(IUnitOfWork db)
        {
            _db = db;
        }



        [HttpGet]
        public ActionResult<Country> GetAllCountries()
        {
            var countries = _db.Countries.GetAll();
            return Ok(countries);
        }



        [HttpGet("{id}")]
        public ActionResult<Country> GetCountryById(int id)
        {
            var country = _db.Countries.Get(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }



        [HttpPost]
        public ActionResult<Country> PostCountry([FromBody] Country country)
        {
            _db.Countries.Add(country);
            _db.Complete();

            return CreatedAtAction("GetCountryById", new { id = country.Id }, country);
        }



        [HttpPut("{id}")]
        public ActionResult<Country> UpdateCountry(int id, [FromBody] Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _db.Countries.Update(country);

            try
            {
                _db.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id, country))
                {
                    return NotFound(country);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        [HttpDelete("{id}")]
        public ActionResult<Country> DeleteCountry(int id)
        {
            var country = _db.Countries.Get(id);
            if (country == null)
            {
                return NotFound(country);
            }
            _db.Countries.Remove(country);
            _db.Complete();
            return country;

        }


        private bool CountryExists(int id, Country country)
        {
            if (_db.Countries.Find(a => a.Id.Equals(country.Id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}
