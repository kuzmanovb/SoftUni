using NUnit.Framework;
using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {
        string make;
        string model;
        double fuelConsumption;
        double fuelCapacity;
        Car car;


        [SetUp]
        public void Setup()
        {
            make = "GM";
            model = "Ford";
            fuelConsumption = 8;
            fuelCapacity = 45;

            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void TestEmptyConstructor()
        {
            var newCar = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void TestMakeGeter()
        {
            var expectedMake = make;

            Assert.AreEqual(expectedMake, car.Make);
        }

        [Test]
        public void TestMakeCarWithNullMake()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var newCar = new Car(null, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void TestModelGeter()
        {
            var expectedModel = model;

            Assert.AreEqual(expectedModel, car.Model);
        }

        [Test]
        public void TestMakeCarWithNullModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var newCar = new Car(make, null, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void TestFuelConsumptionGeter()
        {
            var expectedFuelConsumption = fuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
        }

        [Test]
        public void TestMakeCarWithZeroAndNegativeNumberFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var newCar = new Car(make, model, 0, fuelCapacity);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                var newCar = new Car(make, model, -5, fuelCapacity);
            });
        }

        [Test]
        public void TestFuelCapacityGeter()
        {
            var expectedFuelConsumption = fuelCapacity;

            Assert.AreEqual(expectedFuelConsumption, car.FuelCapacity);
        }

        [Test]
        public void TestMakeCarWithZeroAndNegativeNumberFfuelCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var newCar = new Car(make, model, fuelConsumption, 0);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                var newCar = new Car(make, model, fuelConsumption, -5);
            });
        }

        [Test]
        public void TestFuelAmountGeter()
        {
            var expectedFuelAmount = 0;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestRefuelWithZeroAndNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-5);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }

        [Test]
        public void TestRefuelIncreaseFuelAmount()
        {
            car.Refuel(5);

            var expectedAmount = 5;

            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [Test]
        public void TestRefuelOverFuelAmount()
        {
            car.Refuel(48);

            var expectedAmount = 45;

            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [Test]
        public void TestDriveWithNoEnonghFuel()
        {
            // fuelConsumption = 8;
            //double fuelNeeded = (distance / 100) * this.FuelConsumption;
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(1000);
            });
        }


        [Test]
        public void TestDriveWithEnonghFuel()
        {
            //fuelConsumption = 8;
            //double fuelNeeded = (distance / 100) * this.FuelConsumption;

            car.Refuel(10);
            car.Drive(100);
            var expectedFuel = 2;
            Assert.AreEqual(expectedFuel, car.FuelAmount);

        }
    }
}