using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class TakeLastTests
    {
        [TestMethod]
        public void When_Count_Is_Greather_Than_Element_In_List_Then_Throw_OutOfRange_Exception()
        {
            var list = new List<int> { 1, 2, 3, 4 };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.TakeLast(5).ToList());
        }

        [TestMethod]
        public void When_List_Is_Null_Then_Throw_Exception()
        {
            IEnumerable<int> list = null;

            Assert.ThrowsException<ArgumentNullException>(() => list.TakeLast(5).ToList());
        }

        [TestMethod]
        public void When_Take_Last_Five_Elements_Then_Should_Return_List_Of_Five()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var expectedList = new List<int> { 3, 4, 5, 6, 7 };

            var lastFiveElements = list.TakeLast(5).ToList();

            Assert.IsTrue(lastFiveElements.Count == 5);
            CollectionAssert.AreEqual(expectedList, lastFiveElements);

        }

        [TestMethod]
        public void When_Take_Last_Five_Elements_In_List_Of_Five_Then_Should_Return_Same_List()
        {
            var list = new List<int> { 3, 4, 5, 6, 7 };
            var expectedList = new List<int> { 3, 4, 5, 6, 7 };

            var lastFiveElements = list.TakeLast(5).ToList();

            Assert.IsTrue(lastFiveElements.Count == 5);
            CollectionAssert.AreEqual(expectedList, lastFiveElements);

        }
    }
}
