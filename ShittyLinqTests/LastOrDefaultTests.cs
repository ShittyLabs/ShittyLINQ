using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;

namespace ShittyTests
{
    [TestClass]
    public class LastOrDefaultTests
    {
        [TestMethod]
        public void LastOrDefault_GetLastNumber()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int expectedResult = 5;

            int result = numbers.LastOrDefault();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void LastOrDefault_SourceIsEmpty()
        {
            int[] numbers = { };
            int expected = 0;

            Assert.AreEqual(numbers.LastOrDefault(), expected);
        }

        [TestMethod]
        public void LastOrDefault_SourceIsEmpty_WithCustomDefaultValue()
        {
            int[] numbers = { };
            int defaultValue = 42;
            int expected = defaultValue;

            Assert.AreEqual(numbers.LastOrDefault(defaultValue), expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastOrDefault_SourceIsNull()
        {
            int[] numbers = null;

            int result = numbers.LastOrDefault();
        }
    }
}
