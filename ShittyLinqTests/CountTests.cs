using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
    [TestClass]
    public class CountTests
    {
        [TestMethod]
        public void Count_Numbers()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            long expectedResult = 5;

            long result = numbers.Count();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Count_SourceIsEmpty()
        {
            int[] numbers = new int[] { };
            long expectedResult = 0;

            long result = numbers.Count();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Count_SourceIsNull()
        {
            int[] numbers = null;

            long result = numbers.Count();
        }
    }
}
