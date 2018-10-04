using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
    [TestClass]
    public class AverageTests
    {
        [TestMethod]
        public void Ints()
        {
            int[] numbers = new int[] { 0, 7, 4, 1 };
            double expectedResult = 3d;
            double actualResult = numbers.Average();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Floats()
        {
            float[] numbers = new float[] { 3.5f, -4f, 14f, 7f };
            float expectedResult = 5.125f;
            float actualResult = numbers.Average();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Doubles()
        {
            double[] numbers = new double[] { -1.25d, 2.75d, 7.5d, -4d };
            double expectedResult = 1.25d;
            double actualResult = numbers.Average();

            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [TestMethod]
        public void Longs()
        {
            long[] numbers = new long[] { 5, 3, 17, 1 };
            double expectedResult = 6.5d;
            double actualResult = numbers.Average();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CollectionIsEmpty()
        {
            int[] numbers = new int[] { };
            numbers.Average();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionIsNull()
        {
            int[] numbers = null;
            numbers.Average();
        }
    }
}
