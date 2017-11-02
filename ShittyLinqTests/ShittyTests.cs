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
        public void TestAggregate()
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
        public void TestFirst()
        {
            var shittyFirst = ShittyLINQ.Extensions.First(range);
            var linqFirst = range.First();
            Assert.AreEqual(shittyFirst, linqFirst);
        }

        [TestMethod]
        public void TestFoldl()
        {
            Func<int, int, int> sumOfEnumerable = (accumulator, val) => accumulator += val;
            var shittySum = ShittyLINQ.Extensions.Foldl(range, 0, sumOfEnumerable);
            var linqSum = range.Sum();
            Assert.AreEqual(shittySum, linqSum);
        }

        [TestMethod]
        public void TestMap()
        {
            Func<int, string> stringsOfEnumerable = (val) => val.ToString();
            var shittyMap = ShittyLINQ.Extensions.Map(range, stringsOfEnumerable);
            var linqMap = range.Select(stringsOfEnumerable);
            CollectionAssert.AreEqual(shittyMap.ToList(), linqMap.ToList());
        }

        [TestMethod]
        public void TestMax()
        {
            Func<int, int> identity = (val) => val;
            var shittyMax = ShittyLINQ.Extensions.Max(range, identity);
            var linqMax = range.Max(identity);
            Assert.AreEqual(shittyMax, linqMax);
        }

        [TestMethod]
        public void TestSelect()
        {
            Func<int, string> stringsOfEnumerable = (val) => val.ToString();
            var shittySelect = ShittyLINQ.Extensions.Select(range, stringsOfEnumerable);
            var linqSelect = range.Select(stringsOfEnumerable);
            CollectionAssert.AreEqual(shittySelect.ToList(), linqSelect.ToList());
        }

        [TestMethod]
        public void TestWhere()
        {
            Func<int, bool> filterEnumerable = (item) => item % 2 == 0;
            var shittyEvens = ShittyLINQ.Extensions.Where(range, filterEnumerable);
            var linqEvens = range.Where(filterEnumerable);
            CollectionAssert.AreEqual(shittyEvens.ToList(), linqEvens.ToList());
        }

        [TestMethod]
        public void TestTake()
        {   
            var shittySkip = ShittyLINQ.Extensions.Take(range, 3);
            var linqSkip = range.Take(3);
            CollectionAssert.AreEqual(linqSkip.ToList(), shittySkip.ToList());
        }
    }
}
