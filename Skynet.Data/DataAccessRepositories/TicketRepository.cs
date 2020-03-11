using Skynet.Data.Internal;
using Skynet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data
{
    interface ITicketRepository : ICrudRepository<Ticket> { }
    public class TicketRepository : ITicketRepository
    {
        public void Add(Ticket item)
        {
            throw new NotImplementedException();
        }

        public Ticket Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAll()
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
