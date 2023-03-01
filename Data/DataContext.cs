using CarTracking.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarTracking.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CarRoute> CarRoutes { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarRoute)
                .WithMany(cr => cr.Cars)
                .HasForeignKey(c => c.CarRouteId);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Driver)
                .WithMany(d => d.Cars)
                .HasForeignKey(c => c.DriverId);
        }
    }
}
