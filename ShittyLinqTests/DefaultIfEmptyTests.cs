using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using Enumerable = System.Linq.Enumerable;

namespace ShittyTests
{
    [TestClass]
    public class DefaultIfEmptyTests
    {
        [TestMethod]
        public void Default_NotEmpty()
        {
            int[] source = { 1, 2, 3 };
            int[] expectedResult = { 1, 2, 3 };

            var result = source.DefaultIfEmpty(0);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedResult, result));
        }

        [TestMethod]
        public void Default_Empty()
        {
            int[] source = { };
            int[] expectedResult = { 0 };

            var result = source.DefaultIfEmpty(0);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedResult, result));
        }

        [TestMethod]
        public void Default_EnumerableNull()
        {
            int[] source = null;
            int[] expectedResult = { 0 };

            var result = source.DefaultIfEmpty(0);
            Assert.IsTrue(Enumerable.SequenceEqual(expectedResult, result));
        }
    }
}
