using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
  [TestClass]
  public class SkipLastTests
  {
    [TestMethod]
    public void SkipLast_ReturnsBeginOfCollection()
    {
      List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      var result = numberList.SkipLast(5).ToList();
      var expected = new List<int> { 1, 2, 3, 4 };

      CollectionAssert.AreEqual(expected, result);
    }
    [TestMethod]
    public void SkipLast_CountLessThanZero()
    {
      List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      var result = numberList.SkipLast(-1).ToList();

      CollectionAssert.AreEqual(numberList, result);
    }
    [TestMethod]
    public void SkipLast_CountEqualsZero()
    {
      List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      var result = numberList.SkipLast(0).ToList();

      CollectionAssert.AreEqual(numberList, result);
    }

    [TestMethod]
    public void SkipLast_GreaterThanCollectionCount()
    {
      List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      var result = numberList.SkipLast(15).ToList();
      var expected = new List<int>();

      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SkipLast_EqualToCollectionCount()
    {
      List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      var result = numberList.SkipLast(9).ToList();
      var expected = new List<int>();

      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SkipLast_SourceIsNull()
    {
      List<int> numberList = null;

      numberList.SkipLast(4).ToList();
    }
  }
}
