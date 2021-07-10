using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
    [TestClass]
    public class SingleTests
    {
        [TestMethod]
        public void Single_GetSingleNumber()
        {
            int[] numbers = new int[] { 1 };
            int expectedResult = 1;

            int result = numbers.Single();

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void Single_GetSingleNumber_Predicate()
        {
            int[] numbers = new int[] { 1, 1, 1, 2 };
            int expectedResult = 2;

            int result = numbers.Single(x => x == 2);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Single_SourceIsEmpty()
        {
            int[] numbers = new int[] { };

            int result = numbers.Single();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Single_MoreThanOne()
        {
            int[] numbers = new int[] { 1, 1 };

            int result = numbers.Single();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Single_Predicate_MoreThanOne()
        {
            int[] numbers = new int[] { 1, 1, 1, 2, 2 };

            int result = numbers.Single(x => x == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Single_Predicate_Empty()
        {
            int[] numbers = new int[] { 1, 1, 1, 2, 2 };

            int result = numbers.Single(x => x == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Single_SourceIsNull()
        {
            int[] numbers = null;

            int result = numbers.First();
        }
    }
}
