using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;

namespace ShittyLinqTests
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
        public void ToArray_SequenceEqual()
        {
            var expected = new int[]{1,2,3,4};
            var actual = expected.ToArray();
            TestHelper.AssertCollectionsAreSame<int>(expected,actual);
        }
    }
}