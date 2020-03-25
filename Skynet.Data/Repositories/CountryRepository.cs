using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Skynet.Data.Repositories;
using Skynet.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Skynet.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context) : base(context) { }
    }

public interface ICountryRepository : IRepository<Country> { }

}
