using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections;

namespace ShittyTests
{
    [TestClass]
    public class OfTypeTests
    {
        [TestMethod]
        public void OfType_FiltersItemsBasedOnType()
        {
            var items = new object[] { 1, "hello", 8, 24.12d, 89.15f, 62.8m, new object() };
            var expected = new int[] { 1, 8 };
            var ints = items.OfType<int>();

            TestHelper.AssertCollectionsAreSame(expected, ints);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OfType_ThrowsIfSourceSequenceIsEmpty()
        {
            IEnumerable items = null;
            var ints = items.OfType<int>()?.ToList();
        }
    }
}
