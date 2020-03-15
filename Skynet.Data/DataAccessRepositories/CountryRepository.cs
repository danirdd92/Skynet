using Microsoft.Extensions.Configuration;
using Skynet.Data.Internal;
using Skynet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Skynet.Data.DataAccessRepositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(IConfiguration config, IDbConnection connection) : base(config, connection) { }
    }

    public interface ICountryRepository : IRepository<Country> { }

}
