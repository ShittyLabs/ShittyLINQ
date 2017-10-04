using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
    [TestClass]
    public class MaxTests
    {
        [TestMethod]
        public void Max_LargestNumber()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int expectedResult = 5;

            int result = numbers.Max((x) => x);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Max_LongestString()
        {
            string[] words = new string[] { "bc", "b", "a", "aa", "abc" };
            int expectedResult = 3;

            int result = words.Max((x) => { return x.Length; });

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Max_CollectionIsEmpty()
        {
            int[] numbers = new int[] { };

            int result = numbers.Max((x) => x);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Max_CollectionIsNull()
        {
            int[] numbers = null;

            int result = numbers.Max((x) => x);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Max_SelectorIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            int result = numbers.Max(null);
        }
    }
}
