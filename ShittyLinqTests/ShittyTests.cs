using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace ShittyLinqTests
{
  [TestClass]
  public class ShittyLinqTests
  {
    IEnumerable<int> range;

    [TestInitialize]
    public void Setup()
    {
      range = Enumerable.Range(1, 10);
    }

    [TestMethod]
    public void TestAggragate()
    {
      Func<int, int, int> productOfEnumerable = (accum, val) => accum *= val;
      var shittyProd = ShittyLINQ.Extensions.Aggregate(range, 1, productOfEnumerable);
      var linqProd = range.Aggregate(productOfEnumerable);
      Assert.AreEqual(shittyProd, linqProd);
    }

    [TestMethod]
    public void TestCount()
    {
      var shittyCount = ShittyLINQ.Extensions.Count(range);
      var linqCount = range.Count();
      Assert.AreEqual(shittyCount, linqCount);
    }

    [TestMethod]
    public void TestFilter()
    {
      Func<int, bool> filterEnumerable = (item) => item % 2 == 0;
      var shittyEvens = ShittyLINQ.Extensions.Filter(range, filterEnumerable);
      var linqEvens = range.Where(filterEnumerable);
      CollectionAssert.AreEqual(shittyEvens.ToList(), linqEvens.ToList());
    }

    [TestMethod]
    public void TestFoldl()
    {
      Func<int, int, int> sumOfEnumerable = (accumulator, val) => accumulator += val;
      var shittySum = ShittyLINQ.Extensions.Foldl(range, 0, sumOfEnumerable);
      var linqSum = range.Sum();
      Assert.AreEqual(shittySum, linqSum);
    }
  }
}
