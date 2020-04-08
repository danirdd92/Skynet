using Skynet.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Skynet.Data.Repositories
{
    public class AirlineRepository : Repository<Airline>, IAirlineRepository
    {
        private readonly SkynetContext _context;

        public AirlineRepository(SkynetContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Airline> GetAirlineByCountry(Country country)
        {
            var airlines = _context.Set<Airline>().Where(a => a.Country.Id.Equals(country.Id));
            return airlines;
        }

        public Airline GetAirlineByCustomerName(Customer customer)
        {
            // Todo: Return to this after authentication
            throw new Exception("Not Implemented yet");
        }
    }


    public interface IAirlineRepository : IRepository<Airline>
    {

        Airline GetAirlineByCustomerName(Customer customer);
        IEnumerable<Airline> GetAirlineByCountry(Country country);
    }

}
