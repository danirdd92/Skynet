using Microsoft.EntityFrameworkCore;
using Skynet.Domain;

namespace Skynet.Data
{
    public class SkynetContext : DbContext
    {
        private readonly DbContextOptions<SkynetContext> _options;

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<CustomerIdentity> CustomerIdentities { get; set; }

        public SkynetContext(DbContextOptions<SkynetContext> options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerIdentity>()
                .HasKey(i => i.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasOne(i => i.CustomerIdentity)
                .WithOne(c => c.Customer)
                .HasForeignKey<CustomerIdentity>(i => i.CustomerId);


            // Many To Many For Users and Flights
            modelBuilder.Entity<Ticket>()
                .HasKey(t => new { t.FlightId, t.CustomerId });

            modelBuilder.Entity<Ticket>()
                .HasOne(c => c.Customer)
                .WithMany(t => t.Tickets)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<Ticket>()
                .HasOne(f => f.Flight)
                .WithMany(t => t.Tickets)
                .HasForeignKey(f => f.FlightId);


            // Flight Entity FKs
            modelBuilder.Entity<Flight>()
            .HasOne(p => p.OriginCountry)
            .WithMany(b => b.OutboundFlights)
            .HasForeignKey(p => p.OriginCountryId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Flight>()
            .HasOne(p => p.DestinationCountry)
            .WithMany(b => b.InboundFlights)
            .HasForeignKey(p => p.DestinationCountryId)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
