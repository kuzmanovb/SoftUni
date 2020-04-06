using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        UnitMotorcycle motorcycle1;
        UnitMotorcycle motorcycle2;
        [SetUp]
        public void Setup()
        {
            motorcycle1 = new UnitMotorcycle("GT", 30, 125);
            motorcycle2 = new UnitMotorcycle("FH", 20, 500);
        }

        [Test]
        public void TestMotorcycleConstructorAndGeters()
        {
            var expectedModel = "GT";
            var expectedHorsePower = 30;
            var expectedCubicCentimeters = 125;
            

            Assert.AreEqual(expectedModel, motorcycle1.Model);
            Assert.AreEqual(expectedHorsePower, motorcycle1.HorsePower);
            Assert.AreEqual(expectedCubicCentimeters, motorcycle1.CubicCentimeters);
        }

        [Test]
        public void TestRiderConstructorAndGeters()
        {
            var rider = new UnitRider("Pesho", motorcycle1);

            var expectedName = "Pesho";

            Assert.AreEqual(expectedName, rider.Name);
            Assert.AreEqual(motorcycle1, rider.Motorcycle);
           
        }

        [Test]
        public void TestRiderSeterNameWhitNullName()
        {
            string nameRider = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var rider = new UnitRider(nameRider, motorcycle1);
            });
        }

        [Test]
        public void TestRaceConstructor()
        {
            var race = new RaceEntry();

            Assert.IsNotNull(race);
        }

        [Test]
        public void TestAddRiderWithNullRider()
        {
            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddRider(null);
            });
        }

        [Test]
        public void TestAddRiderWithSameRider()
        {
            var race = new RaceEntry();
            var rider = new UnitRider("Pesho", motorcycle1);

            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddRider(rider);
            });
        }

        [Test]
        public void TestRaceCount()
        {
            var race = new RaceEntry();
            var rider = new UnitRider("Pesho", motorcycle1);

            race.AddRider(rider);
            var expectedCount = 1;

            Assert.AreEqual(expectedCount, race.Counter);
        }

        [Test]
        public void TestCalculateAverageHorsePowerWithLessMinParticipants()
        {
            var race = new RaceEntry();
            var rider = new UnitRider("Pesho", motorcycle1);

            race.AddRider(rider);


            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void TestCalculateAverageHorsePower()
        {
            var race = new RaceEntry();
           
            var rider1 = new UnitRider("Pesho", motorcycle1);
            var rider2 = new UnitRider("Gosho", motorcycle2);

            race.AddRider(rider1);
            race.AddRider(rider2);

            var expectedHorsePower = 25;

            Assert.AreEqual(expectedHorsePower, race.CalculateAverageHorsePower());
        }
        
    }
}