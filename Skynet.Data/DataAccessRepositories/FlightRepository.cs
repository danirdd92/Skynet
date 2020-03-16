using Microsoft.Extensions.Configuration;
using Skynet.Data.Internal;
using Skynet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Skynet.Data.DataAccessRepositories
{

    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(IConfiguration config, IDbConnection connection) : base(config, connection) { }

        public IEnumerable<Flight> GetAllFlightsVacancy()
        {
            throw new NotImplementedException();
        }

        public Flight GetFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetFlightsByCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetFlightsByDepartureDate(DateTime departureDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetFlightsByDestination(Country country)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetFlightsByOriginCountry(Country country)
        {
            throw new NotImplementedException();
        }
    }

    public interface IFlightRepository : IRepository<Flight>
    {
        IEnumerable<Flight> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        IEnumerable<Flight> GetFlightsByCustomer(Customer customer);
        IEnumerable<Flight> GetFlightsByLandingDate(DateTime landingDate);
        IEnumerable<Flight> GetFlightsByDepartureDate(DateTime departureDate);
        IEnumerable<Flight> GetFlightsByOriginCountry(Country country);
        IEnumerable<Flight> GetFlightsByDestination(Country country);
    }

}
