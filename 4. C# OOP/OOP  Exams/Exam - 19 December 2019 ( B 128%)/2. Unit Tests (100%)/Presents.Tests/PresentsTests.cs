namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    public class PresentsTests
    {
        Present present1;
        Present present2;
        Bag bag;

         [SetUp]
        public void SetUp()
        {
            present1 = new Present("To", 10);
            present2 = new Present("Ko", 20);

            bag = new Bag();
        }

        [Test]
        public void TestPresent()
        {
            var newPresent = new Present("ToTo", 30.5);

            var expectedName = "ToTo";
            var expectedMagic = 30.5;

            Assert.AreEqual(expectedName, newPresent.Name);
            Assert.AreEqual(expectedMagic, newPresent.Magic);
        }

        [Test]
        public void TestConstructorBag()
        {
            var newBag = new Bag();

            Assert.IsNotNull(newBag.GetPresents());
        }

        [Test]
        public void TestCreateWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            });
        }

        [Test]
        public void TestCreateWithSamePresent()
        {
            bag.Create(present1);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present1);
            });
        }

        [Test]
        public void TestRemove()
        {
            bag.Create(present1);
            bag.Create(present2);

            bag.Remove(present1);
            var expectedCount = 1;

            Assert.AreEqual(expectedCount, bag.GetPresents().Count);
        }

        [Test]
        public void TestGetPresentWithLeastMagic()
        {
            bag.Create(present1);
            bag.Create(present2);

            var actualPresent = bag.GetPresentWithLeastMagic();
            var expectedPresent = present1;

            Assert.AreEqual(expectedPresent, actualPresent);
        }

        [Test]
        public void TestGetPresent()
        {
            bag.Create(present1);
            bag.Create(present2);

            var actualPresent = bag.GetPresent("To");
            var expectedPresent = present1;

            Assert.AreEqual(expectedPresent, actualPresent);
        }


    }
}
