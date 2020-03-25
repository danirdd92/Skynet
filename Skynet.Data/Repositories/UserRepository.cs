using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Skynet.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Skynet.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context) : base(context) {
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
