using FluentValidation.Results;
using RentalCarService.Api;
using RentalCarService.Api.Models;
using RentalCarService.Api.Validators;
using System;
using System.Linq;

namespace RentalCarsService
{
    public class RentalHandling
    {
        private RentalContext _rentalContext;
        private PriceCalculation _priceCalculation;
        public RentalHandling(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
            _priceCalculation = new PriceCalculation();
        }

        public string Register(RentalRegistrationModel RentalRegistration)
        {
            if (!CarExists(RentalRegistration.Regnr)) return "Regnr don't exists";
            CarType carType = CarTypeHandler.GetCarTypeFromName(RentalRegistration.CarCategory);
            Booking Booking = new Booking
            {
                BookingNumber = RentalRegistration.BookingNumber,
                CustomerDateOfBirth = RentalRegistration.CustomerDateOfBirth,
                MilageRegistrated = RentalRegistration.CurrentMilage,
                CarCategoryID = carType.CarTypeID,
                RentalStart = DateTime.Now
            };
            var Validator = new BookingValidator();
            var validationResult = Validator.Validate(Booking);
            if (validationResult.IsValid)
            {
                if (!IsCarBooked(RentalRegistration.Regnr))
                {
                    var car = _rentalContext.Cars.Single(c => c.Regnr == RentalRegistration.Regnr);
                    car.Booked = true;
                    Booking.CarID = car.CarID;
                    _rentalContext.Booking.Add(Booking);
                    _rentalContext.SaveChanges();
                    return "Booking created";
                }
                else
                {
                    return "Car out and about";
                }
            }
            else
            {
                return validationResult.ToString("~");
            }

        }
        public double ReturnBooking(string bookingnumber, int CurrentMilage, int baseDayRental, double kilometerPrice)
        {
            Booking booking = _rentalContext.Booking.Where(b => b.BookingNumber == bookingnumber && b.MilageReturned == 0).LastOrDefault();
            booking.RentalEnd = DateTime.Now;
            booking.MilageReturned = CurrentMilage;
            Car car = _rentalContext.Cars.Single(c => c.CarID == booking.CarID);
            car.Booked = false;
            booking.Price = GetBookingPrice(booking, car, baseDayRental, kilometerPrice);
            _rentalContext.SaveChanges();
            return booking.Price;
        }

        public double GetBookingPrice(Booking booking, Car car, int baseDayRental, double kilometerPrice)
        {
            double numberOfDays = (booking.RentalEnd.Date - booking.RentalStart.Date).TotalDays;
            int numberOfKilometer = (booking.MilageReturned - booking.MilageRegistrated);
            return _priceCalculation.CalculatPrice(car.CarTypeID, baseDayRental, numberOfDays, kilometerPrice, numberOfKilometer);
        }

        public bool IsCarBooked(string Regnr)
        {
            if (_rentalContext.Cars.Any(c => c.Regnr == Regnr && c.Booked == true)) return true;
            return false;
        }

        public bool CarExists(string regnr)
        {
            return _rentalContext.Cars.Any(c => c.Regnr == regnr);
        }
    }
}
