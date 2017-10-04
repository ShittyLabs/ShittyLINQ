using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class ForeachTests
    {
        [TestMethod]
        public void Foreach_IncreaseNumbersWithOneAndRecord()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int[] expectedResult = new int[] { 2, 3, 4, 5, 6 };

            List<int> resultCollection = new List<int>();
            numbers.ForEach(x => resultCollection.Add(x + 1));

            TestHelper.AssertCollectionsAreSame(expectedResult, resultCollection);
        }

        [TestMethod]
        public void Foreach_SourceIsEmpty()
        {
            int[] numbers = new int[] { };
            int[] expectedResult = new int[] { };

            List<int> resultCollection = new List<int>();
            numbers.ForEach(x => resultCollection.Add(x + 1));

            TestHelper.AssertCollectionsAreSame(expectedResult, resultCollection);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Foreach_SourceIsNull()
        {
            int[] numbers = null;

            List<int> resultCollection = new List<int>();
            numbers.ForEach(x => resultCollection.Add(x + 1));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Foreach_CollectionHasBeenModified()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            numbers.ForEach(x => numbers.Remove(x));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Foreach_ActionIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int[] expectedResult = new int[] { 2, 3, 4, 5, 6 };

            List<int> resultCollection = new List<int>();
            numbers.ForEach(null);
        }
    }
}
