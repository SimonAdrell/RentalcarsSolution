using FluentValidation;
using RentalCarService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api.Validators
{
    public class RentalRegistrationValidation : AbstractValidator<RentalRegistrationModel>
    {
        public RentalRegistrationValidation()
        {
            RuleFor(rentalregistration => rentalregistration.BookingNumber).NotEmpty().WithMessage("Please add a bookingnumber");
            RuleFor(rentalregistration => rentalregistration.CarCategory).NotEmpty().WithMessage("Please pick a car category");
            RuleFor(rentalregistration => rentalregistration.CurrentMilage).NotEmpty().WithMessage("Current milage is missing");
            RuleFor(rentalregistration => rentalregistration.CustomerDateOfBirth).NotEmpty().WithMessage("Customer date of birth is emtpy");
        }
    }
}
