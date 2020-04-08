using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;

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
        public ActionResult<Customer> GetAllCustomers()
        {
            var customers = _db.Customers.GetAll();
            return Ok(customers);
        }



        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _db.Customers.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }



        [HttpPost]
        public ActionResult<Customer> PostCustomer([FromBody] Customer customer)
        {
            _db.Customers.Add(customer);
            _db.Complete();

            return CreatedAtAction("GetCustomerById", new { id = customer.Id }, customer);
        }



        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _db.Customers.Update(customer);

            try
            {
                _db.Complete();
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
        public ActionResult<Customer> DeleteCustomer(int id)
        {
            var customer = _db.Customers.Get(id);
            if (customer == null)
            {
                return NotFound(customer);
            }
            _db.Customers.Remove(customer);
            _db.Complete();
            return customer;

        }


        private bool CustomerExists(int id, Customer customer)
        {
            if (_db.Customers.Find(a => a.Id.Equals(customer.Id)) == null)
            {
                return false;
            }
            return true;
        }
    }
}