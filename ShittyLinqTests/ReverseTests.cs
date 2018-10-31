using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void Reverse_ReturnsReversed()
        {
            List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = numberList.Reverse<int>().ToList();
            var expected = new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Skip_SourceIsNull()
        {
            List<int> numberList = null;

            numberList.Reverse<int>().ToList();
        }
    }
}
