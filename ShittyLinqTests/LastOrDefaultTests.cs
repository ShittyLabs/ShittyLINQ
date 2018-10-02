using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
namespace ShittyTests
{
  [TestClass]
  public class LastOrDefaultTests
  {
    [TestMethod]
    public void LastOrDefault_GetLastNumber()
    {
      int[] numbers = new int[] { 1, 2, 3, 4, 5 };
      int expectedResult = 5;

      int result = numbers.LastOrDefault();

      Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void LastOrDefault_GetLastNumberMatchingPredicate()
    {
      int[] numbers = new int[] { 1, 2, 3, 4, 5 };
      int expectedResult = 3;
      bool predicate(int i) => i == 3;

      int result = numbers.LastOrDefault(predicate);

      Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastOrDefault_SourceIsNull()
    {
      int[] numbers = null;

      int result = numbers.LastOrDefault();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastOrDefault_SourceIsNullWithPredicate()
    {
      int[] numbers = null;
      bool predicate(int i) => i == 3;

      int result = numbers.LastOrDefault(predicate);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastOrDefault_PredicateIsNull()
    {
      int[] numbers = new int[] { 1, 2, 3, 4, 5 };
      Func<int, bool> predicate = null;

      int result = numbers.LastOrDefault(predicate);
    }

    [TestMethod]
    public void LastOrDefault_SourceIsEmpty()
    {
      int[] numbers = new int[] { };
      int expectedResult = default(int);

      int result = numbers.LastOrDefault();

      Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void LastOrDefault_SourceIsEmptyWithPredicate()
    {
      int[] numbers = new int[] { };
      bool predicate(int i) => i == 3;
      int expectedResult = default(int);

      int result = numbers.LastOrDefault(predicate);

      Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void LastOrDefault_NoElementMatchesPredicate()
    {
      int[] numbers = new int[] { 1, 2, 4, 5 };
      bool predicate(int i) => i == 3;
      int expectedResult = default(int);

      int result = numbers.LastOrDefault(predicate);

      Assert.AreEqual(expectedResult, result);
    }
  }
}