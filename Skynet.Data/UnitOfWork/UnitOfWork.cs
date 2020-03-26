using Microsoft.EntityFrameworkCore;
using Skynet.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SkynetContext _context;

        public UnitOfWork(SkynetContext context )
        {
            _context = context;

            Airlines = new AirlineRepository(_context);
            Countries = new CountryRepository(_context);
            Flights = new FlightRepository(_context);
            Users = new UserRepository(_context);
        }
        public IAirlineRepository Airlines { get; private set; }

        public ICountryRepository Countries {get; private set;}

        public IFlightRepository Flights {get; private set;}

        public IUserRepository Users {get; private set;}

        public int Complete()
        {
            return _context.SaveChanges();
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
