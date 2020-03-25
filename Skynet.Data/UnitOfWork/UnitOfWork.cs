﻿using Microsoft.EntityFrameworkCore;
using Skynet.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context )
        {
            _context = context as SkynetContext;

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

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
