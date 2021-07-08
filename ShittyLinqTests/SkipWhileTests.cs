using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
  [TestClass]
  public class SkipWhileTests
  {
    [TestMethod]
    public void SkipWhile_ReturnsRemainingCollection()
    {
      List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 3 };
      bool predicate(int i) => i >= 6;
      var expected = new List<int> { 1, 2, 3, 4, 5, 3 };

      var result = numberList.SkipWhile(predicate).ToList();

      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SkipWhile_ReturnsEmptyCollection()
    {
      List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      bool predicate(int i) => i >= 1;
      var expected = new List<int> { };

      var result = numberList.SkipWhile(predicate).ToList();

      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SkipWhile_ReturnsFullCollection()
    {
      List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      bool predicate(int i) => i >= 10;

      var result = numberList.SkipWhile(predicate).ToList();

      CollectionAssert.AreEqual(numberList, result);
    }

    [TestMethod]
    public void SkipWhile_ReturnsFilteredCollection()
    {
      List<int> numberList = new List<int> { 5000, 2500, 9000, 8000, 6500, 4000, 1500, 5500 };
      bool predicate(int i, int index) => i > index * 1000;
      var expected = new List<int> { 4000, 1500, 5500 };

      var result = numberList.SkipWhile(predicate).ToList();

      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SkipWhile_SourceIsNull()
    {
      List<int> numberList = null;

      numberList.Skip(4).ToList();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SkipWhile_PredicateIsNull()
    {
      List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      Func<int, bool> predicate = null;

      numberList.SkipWhile(predicate).ToList();
    }
  }
}
