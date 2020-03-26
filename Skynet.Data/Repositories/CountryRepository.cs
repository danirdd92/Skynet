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
        private readonly SkynetContext _context;

        public CountryRepository(SkynetContext context) : base(context) {
            _context = context;
        }
    }

public interface ICountryRepository : IRepository<Country> { }

}
