using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using Enumerable = System.Linq.Enumerable;

namespace ShittyTests
{
    [TestClass]
    public class ExceptTests
    {
        [TestMethod]
        public void Except_ReturnsExcept()
        {
            int[] first = { 1, 2, 3, 4, 5 };
            int[] second = { 2, 4 };
            int[] expectedResult = { 1, 3, 5 };

            var result = first.Except(second);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedResult, result));
        }
        
        [TestMethod]
        public void Except_NoExceptions()
        {
            int[] first = { 1, 2, 3, 4, 5 };
            int[] second = { 0, 6 };
            int[] expectedResult = { 1, 2, 3, 4, 5 };

            var result = first.Except(second);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedResult, result));
        }

        [TestMethod]
        public void Except_AllExceptions()
        {
            int[] first = { 1, 2, 3, 4, 5 };
            int[] second = { 1, 2, 3, 4, 5 };
            int[] expectedResult = { };

            var result = first.Except(second);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedResult, result));
        }

        [TestMethod]
        public void Except_EmptyFirst()
        {
            int[] first = { };
            int[] second = { 1, 2, 3 };
            int[] expectedResult = { };

            var result = first.Except(second);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedResult, result));
        }

        [TestMethod]
        public void Except_EmptySecond()
        {
            int[] first = { 1, 2, 3, 4, 5 };
            int[] second = { };
            int[] expectedResult = { 1, 2, 3, 4, 5 };

            var result = first.Except(second);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedResult, result));
        }
    }
}
