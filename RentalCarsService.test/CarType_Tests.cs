using NUnit.Framework;
using RentalCarService.Api;
using RentalCarService.Api.Models;
using System.Collections.Generic;

namespace RentalCarsService.test
{
    [TestFixture]
    public class CarType_Tests
    {
        [Test]
        [TestCase("DragorSlayer")]
        [TestCase("2 Premium")]
        [TestCase("")]
        public void CarTypeFromNameException_Test(string CarTypeName)
        {
            Assert.Throws<KeyNotFoundException>(() => CarTypeHandler.GetCarTypeFromName(CarTypeName));
        }

        [Test]
        [TestCase("Premium","Premium")]
        [TestCase("Minivan","Minivan")]
        [TestCase("Compact","Compact")]
        [TestCase("Compact ","Compact")]
        [TestCase("MINIVAN","Minivan")]
        public void CarTypeFromValidName_Test(string CarTypeName,string ExpectedName)
        {
            CarType carType = CarTypeHandler.GetCarTypeFromName(CarTypeName);
            Assert.AreEqual(carType.CarTypeName, ExpectedName);
        }

       [Test]
       [TestCase(1,"Compact")]
       [TestCase(2,"Premium")]
        public void CartypeFromID_Test(int CarTypeID,string ExpectedName)
        {
            CarType carType = CarTypeHandler.GetCarTypeFromCarTypeID(CarTypeID);
            Assert.AreEqual(carType.CarTypeName, ExpectedName);
        }

        [Test] 
        [TestCase("-1")]
        [TestCase("21589")]
        public void CarTypeFromIDException_Test(int CarTypeID)
        {
            
            Assert.Throws<KeyNotFoundException>(() => CarTypeHandler.GetCarTypeFromCarTypeID(CarTypeID));
        }


    }
}