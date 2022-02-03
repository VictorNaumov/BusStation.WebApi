using BusStation.Data.Configuration;
using BusStation.Data.DataTransferObjects.Admin;
using BusStation.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusStation.Data
{
    public class RepositoryContext : IdentityDbContext<Admin>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bus>().HasMany(x => x.Trips).WithOne(y => y.Bus);

            modelBuilder.Entity<BusStop>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Route>().HasOne(x => x.RouteType);
            modelBuilder.Entity<Route>().HasMany(p => p.BusStops).WithMany(p => p.Routes)
                .UsingEntity<RouteBusStop>(
                    j => j
                        .HasOne(pt => pt.BusStop)
                        .WithMany(t => t.RouteBusStops)
                        .HasForeignKey(pt => pt.BusStopId),
                    j => j
                        .HasOne(pt => pt.Route)
                        .WithMany(p => p.RouteBusStops)
                        .HasForeignKey(pt => pt.RouteId),
                    j =>
                    {
                        j.HasKey(t => new { t.RouteId, t.BusStopId, t.Order });
                    });

            modelBuilder.Entity<TripReport>().HasNoKey().ToView("View_TripReport");

            modelBuilder.ApplyConfiguration(new RouteTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new BusConfiguration());
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
            modelBuilder.ApplyConfiguration(new BusStopConfiguration());
            modelBuilder.ApplyConfiguration(new RouteBusStopConfiguration());
            modelBuilder.ApplyConfiguration(new TripConfiguration());
        }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<TripReport> TripReports { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteType> RouteTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
