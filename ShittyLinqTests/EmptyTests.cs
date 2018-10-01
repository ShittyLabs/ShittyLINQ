using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;

namespace ShittyTests
{
    [TestClass]
    public class EmptyTests
    {

        [TestMethod]
        public void EmptyReturnsAnEmptyEnumerable ()
        {
            var emptyStringEnum = Enumerable.Empty<string> ();

            Assert.AreEqual (emptyStringEnum.Count (), 0);
        }

        [TestMethod]
        public void EmptyComparisonIsTrue ()
        {
            IEnumerable<decimal> someEnumerable = new List<decimal> ();
            var testEnum = Enumerable.Empty<decimal> ();

            TestHelper.AssertCollectionsAreSame (someEnumerable, testEnum);
        }

    }
}
