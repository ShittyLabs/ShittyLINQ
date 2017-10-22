using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class TakeTests
    {
        [TestMethod]
        public void Take_ReturnsCorrectElements()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var result = numbers.Take(3).ToList();
            var expected = new List<int> { 1, 2, 3 };

            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Take_CountIsGreaterThanCollection()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var result = numbers.Take(10).ToList();

            CollectionAssert.AreEqual(numbers, result);
        }
        [TestMethod]
        public void Take_CountIsLessThanZero()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var result = numbers.Take(-1).ToList();
            List<int> expectedResult = new List<int>();

            CollectionAssert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void Take_CountIsZero()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var result = numbers.Take(0).ToList();
            List<int> expectedResult = new List<int>();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Take_SourceIsNull()
        {
            int[] numbers = null;

            var result = numbers.Take(5).ToList();
        }
    }
}
