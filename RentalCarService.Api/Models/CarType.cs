using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api.Models
{
    public class CarType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CarTypeID { get; set; }
        public string CarTypeName { get; set; }
        public double DayMultiplier { get; set; }
        public double KilometerMultiplier { get; set; }

    }
}
