using RentalCarService.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarService.Api
{
    public class CarTypeHandler
    {
        private static readonly List<CarType> CarTypes = new List<CarType>{ new CarType
                {
                    CarTypeID = 1,
                    CarTypeName = "Compact",
                    DayMultiplier = 1,
                    KilometerMultiplier = 1
                },
                new CarType
                {
                    CarTypeID = 2,
                    CarTypeName = "Premium",
                    DayMultiplier = 1.2,
                    KilometerMultiplier = 1
                },
                new CarType
                {
                    CarTypeID = 3,
                    CarTypeName = "Minivan",
                    DayMultiplier = 1.7,
                    KilometerMultiplier = 1.5
                } };

        public  static CarType GetCarTypeFromName(string CarTypeName)
        {
            string name = CarTypeName.ToLower().Replace(" ", "");
            if (CarTypes.Where(ct => ct.CarTypeName.ToLower() == name).Any() == false)
            {
                throw new KeyNotFoundException("Cartype not found");
            }
            else
            {
                return CarTypes.Single(carType => carType.CarTypeName.ToLower() == name);
            }
        }

        public static CarType GetCarTypeFromCarTypeID(int CarTypeID)
        {
            if (CarTypes.Where(ct => ct.CarTypeID == CarTypeID).Any() == false)
            {
                throw new KeyNotFoundException("CartypeID not found");
            }
            else
            {
                return CarTypes.Single(carType => carType.CarTypeID == CarTypeID);
            }
        }

    }
}
