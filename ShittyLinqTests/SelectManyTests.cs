using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyTests
{
    [TestClass]
    public class SelectManyTests
    {
        [TestMethod]
        public void SelectMany_Flatten()
        {
            IEnumerable<IEnumerable<int>> numbers = new[] { new[] { 1, 2, 3 }, new[] { 4 } };
            IEnumerable<int> expected = new[] { 1, 2, 3, 4 };

            IEnumerable<int> actual = numbers.SelectMany(i => i);

            TestHelper.AssertCollectionsAreSame(expected, actual);
        }

        [TestMethod]
        public void SelectMany_ThrowsArgumentNullException()
        {
            IEnumerable<IEnumerable<int>> numbers = null;

            Assert.ThrowsException<ArgumentNullException>(() => numbers.SelectMany(i => i));

            numbers = new[] { new[] { 1, 2, 3 } };
            Func<IEnumerable<int>, IEnumerable<int>> selector = null;

            Assert.ThrowsException<ArgumentNullException>(() => numbers.SelectMany(selector));
        }
    }
}
