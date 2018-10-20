namespace ShittyTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ShittyLINQ;
    using ShittyTests.TestHelpers;

    [TestClass]
    public class IntersectTests
    {
        [TestMethod]
        public void Intersect_ReturnsExpected()
        {
            var first = new[] { 1, 2, 3, 4, 5 };
            var second = new[] { 1, 2, 5, 6, 7 };
            var expectedResult = new[] { 1, 2, 5 };

            var result = first.Intersect(second);

            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }

        [TestMethod]
        public void Intersect_ReturnsExpectedWithFirstCollectionEmpty()
        {
            var first = new int[] { };
            var second = new[] { 1, 2, 5, 6, 7 };
            var expectedResult = new int[] { };

            var result = first.Intersect(second);

            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }

        [TestMethod]
        public void Intersect_ReturnsExpectedWithSecondCollectionEmpty()
        {
            var first = new[] { 1, 2, 3, 4, 5 };
            var second = new int[] { };
            var expectedResult = new int[] { };

            var result = first.Intersect(second);

            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }

        [TestMethod]
        public void Intersect_ReturnsExpectedWithoutCommonValue()
        {
            var first = new[] { 1, 2, 3, 4, 5 };
            var second = new int[] { 6, 7, 8, 9, 10 };
            var expectedResult = new int[] { };

            var result = first.Intersect(second);

            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }
    }
}
