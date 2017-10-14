using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class AggregateTests
    {
        [TestMethod]
        public void Aggregate_SumResult()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int expectedResult = 1 + 2 + 3 + 4 + 5;

            int result = numbers.Aggregate(0, (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Aggregate_ConcatenateStringResult()
        {
            string[] words = new string[] { "This ", "is ", "a ", "test." };
            string expectedResult = "This is a test.";

            string result = words.Aggregate("", (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Aggregate_ProcessObjects()
        {
            List<Person> people = TestHelper.GetPeople();
            int expectedDevCount = 34;

            int devCount = people.Aggregate(0, (x, y) => x += y.Job == "Dev" ? 1 : 0);

            Assert.AreEqual(expectedDevCount, devCount);
        }

        [TestMethod]
        public void Aggregate_SeedValueIsMoreThanZero()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int expectedResult = 10 + 1 + 2 + 3 + 4 + 5;

            int result = numbers.Aggregate(10, (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Aggregate_AccumulatorIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            int result = numbers.Aggregate(10, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Aggregate_SeedIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int? expectedResult = null;

            int? result = numbers.Aggregate<int, int?>(null, (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Aggregate_SourceIsEmpty()
        {
            int[] numbers = new int[] { };
            int expectedResult = 0;

            int result = numbers.Aggregate(0, (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Aggregate_SourceIsNull()
        {
            int[] numbers = null;

            int result = numbers.Aggregate(0, (x, y) => x + y);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Aggregate_CollectionHasBeenModified()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            int result = numbers.Aggregate(0, (x, y) =>
            {
                numbers.Remove(x);
                return y;
            });
        }
    }
}
