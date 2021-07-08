using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ShittyLINQ;

namespace ShittyTests
{
    [TestClass]
    public class OrdeByTest
    {
        [TestMethod]
        public void OrderBy_Numbers()
        {
            int[] numbers = new int[] { 1, 5, 9, 21, 11, 10 };

            IEnumerable<int> result = numbers.OrderBy(x => x);

            Assert.AreEqual(1, result.ElementAt(0));
            Assert.AreEqual(5, result.ElementAt(1));
            Assert.AreEqual(9, result.ElementAt(2));
            Assert.AreEqual(10, result.ElementAt(3));
            Assert.AreEqual(11, result.ElementAt(4));
            Assert.AreEqual(21, result.ElementAt(5));
        }
        [TestMethod]
        public void OrderBy_NumbersWithCustomComparer()
        {
            int[] numbers = new int[] { 314, 782, 0, 93, 65, -1 };

            IEnumerable<int> result = numbers.OrderBy(n=>n,Comparer<int>.Create((x,y)=>
            {
                if (x < y) return 1;
                if (x > y) return -1;

                return 0;
            }));

            Assert.AreEqual(782, result.ElementAt(0));
            Assert.AreEqual(314, result.ElementAt(1));
            Assert.AreEqual(93, result.ElementAt(2));
            Assert.AreEqual(65, result.ElementAt(3));
            Assert.AreEqual(0, result.ElementAt(4));
            Assert.AreEqual(-1, result.ElementAt(5));
        }
        [TestMethod]
        public void OrderBy_ComplextType()
        {
            var anonymousType = new[] {
                new { name = "Mary", age = 50 },
                new { name = "Jane", age = 10 },
                new { name = "James", age = 70 },
                new { name = "Anthony", age = 15 },
                new { name = "Peter", age = 20 },
                new { name = "Blue", age = 3 },
                new { name = "Jobs", age = 9 },
            };

            var result = anonymousType.OrderBy(x => x.age);

            Assert.AreEqual(3, result.ElementAt(0).age);
            Assert.AreEqual(9, result.ElementAt(1).age);
            Assert.AreEqual(10, result.ElementAt(2).age);
            Assert.AreEqual(15, result.ElementAt(3).age);
            Assert.AreEqual(20, result.ElementAt(4).age);
            Assert.AreEqual(50, result.ElementAt(5).age);
            Assert.AreEqual(70, result.ElementAt(6).age);
        }
    }
}
