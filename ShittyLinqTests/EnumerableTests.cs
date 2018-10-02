using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class EnumerableTests
    {
        [TestMethod]
        public void Range_ReturnsIEnumerableFrom1To10()
        {
            IEnumerable<int> expectedNumbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var actualNumbers = Enumerable.Range(1, 10);

            TestHelper.AssertCollectionsAreSame(expectedNumbers, actualNumbers);
        }

        [TestMethod]
        public void Range_ArgumentOutOfRangeException()
        {
            // Over int.MaxValue
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Enumerable.Range(int.MaxValue, 2).ToList());

            // Negative count
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Enumerable.Range(0, -1).ToList());
        }

        [TestMethod]
        public void Repeat_Repeats5Times()
        {
            IEnumerable<int> expectedNumbers = new[] { 1, 1, 1, 1, 1 };

            var actualNumbers = Enumerable.Repeat(1, 5);

            TestHelper.AssertCollectionsAreSame(expectedNumbers, actualNumbers);
        }

        [TestMethod]
        public void Repeat_ArgumentOutOfRangeException()
        {
            // Negative count
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Enumerable.Repeat(1, -1).ToList());
        }
    }
}
