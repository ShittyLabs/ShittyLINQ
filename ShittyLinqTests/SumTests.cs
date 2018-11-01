using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyTests
{
    [TestClass]
    public class SumTests
    {
        [TestMethod]
        public void Sum_ThrowsExceptionWhenSourceIsNull()
        {
            List<int> numberList = null;
            Assert.ThrowsException<ArgumentNullException>(() => numberList.Sum());
        }

        [TestMethod]
        public void Sum_EmptyListReturnsZero()
        {
            List<int> numberList = new List<int>();
            var result = numberList.Sum();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Sum_SumReturnsTheRightValue()
        {
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = numberList.Sum();
            Assert.AreEqual(45, result);
        }
    }
}
