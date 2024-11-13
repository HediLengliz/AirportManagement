using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AM.Infrastructure
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map Traveller to its own table
            modelBuilder.Entity<Traveller>()
                .ToTable("Travelers");

            // Map Staff to its own table
            modelBuilder.Entity<Staff>()
                .ToTable("Staffs");

            // Map Passenger to its own table
            modelBuilder.Entity<Passenger>()
                .ToTable("Passengers")
                .Property(e => e.TelNumber)
                .HasColumnName("NumTel")
                .HasConversion<int>()
                .HasDefaultValue(0);

            modelBuilder.Entity<Passenger>()
                .OwnsOne(p => p.FullName, fn =>
                {
                    fn.Property(f => f.FirstName).HasColumnName("FullNameFirst");
                    fn.Property(f => f.LastName).HasColumnName("FullNameLast");
                });

            // Apply additional configurations
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Flight> flights { get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Traveller> travelers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder ConfigurationBuilder)
        {
            ConfigurationBuilder.Properties<DateTime>().HaveColumnType("datetime");
            base.ConfigureConventions(ConfigurationBuilder);
        }
    }
}
