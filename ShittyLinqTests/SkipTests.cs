using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class SkipTests
    {
        [TestMethod]
        public void Skip_ReturnsRemainingCollection()
        {
            List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = numberList.Skip(5).ToList();
            var expected = new List<int> { 6, 7, 8, 9 };

            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Skip_CountLessThanZero()
        {
            List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = numberList.Skip(-1).ToList();

            CollectionAssert.AreEqual(numberList, result);
        }
        [TestMethod]
        public void Skip_CountEqualsZero()
        {
            List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = numberList.Skip(0).ToList();            

            CollectionAssert.AreEqual(numberList, result);
        }

        [TestMethod]
        public void Skip_GreaterThanCollectionCount()
        {
            List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = numberList.Skip(15).ToList();
            var expected = new List<int>();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Skip_SourceIsNull()
        {
            List<int> numberList = null;

            numberList.Skip(4).ToList();
        }
    }
}
