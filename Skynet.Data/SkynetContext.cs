using Microsoft.EntityFrameworkCore;
using Skynet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data
{
    class SkynetContext : DbContext
    {
        public DbSet<AirlineCompany> AirlineCompanies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Data Source = (localDb)\MSSQLLocalDB; Initial Catalog = SkynetData");
        }
    }
}
