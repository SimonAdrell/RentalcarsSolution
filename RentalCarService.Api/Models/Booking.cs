using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api.Models
{
    public class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        public string BookingNumber { get; set; }
        public string CustomerDateOfBirth { get; set; }
        public int CarCategoryID { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public int MilageRegistrated { get; set; }
        public int MilageReturned { get; set; }
        public Double Price { get; set; }
        public int CarID { get; set; }
    }
}
