using Skynet.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Skynet.Data.Repositories
{
    public class AirlineRepository : Repository<Airline>, IAirlineRepository
    {
        private readonly SkynetContext _context;

        public AirlineRepository(SkynetContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Airline>> GetAirlineByCountryAsync(Country country)
        {
            var airlines = await this.FindAsync(a => a.Country.Id.Equals(country.Id));
            return airlines;
        }
    }


    public interface IAirlineRepository : IRepository<Airline>
    {
        Task<IEnumerable<Airline>> GetAirlineByCountryAsync(Country country);
    }

}
