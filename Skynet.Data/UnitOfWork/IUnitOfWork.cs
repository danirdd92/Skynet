using Skynet.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Skynet.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAirlineRepository Airlines { get; }
        ICountryRepository Countries { get; }
        IFlightRepository Flights { get; }
        ICustomerRepository Customers { get; }

        Task<int> CompleteAsync();
    }
}