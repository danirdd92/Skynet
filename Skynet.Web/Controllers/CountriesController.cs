using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;
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
        public async Task<ActionResult<Country>> GetAllCountries()
        {
            var countries = await _db.Countries.GetAllAsync();
            return Ok(countries);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            var country = await _db.Countries.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }



        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry([FromBody] Country country)
        {
            await _db.Countries.AddAsync(country);
            await _db.CompleteAsync();

            return CreatedAtAction("GetCountryById", new { id = country.Id }, country);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> UpdateCountry(int id, [FromBody] Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            await _db.Countries.UpdateAsync(country);

            try
            {
                await _db.CompleteAsync();
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
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            var country = await _db.Countries.GetAsync(id);
            if (country == null)
            {
                return NotFound(country);
            }
            await _db.Countries.RemoveAsync(country);
            await _db.CompleteAsync();
            return country;

        }


        private bool CountryExists(int id, Country country)
        {
            if (_db.Countries.FindAsync(a => a.Id.Equals(country.Id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}
