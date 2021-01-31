using RentalCarService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarService.Api
{
    public class PriceCalculation
    {
        public double CalculatPrice(string CarTypeName,int BaseDayRental, double NumberOfDays, double KilometerPrice, int NumerOfKilometer)
        {
            CarType carType = CarTypeHandler.GetCarTypeFromName(CarTypeName);
            return (BaseDayRental * NumberOfDays * carType.DayMultiplier) + (KilometerPrice * NumerOfKilometer * carType.KilometerMultiplier);
        }
        public double CalculatPrice(int CartypeID, int BaseDayRental, double NumberOfDays, double KilometerPrice, int NumerOfKilometer)
        {
            CarType carType = CarTypeHandler.GetCarTypeFromCarTypeID(CartypeID);
            return (BaseDayRental * NumberOfDays * carType.DayMultiplier) + (KilometerPrice * NumerOfKilometer * carType.KilometerMultiplier);
        }
    }

}
