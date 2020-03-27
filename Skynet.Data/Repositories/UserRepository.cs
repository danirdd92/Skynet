using Skynet.Domain;
using System.Data;
using System.Linq;

namespace Skynet.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly SkynetContext _context;

        public UserRepository(SkynetContext context) : base(context)
        {
            _context = context;
        }

        public User GetCustomerByUsername(string userName)
        {
            var user = _context.Set<User>()
                .Where(u => u.UserName.Equals(userName))
                .FirstOrDefault();
            return user;
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        User GetCustomerByUsername(string userName);
    }

}
