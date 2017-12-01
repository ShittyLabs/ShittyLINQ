using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;

namespace ShittyTests
{
    [TestClass]
    public class FirstOrDefaultTests
    {
        [TestMethod]
        public void FirstOrDefault_GetFirstNumber()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int expectedResult = 1;

            int result = numbers.FirstOrDefault();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FirstOrDefault_SourceIsEmpty()
        {
            int[] numbers = { };
            int expected = 0;

            Assert.AreEqual(numbers.FirstOrDefault(), expected);
        }

        [TestMethod]
        public void FirstOrDefault_SourceIsEmpty_WithCustomDefaultValue()
        {
            int[] numbers = { };
            int defaultValue = 42;
            int expected = defaultValue;

            Assert.AreEqual(numbers.FirstOrDefault(defaultValue), expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstOrDefault_SourceIsNull()
        {
            int[] numbers = null;

            int result = numbers.FirstOrDefault();
        }
    }
}
