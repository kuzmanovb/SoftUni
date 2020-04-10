namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {

        [Test]
        public void TestFishConstructor()
        {
            var fish = new Fish("Nemo");

            var expectedName = "Nemo";
            var expectedAvailable = true;

            Assert.AreEqual(expectedName, fish.Name);
            Assert.AreEqual(expectedAvailable, fish.Available);
        }

        [Test]
        public void TestAquariumConstructor()
        {
            var aquarium = new Aquarium("To", 100);

            var expectedName = "To";
            var expectedCapacity = 100;
            var expectedCount = 0;

            Assert.AreEqual(expectedName, aquarium.Name);
            Assert.AreEqual(expectedCapacity, aquarium.Capacity);
            Assert.AreEqual(expectedCount, aquarium.Count);

        }

        [Test]
        public void TestAquariumNameSeter()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium(null, 100);
            });
        }

        [Test]
        public void TestAquariumCapacitySeter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var aquarium = new Aquarium("To", -50);
            });
        }


        [Test]
        public void TestAquariumAddMethod()
        {
            var aquarium = new Aquarium("To", 100);
            var fish = new Fish("Nemo");

            aquarium.Add(fish);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void TestAquariumAddMethodWithFullCapacity()
        {
            var aquarium = new Aquarium("To", 1);
            var fish1 = new Fish("Nemo");
            var fish2 = new Fish("Trol");

            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish2);
            });
        }

        [Test]
        public void TestAquariumRempveMethod()
        {
            var aquarium = new Aquarium("To", 2);
            var fish1 = new Fish("Nemo");
            var fish2 = new Fish("Trol");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.RemoveFish("Nemo");

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, aquarium.Count);

        }

        [Test]
        public void TestAquariumRempveMethodWithInvalidName()
        {
            var aquarium = new Aquarium("To", 2);
            var fish1 = new Fish("Nemo");
            var fish2 = new Fish("Trol");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Tosho");
            });
        }

        [Test]
        public void TestAquariumSellFishMethod()
        {
            var aquarium = new Aquarium("To", 2);
            var fish1 = new Fish("Nemo");
            var fish2 = new Fish("Trol");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            var expectedFish = fish1;
            var actualFish = aquarium.SellFish("Nemo");

            Assert.AreEqual(expectedFish, actualFish);
        }

        [Test]
        public void TestAquariumSellFishMethodWithInvalidName()
        {
            var aquarium = new Aquarium("To", 2);
            var fish1 = new Fish("Nemo");
            var fish2 = new Fish("Trol");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() => {

                aquarium.SellFish("Gosho");
            });
        }

        [Test]
        public void TestAquariumRaportMethod()
        {
            var aquarium = new Aquarium("To", 2);
            var fish1 = new Fish("Nemo");
           

            aquarium.Add(fish1);

            var expectedRaport = "Fish available at To: Nemo";
            var actualRaport = aquarium.Report();

            Assert.AreEqual(expectedRaport, actualRaport);

        }
    }
}
