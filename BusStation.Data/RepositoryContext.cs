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

            modelBuilder.Entity<BusStop>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<BusStop>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Route>().HasMany(x => x.RouteNodes).WithOne(y => y.Route);
            modelBuilder.Entity<Route>().HasMany(x => x.Trips).WithOne(y => y.Route);
            modelBuilder.Entity<Route>().HasOne(x => x.RouteType);

            modelBuilder.Entity<RouteNode>().HasOne(x => x.Route).WithMany(y => y.RouteNodes);
            modelBuilder.Entity<RouteNode>().HasOne(x => x.Node).WithMany(y => y.RouteNodes);

            modelBuilder.Entity<Node>().HasAlternateKey(x => x.Id);
            modelBuilder.Entity<Node>().HasKey(x => new { x.FirstBusStopId, x.SecondBusStopId });
            modelBuilder.Entity<Node>().HasOne(x => x.FirstBusStop).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Node>().HasOne(x => x.SecondBusStop).WithOne().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Trip>().HasOne(x => x.Route).WithMany(y => y.Trips);
            modelBuilder.Entity<Trip>().HasOne(x => x.Bus);

            modelBuilder.ApplyConfiguration(new BusStopConfiguration());
            modelBuilder.ApplyConfiguration(new RouteTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleDayConfiguration());
        }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteNode> RouteNodes { get; set; }
        public DbSet<RouteType> RouteTypes { get; set; }
        public DbSet<ScheduleDay> ScheduleDayes { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
