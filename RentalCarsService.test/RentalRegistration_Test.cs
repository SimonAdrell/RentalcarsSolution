using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RentalCarService.Api;
using RentalCarService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarsService.test
{
    [TestFixture]
    class RentalRegistration_Test
    {
        private RentalHandling _rentalRegistration;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RentalContext>() .UseInMemoryDatabase(databaseName: "TestingDB").Options;
            var rentalContext = new RentalContext(options);
            if(!rentalContext.Cars.Any(c => c.Regnr == "KZV123"))
            {
                rentalContext.Cars.Add(new Car { CarID=1, Booked = true, CarTypeID = 3, Milage = 120, Regnr = "KZV123" });
                rentalContext.Cars.Add(new Car { CarID=2, Booked = true, CarTypeID = 2, Milage = 120, Regnr = "CPR100" });
                rentalContext.Cars.Add(new Car { CarID=3, Booked = false, CarTypeID = 1, Milage = 120, Regnr = "CPR101" });
                rentalContext.Cars.Add(new Car { CarID=4, Booked = true, CarTypeID = 1, Milage = 120, Regnr = "CPR103" });
            }
            if (!rentalContext.Booking.Any(c => c.BookingNumber == "0737696971"))
            {
                rentalContext.Booking.Add(new Booking { CarID = 1, BookingNumber = "1", CustomerDateOfBirth = "121212121212", RentalStart = DateTime.Now.AddDays(-10), MilageRegistrated = 1000 });
                rentalContext.Booking.Add(new Booking { CarID = 2, BookingNumber = "2", CustomerDateOfBirth = "121212121212", RentalStart = DateTime.Now.AddDays(-2), MilageRegistrated = 2000 });
                rentalContext.Booking.Add(new Booking { CarID = 4, BookingNumber = "4", CustomerDateOfBirth = "121212121212", RentalStart = DateTime.Now.AddDays(-2), MilageRegistrated = 2000 });
            }

            rentalContext.SaveChanges();
            _rentalRegistration = new RentalHandling(rentalContext);
        }

        [Test]
        [TestCase("3", "dateofbirth", "Premium", 1200, "CPR101", ExpectedResult = "Booking created")]
        public string Register_test(string Bookingnumber, string DateOfBirth, string CarCategory, int CurrentMilage, string Regnr)
        {
            RentalRegistrationModel rentalRegistrationModel = new RentalRegistrationModel
            {
                BookingNumber = Bookingnumber,
                CustomerDateOfBirth = DateOfBirth,
                CarCategory = CarCategory,
                CurrentMilage = CurrentMilage,
                Regnr = Regnr
            };
            return _rentalRegistration.Register(rentalRegistrationModel);
        }

        [Test]
        [TestCase("4", "dateofbirth", "Premium", 1200, "RON222", ExpectedResult = "Regnr don't exists")]
        public string RegisterInvalidRegnr_test(string Bookingnumber, string DateOfBirth, string CarCategory, int CurrentMilage, string Regnr)
        {
            RentalRegistrationModel rentalRegistrationModel = new RentalRegistrationModel{
                    BookingNumber = Bookingnumber,CustomerDateOfBirth= DateOfBirth, CarCategory = CarCategory, CurrentMilage = CurrentMilage,Regnr =Regnr
                };
            return _rentalRegistration.Register(rentalRegistrationModel);
        }

        [Test]
        [TestCase("5", "dateofbirth", "Premium", 1200, "CPR103", ExpectedResult = "Car out and about")]
        public string RegisterBookedCar_test(string Bookingnumber, string DateOfBirth, string CarCategory, int CurrentMilage, string Regnr)
        {
            RentalRegistrationModel rentalRegistrationModel = new RentalRegistrationModel
            {
                BookingNumber = Bookingnumber,
                CustomerDateOfBirth = DateOfBirth,
                CarCategory = CarCategory,
                CurrentMilage = CurrentMilage,
                Regnr = Regnr
            };
            return _rentalRegistration.Register(rentalRegistrationModel);
        }

        [Test]
        [TestCase("1", 1300,300,2, ExpectedResult = 6000, 
            Description ="Return a minivan: 300 * 10 * 1.7 + (2 * 300 * 1.5)")]
        [TestCase("2", 2100, 299,4, ExpectedResult = 1117.6, 
            Description = "Return a Premium: 299 * 2 * 1.2 + 4 * 100")]
        public double CarReturn_Test(string Bookingnumber, int CurrentMilage,int baseDayRental,double kilometerPrice )
        {
            //CurrentMilage = 1300
            return _rentalRegistration.ReturnBooking(Bookingnumber, CurrentMilage, baseDayRental, kilometerPrice);
        }

    }
}
