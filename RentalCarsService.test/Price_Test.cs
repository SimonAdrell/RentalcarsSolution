using NUnit.Framework;
using RentalCarService.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarsService.test
{
    [TestFixture]
    class Price_Test
    {
        PriceCalculation priceCalculation;
        [SetUp]
        public void Setup()
        {
            priceCalculation = new PriceCalculation();
        }

        [Test]
        [TestCase("Compact",300,2,0,0, ExpectedResult=600)]
        [TestCase("Premium",300,2,2.0,150, ExpectedResult=1020)]
        [TestCase("Minivan",300,2,2.0,150, ExpectedResult=1470)]
        [TestCase("Minivan",300,10,2.0,300, ExpectedResult=6000)]
        [TestCase("MINIVAN ",300,2,2.0,150, ExpectedResult = 1470)]
        public double PriceCalculationByCartypeName_test(string CarType,int BaseDayRental,int NumberOfDays, double KilometerPrice,int NumberOfKilometers)
        {
            var Price = priceCalculation.CalculatPrice(CarType,BaseDayRental, NumberOfDays, KilometerPrice,NumberOfKilometers);
            return Price;
        }

        [Test]
        [TestCase(1, 300, 2, 0, 0, ExpectedResult = 600)]
        [TestCase(2, 300, 2, 2.0, 150, ExpectedResult = 1020)]
        [TestCase(3, 300, 2, 2.0, 150, ExpectedResult = 1470)]
        public double PriceCalculationByCartypeID_test(int CartypeID, int BaseDayRental, int NumberOfDays, double KilometerPrice, int NumberOfKilometers)
        {
            var Price = priceCalculation.CalculatPrice(CartypeID, BaseDayRental, NumberOfDays, KilometerPrice, NumberOfKilometers);
            return Price;
        }

    }
}
