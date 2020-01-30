using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class OfTypeTests
    {
        [TestMethod]
        public void OfType_OfTypeFound()
        {
            object[] numbers = new object[] { 1, 2, 3, 4, 5 };
            int expectedResult = 5;

            IEnumerable<int> result = numbers.OfType<int>();

            Assert.AreEqual(expectedResult, result.Count());
        }

        [TestMethod]
        public void OfType_OfTypeNotFound()
        {
            object[] numbers = new object[] { 1, 2, 3, 4, 5 };
            int expectedResult = 0;

            IEnumerable<string> result = numbers.OfType<string>();

            Assert.AreEqual(expectedResult, result.Count());
        }

        [TestMethod]
        public void OfType_OfTypeSomeFound()
        {
            object[] numbers = new object[] { 1, 2, "3", 4, 5 };
            int expectedResult = 1;

            IEnumerable<string> result = numbers.OfType<string>();

            Assert.AreEqual(expectedResult, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OfType_SourceIsNull()
        {
            int[] numbers = null;

            IEnumerable<int> result = numbers.OfType<int>();
        }
    }
}
