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
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        private readonly DbContext _context;

        public FlightRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Flight> GetFlightsByUser(User user)
        {
            var flights = _context.Set<Flight>()
                .Include(t => t.Tickets)
                .ThenInclude(u => u.User)
                .Where(p => p.Id.Equals(user.Id))
                .ToList();

            return flights;
        }

        public IEnumerable<Flight> GetFlightsByDepartureDate(DateTime departureDate)
        {
            var flights = _context.Set<Flight>()
                .Where(t => t.Departure.Date.Equals(departureDate.Date))
                .ToList();

            return flights;
        }

        public IEnumerable<Flight> GetFlightsByDestination(Country country)
        {

            var flights = _context.Set<Flight>()
                .Where(t => t.DestinationCountryId.Equals(country.Id))
                .ToList();

            return flights;
        }

        public IEnumerable<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            var flights = _context.Set<Flight>()
                .Where(t => t.Arrival.Date.Equals(landingDate.Date))
                .ToList();

            return flights;
        }

        public IEnumerable<Flight> GetFlightsByOriginCountry(Country country)
        {
            var flights = _context.Set<Flight>()
               .Where(t => t.OriginCountry.Id.Equals(country.Id))
                .ToList();

            return flights;
        }
    }
}

namespace Skynet.Data.Repositories
{
    public interface IFlightRepository : IRepository<Flight>
    {
        IEnumerable<Flight> GetFlightsByUser(User user);
        IEnumerable<Flight> GetFlightsByLandingDate(DateTime landingDate);
        IEnumerable<Flight> GetFlightsByDepartureDate(DateTime departureDate);
        IEnumerable<Flight> GetFlightsByOriginCountry(Country country);
        IEnumerable<Flight> GetFlightsByDestination(Country country);
    }

}
