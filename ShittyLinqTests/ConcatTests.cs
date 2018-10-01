using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;

namespace ShittyTests
{
    [TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void Concat_SourceSequenceIsNull()
        {
            IEnumerable<int> source = null;
            IEnumerable<int> input = new List<int>();
            Assert.ThrowsException<ArgumentNullException>(() => source.Concat(input));
        }

        [TestMethod]
        public void Concat_InputSequenceIsNull()
        {
            IEnumerable<int> source = new List<int>();
            IEnumerable<int> input = null;
            Assert.ThrowsException<ArgumentNullException>(() => source.Concat(input));
        }

        [TestMethod]
        public void Concat_SequenceEquals()
        {
            var expected = new int[] { 0, 1, 2, 3, 4, 5 };
            var source = new int[] { 0, 1, 2 };
            var input = new int[] { 3, 4, 5 };
            var actual = source.Concat(input);
            TestHelper.AssertCollectionsAreSame(expected, actual);
        }
    }
}
