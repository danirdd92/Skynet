using Microsoft.Extensions.Configuration;
using Skynet.Data.Internal;
using Skynet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Skynet.Data.DataAccessRepositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration config, IDbConnection connection) : base(config, connection) { }

        public Customer GetCustomerByUsername(string userName)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerByUsername(string userName);
    }

}
