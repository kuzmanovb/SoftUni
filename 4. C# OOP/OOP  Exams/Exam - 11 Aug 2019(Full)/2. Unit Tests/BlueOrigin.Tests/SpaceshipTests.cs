namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {

        [Test]
        public void TestAstronautConstructor()
        {
            var astro = new Astronaut("Pesho", 100);

            Assert.AreEqual("Pesho", astro.Name);
            Assert.AreEqual(100, astro.OxygenInPercentage);
        }

        [Test]
        public void TestSpaceshipConstructor()
        {
            var spaceship = new Spaceship("To", 20);

            Assert.AreEqual("To", spaceship.Name);
            Assert.AreEqual(20, spaceship.Capacity);
            Assert.AreEqual(0, spaceship.Count);
        }

        [Test]
        public void TestSeterNameWithNull()
        {

            Assert.Throws<ArgumentNullException>(() => {

                var spaceship = new Spaceship(null, 20);
            });
        }

        [Test]
        public void TestSeterCapacityWithNegativNumber()
        {

            Assert.Throws<ArgumentException>(() => {

                var spaceship = new Spaceship("To", -20);
            });
        }

        [Test]
        public void TestAddMethod()
        {
            var spaceship = new Spaceship("To", 20);
            var astro = new Astronaut("Pesho", 100);

            spaceship.Add(astro);

            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void TestAddMethodWithFullCapacity()
        {
            var spaceship = new Spaceship("To", 1);
            var astro1 = new Astronaut("Pesho", 100);
            var astro2 = new Astronaut("Tosho", 100);

            spaceship.Add(astro1);

            Assert.Throws<InvalidOperationException>(() => {
                spaceship.Add(astro2);
            });
        }

        [Test]
        public void TestAddMethodWithSameName()
        {
            var spaceship = new Spaceship("To", 2);
            var astro1 = new Astronaut("Pesho", 100);
            var astro2 = new Astronaut("Tosho", 100);

            spaceship.Add(astro1);

            Assert.Throws<InvalidOperationException>(() => {
                spaceship.Add(astro1);
            });
        }

        [Test]
        public void TestRemoveMethod()
        {
            var spaceship = new Spaceship("To", 2);
            var astro1 = new Astronaut("Pesho", 100);
            var astro2 = new Astronaut("Tosho", 100);

            spaceship.Add(astro1);
            spaceship.Add(astro2);

            var actual = spaceship.Remove("Pesho");

            Assert.AreEqual(true, actual);
        }
    }
}