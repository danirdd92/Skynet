using Microsoft.EntityFrameworkCore;
using Skynet.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Skynet.Data.Repositories
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        private readonly SkynetContext _context;

        public FlightRepository(SkynetContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByUserAsync(Customer customer)
        {
            var flights = await _context.Set<Flight>()
                .Include(t => t.Tickets)
                .ThenInclude(u => u.Customer)
                .Where(p => p.Id.Equals(customer.Id))
                .ToListAsync();

            return flights;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByDepartureDateAsync(DateTime departureDate)
        {
            var flights = await _context.Set<Flight>()
                .Where(t => t.Departure.Date.Equals(departureDate.Date))
                .ToListAsync();

            return flights;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByDestinationAsync(Country country)
        {

            var flights = await _context.Set<Flight>()
                .Where(t => t.DestinationCountryId.Equals(country.Id))
                .ToListAsync();

            return flights;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByLandingDateAsync(DateTime landingDate)
        {
            var flights = await _context.Set<Flight>()
                .Where(t => t.Arrival.Date.Equals(landingDate.Date))
                .ToListAsync();

            return flights;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByOriginCountryAsync(Country country)
        {
            var flights = await _context.Set<Flight>()
               .Where(t => t.OriginCountry.Id.Equals(country.Id))
                .ToListAsync();

            return flights;
        }

        public async Task<(IEnumerable<Flight>, List<string>)> GetUpcomingFlightsAsync()
        {
            var time = DateTime.Now;
            var timespan = time.AddHours(10);    

            var flights = await _context.Set<Flight>()
                .Where(t => t.Departure >= time)
                .Where(t => t.Departure <= timespan)
                .ToListAsync()
                ;

            var idList = new List<string>(flights.Count);

            foreach (var flight in flights)
            {
                string abrvId = string.Empty;
                if (flight.Airline.Abbreviation != null)
                {
                    abrvId = flight.Airline.Abbreviation + flight.Id.ToString();

                    idList.Add(abrvId);
                }
                else
                {
                    abrvId = flight.Id.ToString();
                }
                
            }

            return (flights, idList);
        }
    }

    public interface IFlightRepository : IRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetFlightsByUserAsync(Customer user);
        Task<IEnumerable<Flight>> GetFlightsByLandingDateAsync(DateTime landingDate);
        Task<IEnumerable<Flight>> GetFlightsByDepartureDateAsync(DateTime departureDate);
        Task<IEnumerable<Flight>> GetFlightsByOriginCountryAsync(Country country);
        Task<IEnumerable<Flight>> GetFlightsByDestinationAsync(Country country);
        Task<(IEnumerable<Flight>, List<string>)> GetUpcomingFlightsAsync();
    }
}




