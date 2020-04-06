namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestConstructor()
        {
            var newPhon = new Phone("Samsung", "S");

            var expectedName = "Samsung";
            var expectedModel = "S";

            Assert.AreEqual(expectedName, newPhon.Make);
            Assert.AreEqual(expectedModel, newPhon.Model);
            Assert.IsNotNull(newPhon.Count);
        }

        [Test]
        public void TestMakeSeter()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var newPhon = new Phone(null, "S");
            });
        }

        [Test]
        public void TestModelSeter()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var newPhon = new Phone("Samsung", null);
            });
        }

        [Test]
        public void TestAddContact()
        {
            var newPhon = new Phone("Samsung", "S");
           
            newPhon.AddContact("Gosho", "1234");

            Assert.AreEqual(1, newPhon.Count);
            
        }

        [Test]
        public void TestAddContactWithExistsPerson()
        {
            var newPhon = new Phone("Samsung", "S");

            newPhon.AddContact("Gosho", "1234");

            Assert.Throws<InvalidOperationException>(() => 
            {
                newPhon.AddContact("Gosho", "1234");
            });

        }

        [Test]
        public void TestCallWhitNevalideName()
        {
            var newPhon = new Phone("Samsung", "S");

            var expectedName = "Gosho";
            var expectedPhone = "1234";
            newPhon.AddContact("Gosho", "1234");

            Assert.Throws<InvalidOperationException>(() =>
            {
                newPhon.Call("Pesho");
            });

        }

        [Test]
        public void TestCall()
        {
            var newPhon = new Phone("Samsung", "S");

            newPhon.AddContact("Gosho", "1234");

            var expectedName = "Gosho";
            var expectedPhone = "1234";

            var proba = newPhon.Call("Gosho");

            Assert.AreEqual(proba, $"Calling {expectedName} - {expectedPhone}...");
        }

    }
}