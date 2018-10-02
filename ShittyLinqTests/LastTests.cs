using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
  [TestClass]
  public class LastTests
  {
    [TestMethod]
    public void Last_GetLastNumber()
    {
      int[] numbers = new int[] { 1, 2, 3, 4, 5 };
      int expectedResult = 5;

      int result = numbers.Last();

      Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Last_GetLastNumberMatchingPredicate()
    {
      int[] numbers = new int[] { 1, 2, 3, 4, 5 };
      int expectedResult = 3;
      bool predicate(int i) => i == 3;

      int result = numbers.Last(predicate);

      Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Last_SourceIsNull()
    {
      int[] numbers = null;

      int result = numbers.Last();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Last_SourceIsNullWithPredicate()
    {
      int[] numbers = null;
      bool predicate(int i) => i == 3;

      int result = numbers.Last(predicate);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Last_PredicateIsNull()
    {
      int[] numbers = new int[] { 1, 2, 3, 4, 5 };
      Func<int, bool> predicate = null;

      int result = numbers.Last(predicate);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Last_SourceIsEmpty()
    {
      int[] numbers = new int[] { };

      int result = numbers.Last();
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Last_SourceIsEmptyWithPredicate()
    {
      int[] numbers = new int[] { };
      bool predicate(int i) => i == 3;

      int result = numbers.Last(predicate);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Last_NoElementMatchesPredicate()
    {
      int[] numbers = new int[] { 1, 2, 4, 5 };
      bool predicate(int i) => i == 3;

      int result = numbers.Last(predicate);
    }
  }
}
