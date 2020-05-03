using System;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPartConstructor()
        {
            var part = new Part("RAM", 20.40M);

            Assert.AreEqual("RAM", part.Name);
            Assert.AreEqual(20.40, part.Price);

        }

        [Test]
        public void TestComputerConstructor()
        {
            var comp = new Computer("HP");

            Assert.AreEqual("HP", comp.Name);
            Assert.IsNotNull(comp.Parts);

        }

        [Test]
        public void TestComputerConstructorWithNull()
        {

            Assert.Throws<ArgumentNullException>(() =>
                {
                    var comp = new Computer(null);

                });
        }

        [Test]
        public void TestAddPart()
        {
            var part = new Part("RAM", 20.40M);
            var comp = new Computer("HP");

            comp.AddPart(part);

            Assert.AreEqual(1, comp.Parts.Count);
        }

        [Test]
        public void TestAddNullPart()
        {
            var comp = new Computer("HP");

            Assert.Throws<InvalidOperationException>(() =>
            {
                comp.AddPart(null);
            } );
        }

        [Test]
        public void TestTotalPrice()
        {
            var comp = new Computer("HP");
            var part1 = new Part("RAM", 20.40M);
            var part2 = new Part("CPU", 40.20M);

            comp.AddPart(part1);
            comp.AddPart(part2);

            Assert.AreEqual(60.60, comp.TotalPrice);

        }

        [Test]
        public void TestRemove()
        {
            var comp = new Computer("HP");
            var part1 = new Part("RAM", 20.40M);
            var part2 = new Part("CPU", 40.20M);
            var part3 = new Part("MB", 10.10M);

            comp.AddPart(part1);
            comp.AddPart(part2);

            Assert.AreEqual(true, comp.RemovePart(part1));
            Assert.AreEqual(false, comp.RemovePart(part3));

        }

        [Test]
        public void TestGetPart()
        {
            var comp = new Computer("HP");
            var part1 = new Part("RAM", 20.40M);
            var part2 = new Part("CPU", 40.20M);

            comp.AddPart(part1);
            comp.AddPart(part2);

            Assert.AreEqual(part1, comp.GetPart("RAM"));
            Assert.AreEqual(null, comp.GetPart("MB"));

        }

    }
}