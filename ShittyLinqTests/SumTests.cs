using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class SumTests
    {
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 15)]
        [DataRow(new int[] { 100, 2, 3, 4, 5 }, 114)]
        [DataRow(new int[] { 0, 0, 0 }, 0)]
        [DataRow(new int[] { -1, -2, -3 }, -6)]
        [DataTestMethod]
        public void Sum_IntNumbers(IEnumerable<int> testData, int expectedResult)
        {
            var result = testData.Sum();

            Assert.AreEqual(expectedResult, result);
        }

        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 15)]
        [DataRow(new int[] { 100, 2, 3, 4, 5 }, 114)]
        [DataRow(new int[] { 0, 0, 0 }, 0)]
        [DataRow(new int[] { -1, -2, -3 }, -6)]
        [DataTestMethod]
        public void Sum_IntNumbers_WithSelector(IEnumerable<int> testData, int expectedResult)
        {
            var result = testData.Sum(x => x);

            Assert.AreEqual(expectedResult, result, 0.02);
        }

        [DataRow(new double[] { 1.2, 2.5, 3.6, 4.8, 5.5 }, 17.6)]
        [DataRow(new double[] { 100.223, 2.523, 3.696, 4.8345, 5.5435 }, 116.82)]
        [DataRow(new double[] { 0, 0, 0 }, 0)]
        [DataRow(new double[] { -1, -2, -3 }, -6)]
        [DataTestMethod]
        public void Sum_DoubleNumbers(IEnumerable<double> testData, double expectedResult)
        {
            var result = testData.Sum();

            Assert.AreEqual(expectedResult, result, 0.02);
        }

        [DataRow(new double[] { 1.2, 2.5, 3.6, 4.8, 5.5 }, 17.6)]
        [DataRow(new double[] { 100.223, 2.523, 3.696, 4.8345, 5.5435 }, 116.82)]
        [DataRow(new double[] { 0, 0, 0 }, 0)]
        [DataRow(new double[] { -1, -2, -3 }, -6)]
        [DataTestMethod]
        public void Sum_DoubleNumbers_WithSelector(IEnumerable<double> testData, double expectedResult)
        {
            var result = testData.Sum(x => x);

            Assert.AreEqual(expectedResult, result, 0.02);
        }

        [DataRow(new double[] { 1.2, 2.5, 3.6, 4.8, 5.5 }, 15)]
        [DataRow(new double[] { 100.223, 2.523, 3.696, 4.8345, 5.5435 }, 114)]
        [DataRow(new double[] { 0, 0, 0 }, 0)]
        [DataRow(new double[] { -1, -2, -3 }, -6)]
        [DataTestMethod]
        public void Sum_DoubleNumbers_WithSelectorToInt(IEnumerable<double> testData, int expectedResult)
        {
            var result = testData.Sum(x => (int)x);

            Assert.AreEqual(expectedResult, result);
        }

        [DataRow(new float[] { 1.2f, 2.5f, 3.6f, 4.8f, 5.5f }, 17.6f)]
        [DataRow(new float[] { 100.223f, 2.523f, 3.696f, 4.8345f, 5.5435f }, 116.82f)]
        [DataRow(new float[] { 0, 0, 0 }, 0)]
        [DataRow(new float[] { -1, -2, -3 }, -6)]
        [DataTestMethod]
        public void Sum_FloatNumbers(IEnumerable<float> testData, float expectedResult)
        {
            var result = testData.Sum();

            Assert.AreEqual(expectedResult, result, 0.02f);
        }

        [DataRow(new float[] { 1.2f, 2.5f, 3.6f, 4.8f, 5.5f }, 17.6f)]
        [DataRow(new float[] { 100.223f, 2.523f, 3.696f, 4.8345f, 5.5435f }, 116.82f)]
        [DataRow(new float[] { 0f, 0f, 0f }, 0f)]
        [DataTestMethod]
        public void Sum_FloatNumbers_WithSelector(IEnumerable<float> testData, float expectedResult)
        {
            var result = testData.Sum(x => x);

            Assert.AreEqual(expectedResult, result, 0.02);
        }

        [DataRow(new float[] { 1.2f, 2.5f, 3.6f, 4.8f, 5.5f }, 15)]
        [DataRow(new float[] { 100.223f, 2.523f, 3.696f, 4.8345f, 5.5435f }, 114)]
        [DataRow(new float[] { 0f, 0f, 0f }, 0)]
        [DataTestMethod]
        public void Sum_FloatNumbers_WithSelectorToInt(IEnumerable<float> testData, int expectedResult)
        {
            var result = testData.Sum(x => (int)x);

            Assert.AreEqual(expectedResult, result);
        }

    }
}