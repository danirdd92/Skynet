using Skynet.Domain;
using System.Data;
using System.Linq;

namespace Skynet.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly SkynetContext _context;

        public CustomerRepository(SkynetContext context) : base(context)
        {
            _context = context;
        }

        public Customer GetCustomerByFirstName(string firstName)
        {
            var customer = _context.Set<Customer>()
                .Where(u => u.FirstName.Equals(firstName))
                .FirstOrDefault();
            return customer;
        }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerByFirstName(string userName);
    }

}
