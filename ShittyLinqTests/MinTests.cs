using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;

namespace ShittyTests
{
    [TestClass]
    public class MinTests
    {
        [TestMethod]
        public void Min_LargestNumber()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int expectedResult = 1;

            int result = numbers.Min(x => x);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Min_ShortestString()
        {
            string[] words = { "bc", "b", "a", "aa", "abc" };
            int expectedResult = 1;

            int result = words.Min(x => x.Length);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Min_CollectionIsEmpty()
        {
            int[] numbers = { };

            int result = numbers.Min(x => x);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Min_CollectionIsNull()
        {
            int[] numbers = null;

            int result = numbers.Min(x => x);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Min_SelectorIsNull()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            int result = numbers.Min(null);
        }
    }
}
