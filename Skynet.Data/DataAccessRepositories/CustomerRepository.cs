using Skynet.Data.Internal;
using Skynet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data.DataAccessRepositories
{
    interface ICustomerRepository : ICrudRepository<Customer>
    {
        Customer GetCustomerByUsername(string userName);
    }
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByUsername(string userName)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
