using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class ToArrayTests
    {
        [TestMethod]
        public void ToArray_SequenceIsNull()
        {
            IEnumerable<int> nums = null;
            Assert.ThrowsException<ArgumentNullException>(() => nums.ToArray());
        }

        [TestMethod]
        public void ToArray_SequenceEquals()
        {
            IEnumerable<int> expected = new List<int> { 0, 1, 2 };
            int[] actual = expected.ToArray();
            TestHelper.AssertCollectionsAreSame(expected, actual);
        }

        [TestMethod]
        public void ToArray_SequenceIsEmpty()
        {
            IEnumerable<int> expected = new List<int>();
            int[] actual = expected.ToArray();
            TestHelper.AssertCollectionsAreSame(expected, actual);
        }
    }
}
