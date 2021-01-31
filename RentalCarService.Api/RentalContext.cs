using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentalCarService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api
{
    public class RentalContext : DbContext
    {
        public IConfiguration Configuration { get; }

        //public RentalContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public RentalContext(DbContextOptions<RentalContext> options):base(options)
        {
        }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<Car> Cars { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(Configuration.GetConnectionString("RentalContext"));
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    CarID = 1,
                    CarTypeID = 2,
                    Milage = 25800,
                    Regnr = "CPR100",
                    Booked = false
                }, new Car
                {
                    CarID = 2,
                    CarTypeID = 1,
                    Milage = 100000,
                    Regnr = "BXR995",
                    Booked = false
                }, new Car
                {
                    CarID = 3,
                    CarTypeID = 3,
                    Milage = 15270,
                    Regnr = "RON222",
                    Booked = true
                });
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    BookingID = 12,
                    BookingNumber = "125040",
                    CarCategoryID = 2,
                    CustomerDateOfBirth = "1212121212",
                    RentalStart = DateTime.Now.AddDays(-12),
                    MilageRegistrated = 15270,
                    CarID = 3
                });
        }
    }
}
