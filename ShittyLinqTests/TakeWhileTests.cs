using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;

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
    }
}
