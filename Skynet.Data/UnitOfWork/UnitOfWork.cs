using Skynet.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Skynet.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SkynetContext _context;

        public UnitOfWork(SkynetContext context)
        {
            _context = context;

            Airlines = new AirlineRepository(_context);
            Countries = new CountryRepository(_context);
            Flights = new FlightRepository(_context);
            Customers = new CustomerRepository(_context);
        }
        public IAirlineRepository Airlines { get; private set; }

        public ICountryRepository Countries { get; private set; }

        public IFlightRepository Flights { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public async Task<int> CompleteAsync()
        {
             return await _context.SaveChangesAsync();
        }

        #region Dispose
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
