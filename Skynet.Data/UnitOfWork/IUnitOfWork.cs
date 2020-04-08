using Skynet.Data.Repositories;
using System;

namespace Skynet.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAirlineRepository Airlines { get; }
        ICountryRepository Countries { get; }
        IFlightRepository Flights { get; }
        ICustomerRepository Customers { get; }

        int Complete();
    }
}