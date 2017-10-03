using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class FoldlTests
    {

        [TestMethod]
        public void Foldl_SumResult()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int expectedResult = 1 + 2 + 3 + 4 + 5;

            int result = numbers.Foldl(0, (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Foldl_ConcatenateStringResult()
        {
            string[] words = new string[] { "This ", "is ", "a ", "test." };
            string expectedResult = "This is a test.";

            string result = words.Foldl("", (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Foldl_ProcessObjects()
        {
            List<Person> people = TestHelper.GetPeople();
            int expectedDevCount = 34;

            int devCount = people.Foldl(0, (x, y) => x += y.Job == "Dev" ? 1 : 0);

            Assert.AreEqual(expectedDevCount, devCount);
        }

        [TestMethod]
        public void Foldl_MemoValueIsMoreThanZero()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int expectedResult = 10 + 1 + 2 + 3 + 4 + 5;

            int result = numbers.Foldl(10, (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Foldl_AccumulatorIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            int result = numbers.Foldl(10, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Foldl_MemoIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int? expectedResult = null;

            int? result = numbers.Foldl<int, int?>(null, (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Foldl_SourceIsEmpty()
        {
            int[] numbers = new int[] { };
            int expectedResult = 0;

            int result = numbers.Foldl(0, (x, y) => x + y);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Foldl_SourceIsNull()
        {
            int[] numbers = null;

            int result = numbers.Foldl(0, (x, y) => x + y);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Foldl_CollectionHasBeenModified()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            int result = numbers.Foldl(0, (x, y) =>
            {
                numbers.Remove(x);
                return y;
            });
        }
    }
}
