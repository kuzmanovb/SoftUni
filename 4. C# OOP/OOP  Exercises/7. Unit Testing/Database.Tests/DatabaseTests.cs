using System;
using Database;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new int[] {})]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestConstructorAndCapacityMethod(int[] arr)
        {
            var data = new Database.Database(arr);

            var expectedCount = arr.Length;
            var actualCount = data.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestAddMethod()
        {
            var arr = new int[] { 1, 2, 3 };
            var data = new Database.Database(arr);

            data.Add(4);

            Assert.AreEqual(4, data.Count);
        }

        [Test]
        public void TestAddMethodWithFullCapacityArrayData()
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var data = new Database.Database(arr);

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(17);
            });
        }

        [Test]
        public void TestRemoveMethod()
        {
            var arr = new int[] { 1, 2, 3 };
            var data = new Database.Database(arr);

            data.Remove();

            var expextedCount = 2;
            var actualCount = data.Count;

            Assert.AreEqual(expextedCount, actualCount);
        }

        [Test]
        public void TestRemoveMethodWithEmptyData()
        {
            var arr = new int[] { };
            var data = new Database.Database(arr);

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Remove();
            });
        }

        [Test]
        public void TestFetchMethod()
        {
            var arr = new int[] {1, 2, 3 };
            var data = new Database.Database(arr);

            var actualData = data.Fetch();

            CollectionAssert.AreEqual(arr, actualData);
        }
    }
}