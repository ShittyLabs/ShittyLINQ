using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System.Diagnostics;

namespace ShittyTests
{
    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void Reverse_ReturnsCorrectElements()
        {
            IEnumerable<int> numbers = new List<int> { 5, 6, 7 };
            var result = numbers.Reverse();
            var expected = new List<int> { 7, 6, 5 };

            TestHelper.AssertCollectionsAreSame(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Reverse_SourceIsNull()
        {
            IEnumerable<int> numbers = null;
            numbers.Reverse().ToList();
        }

        [TestMethod]
        public void Reverse_SourceIsEmpty()
        {
            IEnumerable<int> numbers = new List<int> { };
            var result = numbers.Reverse().ToList();

            Assert.AreEqual(0, numbers.Count());
        }
    }
}
