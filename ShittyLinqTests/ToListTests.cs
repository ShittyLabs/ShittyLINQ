using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyLinqTests
{
    [TestClass]
    public class ToListTests
    {
        [TestMethod]
        public void ToList_SequenceIsNull()
        {
            IEnumerable<int> nums = null;
            Assert.ThrowsException<ArgumentNullException>(() => nums.ToList());
        }

        [TestMethod]
        public void ToList_SequenceEquals()
        {
            var expected = new int[] { 0, 1, 2 };
            var actual = expected.ToList();
            TestHelper.AssertCollectionsAreSame(expected, actual);
        }
    }
}
