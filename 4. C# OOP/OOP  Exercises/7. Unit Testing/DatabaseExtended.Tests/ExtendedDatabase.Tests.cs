using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        Person p1;
        Person p2;
        Person p3;
        Person p4;
        Person p5;
        Person p6;
        Person p7;
        Person p8;
        Person p9;
        Person p10;
        Person p11;
        Person p12;
        Person p13;
        Person p14;
        Person p15;
        Person p16;
        Person p17;
        Person p18;

        ExtendedDatabase.ExtendedDatabase data;
        ExtendedDatabase.ExtendedDatabase dataEmpty;

        [SetUp]
        public void Setup()
        {
            p1 = new Person(1, "A");
            p2 = new Person(2, "B");
            p3 = new Person(3, "C");
            p4 = new Person(4, "D");
            p5 = new Person(5, "F");
            p6 = new Person(6, "T"); 
            p7 = new Person(7, "E");
            p8 = new Person(8, "O");
            p9 = new Person(9, "Z");
            p10 = new Person(10, "X");
            p11 = new Person(11, "V");
            p12 = new Person(12, "N"); 
            p13 = new Person(13, "M");
            p14 = new Person(14, "L");
            p15 = new Person(15, "K");
            p16 = new Person(16, "I");
            p17 = new Person(17, "A"); // Same name with p1
            p18 = new Person(1, "W"); // Same Id with p1

            dataEmpty = new ExtendedDatabase.ExtendedDatabase();
            data = new ExtendedDatabase.ExtendedDatabase(p1, p2, p3);
        }

        [Test]
        public void TestPerson()
        {
            var newPerson = new Person(123, "Pesho");

            var expectedId = 123;
            var expectedName = "Pesho";

            Assert.AreEqual(expectedId, newPerson.Id);
            Assert.AreEqual(expectedName, newPerson.UserName);
        }

        [Test]
        public void TestConstructor()
        {
            var expectedCount = 3;
            
            Assert.AreEqual(expectedCount, data.Count);
            Assert.IsNotNull(dataEmpty);
        }

        [Test]
        public void TestAddRangeMethodAndCount()
        {
            var expectCount = 3;

            Assert.AreEqual(expectCount, data.Count);
        }

        [Test]
        public void TestAddRangeMethodWithOverRange ()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var data2 = new ExtendedDatabase.ExtendedDatabase(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17);
            });
        }
        [Test]
        public void TestAddMethod()
        {
            data.Add(p4);

            var expectCount = 4;

            Assert.AreEqual(expectCount, data.Count);
        }

        [Test]
        public void TestAddMethodWithFullRange()
        {
            var data3 = new ExtendedDatabase.ExtendedDatabase(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);

            Assert.Throws<InvalidOperationException>(() =>
            {
                data3.Add(p17);
            });
        }
        [Test]
        public void TestAddMethodWithSameUserName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(p17); // Same name with p1
            });
        }
        [Test]
        public void TestAddMethodWithSameId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(p18); // Same Id with p1
            });
        }

        [Test]
        public void TestRemoveMethod()
        {
            data.Remove();
            var expectCount = 2;

            Assert.AreEqual(expectCount, data.Count);
        }
        [Test]
        public void TestRemoveMethodWithEmptyData()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dataEmpty.Remove();
            });
        }

        [TestCase("")]
        [TestCase(null)]
        
        public void TestFindByUsernameWithNullOrEmptyName(string arg)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                data.FindByUsername(arg);
            });
        }

        [Test]
        public void TestFindByUsernameWithNoExistedName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                data.FindByUsername("Pesho");
            });
        }

        [Test]
        public void TestFindByUsername()
        {
            var expectUser = p1;

            var actualUser = data.FindByUsername("A");

            Assert.AreEqual(expectUser, actualUser);
        }

        [Test]
        public void TestFindByIdWithNegativeNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                data.FindById(-1);
            });
        }

        [Test]
        public void TestFindByIdWithNoExistedId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                data.FindById(5);
            });
        }

        [Test]
        public void TestFindById()
        {
            var expectUser = p1;

            var actualUser = data.FindById(1);

            Assert.AreEqual(expectUser, actualUser);
        }
    }
}