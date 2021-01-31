using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api.Models
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CarID { get; set; }
        public string Regnr { get; set; }
        public int Milage { get; set; }
        public int CarTypeID { get; set; }
        public bool Booked { get; set; }
    }
}
