using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class ElementAtOrDefaultTests
    {
        [TestMethod]
        public void Element_ReturnsElementAtIndex()
        {
            List<int> numbers = new List<int> {0,1,2,3,4,5,6};
            var expected = numbers[4];
            var result = numbers.ElementAtOrDefault(4);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Element_IndexLessThanZero()
        {
            int[] numbers = { };

            long result = numbers.ElementAtOrDefault(-1);

            Assert.AreEqual(default(long), result);
        }

        [TestMethod]
        public void Element_EqualToCollectionCount()
        {
            int[] numbers = {0,1};

            long result = numbers.ElementAtOrDefault(2);

            Assert.AreEqual(default(long), result);
        }

        [TestMethod]
        public void Element_GreaterThanCollectionCount()
        {
            int[] numbers = { 0, 1 };

            long result = numbers.ElementAtOrDefault(3);

            Assert.AreEqual(default(long), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Element_SourceIsNull()
        {
            int[] numbers = null;

            long result = numbers.ElementAtOrDefault(5);
        }
    }
}
