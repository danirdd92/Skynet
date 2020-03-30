using Microsoft.EntityFrameworkCore;
using Skynet.Domain;

namespace Skynet.Data
{
    public class SkynetContext : DbContext
    {
        private readonly DbContextOptions<SkynetContext> _options;

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public SkynetContext(DbContextOptions<SkynetContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many To Many For Users and Flights
            modelBuilder.Entity<Ticket>()
                .HasKey(t => new { t.FlightId, t.UserId });

            modelBuilder.Entity<Ticket>()
                .HasOne(c => c.User)
                .WithMany(t => t.Tickets)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(f => f.Flight)
                .WithMany(t => t.Tickets)
                .HasForeignKey(f => f.FlightId);

            // One To One Users and User Description
            modelBuilder.Entity<User>()
                .HasOne(d => d.UserDescription)
                .WithOne(u => u.User)
                .HasForeignKey<UserDescription>(d => d.UserId);

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
