using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class TakeWhileTests
    {
        [TestMethod]
        public void TakeWhile_ReturnsASubsetIfConditionBecomesFalse()
        {
            var expected = new int[] { 1, 5, 6, 9 };
            var items = new int[] { 1, 5, 6, 9, -2, 1, 5 };

            var actual = items.TakeWhile(e => e > 0);
            var actual2 = items.TakeWhile((e, i) => e > 0);
            TestHelper.AssertCollectionsAreSame(expected, actual);
            TestHelper.AssertCollectionsAreSame(expected, actual2);
        }

        [TestMethod]
        public void TakeWhile_ReturnsAllElementsIfConditionIsMetUntilTheEnd()
        {
            var expected = new int[] { 1, 1, 99, 534, 123 };
            var items = new int[] { 1, 1, 99, 534, 123 };

            var actual = items.TakeWhile(e => e > 0);
            var actual2 = items.TakeWhile((e, i) => e > 0);

            TestHelper.AssertCollectionsAreSame(expected, actual);
            TestHelper.AssertCollectionsAreSame(expected, actual2);
        }

        [TestMethod]
        public void TakeWhile_PassedIndexIsCorrect()
        {
            var expected = new int[] { 0, 1, 2, 3, 4, 5 };
            var items = new int[] { 0, 1, 2, 3, 4, 5 };

            var actual = items.TakeWhile((e, i) => i == e);
            TestHelper.AssertCollectionsAreSame(expected, actual);
        }

        [TestMethod]
        public void TakeWhile_ReturnsNoneIfConditionIsNeverMet()
        {
            var expected = new int[] { };
            var items = new int[] { 1, 1, 99, 534, 123 };

            var actual = items.TakeWhile(e => e < 0);
            var actual2 = items.TakeWhile((e, i) => e < 0);

            Assert.AreEqual(actual.Count(), 0);
            Assert.AreEqual(actual2.Count(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TakeWhile_ThrowsIfSourceIsNull()
        {
            IEnumerable<int> items = null;
            items.TakeWhile(e => e > 5)?.ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TakeWhile_ThrowsIfPredicateIsNull()
        {
            IEnumerable<int> items = new int[] { 1, 6, 8, 10 };
            Func<int, bool> predicate = null;
            items.TakeWhile(predicate)?.ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TakeWhile_SecondOverloadThrowsIfSourceIsNull()
        {
            IEnumerable<int> items = null;
            items.TakeWhile((e, i) => e > 5)?.ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TakeWhile_SecondOverloadThrowsIfPredicateIsNull()
        {
            IEnumerable<int> items = new int[] { 1, 6, 8, 10 };
            Func<int, int, bool> predicate = null;
            items.TakeWhile(predicate)?.ToList();
        }
    }
}
