using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyLinqTests
{
    [TestClass]
    public class ToHashSetTests
    {
        [TestMethod]
        public void ToHashSet_SequenceIsNull()
        {
            IEnumerable<int> nums = null;
            Assert.ThrowsException<ArgumentNullException>(() => nums.ToHashSet());
        }

        [TestMethod]
        public void ToHashSet_SequenceEquals()
        {
            var expected = new int[] { 0, 1, 2 };
            var actual = expected.ToHashSet();
            TestHelper.AssertCollectionsAreSame(expected, actual);
        }
    }
}
