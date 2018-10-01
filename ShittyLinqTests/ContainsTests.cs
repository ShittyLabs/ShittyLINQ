using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyTests
{
    [TestClass]
    public class ContainsTests
    {
        [TestMethod]
        public void Contains_Numbers()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(numbers.Contains(3));
        }

        [TestMethod]
        public void Not_Contains_Number()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            Assert.IsFalse(numbers.Contains(7));
        }

        [TestMethod]
        public void Contains_Numbers_With_Comparer()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(numbers.Contains(3, EqualityComparer<Int32>.Default));
        }

    }
}
