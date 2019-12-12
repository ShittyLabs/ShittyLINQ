using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            var collection = new int[] { 42 };

            var first = collection.SingleOrDefault();
            Assert.AreEqual(expected, first);
        }

        [TestMethod]
        public void SingleOrDefault_ReturnsDefaultValueIfCollectionIsEmpty()
        {
            var collection = new int[] { };

            var first = collection.SingleOrDefault();
            Assert.AreEqual(default(int), first);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SingleOrDefault_ThrowsIfSourceIsNull()
        {
            IEnumerable<int> collection = null;
            var first = collection.SingleOrDefault();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SingleOrDefault_ThrowsIfMoreThanOneElementInSequence()
        {
            var collection = new int[] { 42, 24 };
            var first = collection.SingleOrDefault();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SingleOrDefault_SecondOverloadThrowsIfSourceIsNull()
        {
            IEnumerable<int> collection = null;
            var first = collection.SingleOrDefault(i => i > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SingleOrDefault_SecondOverloadThrowsIfPredicateIsNull()
        {
            IEnumerable<int> collection = new int[] { 42 };
            var first = collection.SingleOrDefault(null);
        }

        [TestMethod]
        public void SingleOrDefault_SecondOverloadReturnsTheFirstElementIfCollectionIsNotEmpty()
        {
            var expected = 42;
            var collection = new int[] { 42, 142, 242 };

            var first = collection.SingleOrDefault(i => i < 100);
            Assert.AreEqual(expected, first);
        }

        [TestMethod]
        public void SingleOrDefault_SecondOverloadReturnsDefaultValueIfCollectionIsEmpty()
        {
            var collection = new int[] { 142, 242 };

            var first = collection.SingleOrDefault(i => i < 100);
            Assert.AreEqual(default(int), first);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SingleOrDefault_SecondOverloadThrowsIfMoreThanOneElementInSequence()
        {
            var collection = new int[] { 42, 24 };
            var first = collection.SingleOrDefault(i => i < 100);
        }
    }
}
