using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class ElementAtTests
    {
        [TestMethod]
        public void Element_ReturnsElemetAtIndex()
        {
            List<int> numbers = new List<int> {0,1,2,3,4,5,6};
            var expected = numbers[4];
            var result = numbers.ElementAt(4);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Element_IndexLessThanZero()
        {
            int[] numbers = new int[] { };

            long result = numbers.ElementAt(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Element_EqualToColletionCount()
        {
            int[] numbers = new int[] {0,1};


            long result = numbers.ElementAt(2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Element_GreaterThanColletionCount()
        {
            int[] numbers = new int[] { 0, 1 };


            long result = numbers.ElementAt(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Element_SourceIsNull()
        {
            int[] numbers = null;

            long result = numbers.ElementAt(5);
        }
    }
}
