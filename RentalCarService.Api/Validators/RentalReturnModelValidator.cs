using FluentValidation;
using RentalCarService.Api.Models;
using RentalCarsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api.Validators
{
    public class RentalReturnModelValidator : AbstractValidator<RentalReturnModel>
    {
        RentalContext _rentalContext;

        public RentalReturnModelValidator(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
            RuleFor(rentalReturnModel => rentalReturnModel.BookingNumber).NotNull().WithMessage("Bookingnumber is not valid");
            RuleFor(rentalReturnModel => rentalReturnModel.BookingNumber).Must(CheckIfBookingnumberIsActive).WithMessage("Can't find active booking with bookingnumber");
            RuleFor(rentalReturnModel => rentalReturnModel.CurrentMilage).NotNull().WithMessage("No milage on return");
            RuleFor(rentalReturnModel => rentalReturnModel.CurrentMilage).Must(IsMilageLessThenRegistration).WithMessage("Not valid milage. Less or same as registration milage");
        }
        private bool IsMilageLessThenRegistration(RentalReturnModel rentalReturnModel, int CurrentMilage)
        {
            Booking booking = _rentalContext.Booking.Where(b => b.BookingNumber == rentalReturnModel.BookingNumber && b.MilageReturned==0).OrderBy(b => b.BookingID).LastOrDefault();
            if(booking is null)
            {
                return true;
            }
            return booking.MilageRegistrated <= rentalReturnModel.CurrentMilage;
        }
        private bool CheckIfBookingnumberIsActive( string bookingNumber)
        {
            Booking booking = _rentalContext.Booking.Where(b => b.BookingNumber == bookingNumber && b.MilageReturned ==0).OrderBy(b => b.BookingID).LastOrDefault();
            return !(booking is null);
        }
    }
}
