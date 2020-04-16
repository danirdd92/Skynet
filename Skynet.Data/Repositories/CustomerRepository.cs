using Skynet.Domain;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 
namespace Skynet.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly SkynetContext _context;

        public CustomerRepository(SkynetContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByFirstNameAsync(string firstName)
        {
            var customer = await _context.Set<Customer>()
                .Where(u => u.FirstName.Equals(firstName))
                .FirstOrDefaultAsync();
            return customer;
        }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerByFirstNameAsync(string userName);
    }

}
