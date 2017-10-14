using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyTests
{
    [TestClass]
    public class AllTests
    {
        [TestMethod]
        public void All_OddNumbers()
        {
            IEnumerable<int> numbers = new[] { 1, 3, 5, 7, 9 };
            bool expected = true;

            bool actual = numbers.All(number => number % 2 == 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void All_OddNumbersWithOneEven()
        {
            IEnumerable<int> numbers = new[] { 1, 3, 4, 7, 9 };
            bool expected = false;

            bool actual = numbers.All(number => number % 2 == 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void All_ArgumentNullExceptionIfNoPredicate()
        {
            IEnumerable<int> numbers = Enumerable.Range(0, 5);

            Assert.ThrowsException<ArgumentNullException>(() => numbers.All(null));
        }
    }
}
