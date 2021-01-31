using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api.Models
{
    public class RentalRegistrationModel
    {
        public string Regnr { get; set; }
        public string BookingNumber { get; set; }
        public string  CustomerDateOfBirth { get; set; }
        public string CarCategory { get; set; }
        public int CurrentMilage { get; set; }
    }
}
