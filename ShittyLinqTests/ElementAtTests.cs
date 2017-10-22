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
        public void Element_ReturnsElementAtIndex()
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
        public void Element_EqualToCollectionCount()
        {
            int[] numbers = new int[] {0,1};


            long result = numbers.ElementAt(2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Element_GreaterThanCollectionCount()
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
