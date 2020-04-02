namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        Car car1;
        Car car2;
        Car car3;

        SoftPark park;

        [SetUp]
        public void Setup()
        {
            car1 = new Car("Passat", "AB12");
            car2 = new Car("Kadet", "CD34");
            car3 = new Car("AMG", "EF56");

            park = new SoftPark();
        }

        [Test]
        public void TestCarConstructorAndGeters()
        {
            var newCar = new Car("Astra", "CD5678");

            var expectedMake = "Astra";
            var expectedNumber = "CD5678";

            Assert.AreEqual(expectedMake, newCar.Make);
            Assert.AreEqual(expectedNumber, newCar.RegistrationNumber);
        }

        [Test]
        public void TestParkConstructorAndGeters()
        {
            var newPark = new SoftPark();

            Assert.IsNotNull(newPark);
        }

        [Test]
        public void TestParkCarWithOutSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                park.ParkCar("V3", car1);
            });
        }

        [Test]
        public void TestParkWithCarBusySpot()
        {
            park.ParkCar("A1", car1);

            Assert.Throws<ArgumentException>(() =>
            {
                park.ParkCar("A1", car2);
            });
        }
        
        [Test]
        public void TestParkWithCarAlreadyParcedCar()
        {
            park.ParkCar("A1", car1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                park.ParkCar("B3", car1);
            });
        }

        [Test]
        public void TestParkDictionaryGeter()
        {
            park.ParkCar("A1", car1);

            Assert.AreEqual(park.Parking["A1"], car1);
        }

        [Test]
        public void TestRemoveCarWithOutSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                park.RemoveCar("V3", car1);
            });
        }

        [Test]
        public void TestRemoveCarWithWrongSpot()
        {
            park.ParkCar("A1",car1);
            park.ParkCar("B1",car2);
            park.ParkCar("C1",car3);
           
            Assert.Throws<ArgumentException>(() =>
            {
                park.RemoveCar("V3", car1);
            });
        }

        [Test]
        public void TestRemoveCarWithWrongCar()
        {
            park.ParkCar("A1", car1);
            park.ParkCar("B1", car2);
            park.ParkCar("C1", car3);

            Assert.Throws<ArgumentException>(() =>
            {
                park.RemoveCar("B1", car1);
            });
        }

        [Test]
        public void TestRemoveCar()
        {
            park.ParkCar("A1", car1);
            park.ParkCar("B1", car2);
            park.ParkCar("C1", car3);

            park.RemoveCar("A1", car1);

            Assert.IsNull(park.Parking["A1"]);
        }



    }
}