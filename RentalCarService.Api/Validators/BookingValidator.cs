using FluentValidation;
using RentalCarService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api.Validators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(booking => booking.CustomerDateOfBirth).NotNull().WithMessage("Please add Customers date of birth");
            RuleFor(Booking => Booking.CarCategoryID).NotNull().WithMessage("Pick an CarCategory");
            RuleFor(booking => booking.BookingNumber).NotNull().WithMessage("Add a bookingnumber");
            RuleFor(booking => booking.RentalStart).Must(IsValidDate).WithMessage("Pick a valid date");
        }

        private bool IsValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
        
    }
}
