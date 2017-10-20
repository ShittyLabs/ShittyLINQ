using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;

namespace ShittyTests
{
    [TestClass]
    public class BatchTests
    {
        [TestMethod]
        public void Batch_Numbers_Exact_Size()
        {
            var data = Enumerable.Range(1, 10);

            var result = data.Batch(5);

            Assert.AreEqual(2, result.Count());

            foreach (var batch in result)
                Assert.AreEqual(5, batch.Count());

            var asList = result.ToList();

            var lastBatch = asList[1].ToList();

            Assert.AreEqual(6, lastBatch[0]);
            Assert.AreEqual(10, lastBatch[4]);
        }

        [TestMethod]
        public void Batch_Numbers_With_Tail()
        {
            var data = Enumerable.Range(1, 12);

            var result = data.Batch(5);

            Assert.AreEqual(3, result.Count());

            var asList = result.ToList();

            var lastBatch = asList[2].ToList();

            Assert.AreEqual(11, lastBatch[0]);
            Assert.AreEqual(12, lastBatch[1]);
        }

        [TestMethod]
        public void Batch_Invalid_Size()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var data = Enumerable.Range(1, 12);

                var result = data.Batch(0).ToList();
            });
        }
    }
}