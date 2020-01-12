using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyTests
{
  [TestClass]
  public class SingleTests
  {
    [TestMethod]
    public void Single_GetSingleElement()
    {
      int[] numbers = new int[] { 1 };
      int expectedResult = 1;

      int result = numbers.Single();

      Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Single_GetMatchingSingleElement()
    {
      int[] numbers = new int[] { 1, 2 };
      bool predicate(int i) => i == 1;
      int expectedResult = 1;

      int result = numbers.Single(predicate);

      Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Single_SourceIsNull()
    {
      int[] numbers = null;

      int result = numbers.Single();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Single_PredicateIsNull()
    {
      int[] numbers = new int[] { 1 };
      Func<int, bool> predicate = null;

      int result = numbers.Single(predicate);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Single_SourceIsEmpty()
    {
      int[] numbers = new int[] { };

      int result = numbers.Single();
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Single_SourceIsEmptyWithPredicate()
    {
      int[] numbers = new int[] { };
      bool predicate(int i) => i == 1;

      int result = numbers.Single(predicate);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Single_SourceHasMoreThanOneElement()
    {
      int[] numbers = new int[] { 1, 2 };
      int result = numbers.Single();
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Single_MoreThanOneMatchingElement()
    {
      int[] numbers = new int[] { 1, 2, 1 };
      bool predicate(int i) => i == 1;

      int result = numbers.Single(predicate);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Single_NoMatchingElement()
    {
      int[] numbers = new int[] { 1, 2, 3 };
      bool predicate(int i) => i == 4;

      int result = numbers.Single(predicate);
    }
  }
}
