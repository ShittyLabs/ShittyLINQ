using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ShittyTests
{
    [TestClass]
    public class SingleOrDefaultTests
    {
        [TestMethod]
        public void SingleOrDefault_ReturnsTheFirstElementIfCollectionIsNotEmpty()
        {
            var expected = 42;
            var collection = new int[] { 42, 1, 99 };

            var first = collection.FirstOrDefault();
            Assert.AreEqual(expected, first);
        }

        [TestMethod]
        public void SingleOrDefault_ReturnsDefaultValueIfCollectionIsEmpty()
        {
            var collection = new int[] { };

            var first = collection.FirstOrDefault();
            Assert.AreEqual(default(int), first);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SingleOrDefault_ThrowsIfSourceIsNull()
        {
            IOrderedEnumerable<int> collection = null;
            var first = collection.FirstOrDefault();
        }
    }
}
