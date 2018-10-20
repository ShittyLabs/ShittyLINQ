namespace ShittyTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ShittyLINQ;
    using ShittyTests.TestHelpers;

    [TestClass]
    public class PrependTests
    {
        [TestMethod]
        public void Prepend_ReturnsExpected()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var expectedResult = new[] { 0, 1, 2, 3, 4, 5 };

            var result = source.Prepend(0);

            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }

        [TestMethod]
        public void Prepend_ReturnsExpectedWithEmptyCollection()
        {
            var source = new int[] { };
            var expectedResult = new int[] { 0 };

            var result = source.Prepend(0);

            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }
    }
}