using Microsoft.Extensions.Configuration;
using Skynet.Data.Internal;
using Skynet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Skynet.Data
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(IConfiguration config, IDbConnection connection) : base(config, connection) { }
    }

    public interface ITicketRepository : IRepository<Ticket> { }

}
