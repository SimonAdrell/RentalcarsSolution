using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api.Models
{
    public class RentalReturnModel
    {
        public string BookingNumber { get; set; }
        public int CurrentMilage { get; set; }
    }
}
