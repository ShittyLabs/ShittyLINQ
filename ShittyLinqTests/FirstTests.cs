using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
    [TestClass]
    public class FirstTests
    {
        [TestMethod]
        public void First_GetFirstNumber()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int expectedResult = 1;

            int result = numbers.First();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void First_SourceIsEmpty()
        {
            int[] numbers = new int[] { };

            int result = numbers.First();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void First_SourceIsNull()
        {
            int[] numbers = null;

            int result = numbers.First();
        }
    }
}
