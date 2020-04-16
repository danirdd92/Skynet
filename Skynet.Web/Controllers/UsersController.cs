using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;
using System.Threading.Tasks;

namespace Skynet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public CustomerController(IUnitOfWork db)
        {
            _db = db;
        }



        [HttpGet]
        public async Task<ActionResult<Customer>> GetAllCustomers()
        {
            var customers = await _db.Customers.GetAllAsync();
            return Ok(customers);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _db.Customers.GetAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }



        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer([FromBody] Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            await _db.CompleteAsync();

            return CreatedAtAction("GetCustomerById", new { id = customer.Id }, customer);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            await _db.Customers.UpdateAsync(customer);

            try
            {
                await _db.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id, customer))
                {
                    return NotFound(customer);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _db.Customers.GetAsync(id);
            if (customer == null)
            {
                return NotFound(customer);
            }
            await _db.Customers.RemoveAsync(customer);
            await _db.CompleteAsync();
            return customer;

        }


        private bool CustomerExists(int id, Customer customer)
        {
            if (_db.Customers.FindAsync(a => a.Id.Equals(customer.Id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}