using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring Table Per Type (TPT) for Passenger, Staff, and Traveller
            //modelBuilder.Entity<Passenger>().ToTable("passengers");
           // modelBuilder.Entity<Staff>().ToTable("staffs");  // Table for Staff
           // modelBuilder.Entity<Traveller>().ToTable("travellers");  // Table for Traveller
        }
        public DbSet<Flight> flights { get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Traveller> travelers { get; set; }
    }
}
