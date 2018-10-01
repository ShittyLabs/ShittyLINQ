using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
    [TestClass]
    public class ContainsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsElementIsNull()
        {
            string[] numbers = new string[] { };

            bool result = numbers.Contains<string>(null);
        }

        [TestMethod]
        public void ContainsNumber()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            bool expectedResult = true;

            bool result = numbers.Contains<int>(5);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ContainsSourceIsEmpty()
        {
            int[] numbers = new int[] { };
            bool expectedResult = false;

            bool result = numbers.Contains<int>(3);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsSourceIsNull()
        {
            int[] numbers = null;

            bool result = numbers.Contains<int>(7);
        }

        [TestMethod]
        public void DoesNotContainsNumber()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            bool expectedResult = false;

            bool result = numbers.Contains<int>(6);

            Assert.AreEqual(expectedResult, result);
        }
    }
}