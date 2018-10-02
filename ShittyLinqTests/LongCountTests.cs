using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
    [TestClass]
    public class LongCountTests
    {
        [TestMethod]
        public void LongCount_Numbers()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            long expectedResult = 5;

            long result = numbers.LongCount();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void LongCount_SourceIsEmpty()
        {
            int[] numbers = new int[] { };
            long expectedResult = 0;

            long result = numbers.LongCount();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LongCount_SourceIsNull()
        {
            int[] numbers = null;

            long result = numbers.LongCount();
        }
    }
}
