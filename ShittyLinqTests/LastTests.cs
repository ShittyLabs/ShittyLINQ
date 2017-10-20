using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
    [TestClass]
    public class LastTests
    {
        [TestMethod]
        public void Last_GetLastNumber()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int expectedResult = 5;

            int result = numbers.Last();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Last_SourceIsEmpty()
        {
            int[] numbers = { };

            int result = numbers.Last();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Last_SourceIsNull()
        {
            int[] numbers = null;

            int result = numbers.Last();
        }
    }
}