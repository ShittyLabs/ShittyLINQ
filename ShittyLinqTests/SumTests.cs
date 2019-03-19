using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;

namespace ShittyTests
{
    [TestClass]
    public class SumTests
    {
        [TestMethod]
        public void Sum_Integers()
        {
            int[] numbers = new int[] { 1, 2, 3, 4 };
            Assert.AreEqual(numbers.Sum(), 10);
        }

        [TestMethod]
        public void Sum_Long()
        {
            long[] numbers = new long[] { 1, 2, 3, 4 };
            Assert.AreEqual(numbers.Sum(), 10L);
        }

        [TestMethod]
        public void Sum_Float()
        {
            float[] numbers = new float[] { 1, 2, 3, 4 };
            Assert.AreEqual(numbers.Sum(), 10f);
        }

        [TestMethod]
        public void Sum_Double()
        {
            double[] numbers = new double[] { 1, 2, 3, 4 };
            Assert.AreEqual(numbers.Sum(), 10d);
        }

        [TestMethod]
        public void Sum_Decimal()
        {
            decimal[] numbers = new decimal[] { 1, 2, 3, 4 };
            const decimal expected = 10;
            Assert.AreEqual(numbers.Sum(), expected);
        }

        [TestMethod]
        public void Sum_NullIntegers()
        {
            int?[] numbers = new int?[] { 1, null, 2, 3, 4 };
            Assert.AreEqual(numbers.Sum(), 10);
        }

        [TestMethod]
        public void Sum_NullLong()
        {
            long?[] numbers = new long?[] { 1, null, 2, 3, 4 };
            Assert.AreEqual(numbers.Sum(), 10L);
        }

        [TestMethod]
        public void Sum_NullFloat()
        {
            float?[] numbers = new float?[] { 1, null, 2, 3, 4 };
            Assert.AreEqual(numbers.Sum(), 10f);
        }

        [TestMethod]
        public void Sum_NullDouble()
        {
            double?[] numbers = new double?[] { 1, null, 2, 3, 4 };
            Assert.AreEqual(numbers.Sum(), 10d);
        }

        [TestMethod]
        public void Sum_NullDecimal()
        {
            decimal?[] numbers = new decimal?[] { 1, null, 2, 3, 4 };
            const decimal expected = 10;
            Assert.AreEqual(numbers.Sum(), expected);
        }

        class PredicateType
        {
            public int Value { get; }
            public PredicateType(int value)
            {
                this.Value = value;
            }
        }

        [TestMethod]
        public void Sum_IntPredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            const int expected = 20;
            int value = values.Sum(p => p.Value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Sum_LongPredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            const long expected = 20;
            long value = values.Sum(p => (long)p.Value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Sum_FloatPredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            const float expected = 20;
            float value = values.Sum(p => (float)p.Value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Sum_DoublePredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            const double expected = 20;
            double value = values.Sum(p => (double)p.Value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Sum_DecimalPredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            const decimal expected = 20;
            decimal value = values.Sum(p => (decimal)p.Value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Sum_NullableIntPredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            int? expected = 20;
            int? value = values.Sum(p => (int?)p.Value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Sum_NullableLongPredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            long? expected = 20;
            long? value = values.Sum(p => (long?)p.Value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Sum_NullableFloatPredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            float? expected = 20;
            float? value = values.Sum(p => (float?)p.Value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Sum_NullableDoublePredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            double? expected = 20;
            double? value = values.Sum(p => (double?)p.Value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Sum_NullableDecimalPredicate()
        {
            PredicateType[] values = new PredicateType[] { new PredicateType(5), new PredicateType(6), new PredicateType(9) };
            decimal? expected = 20;
            decimal? value = values.Sum(p => (decimal?)p.Value);
            Assert.AreEqual(expected, value);
        }
    }
}
