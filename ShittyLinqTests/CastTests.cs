namespace ShittyTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ShittyLINQ;
    using ShittyTests.TestHelpers;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestClass]
    public class CastTests
    {
        [TestMethod]
        public void Cast_ReturnsExpected()
        {
            var source = new ArrayList { "1", "2", "3" };
            var expectedResult = new List<string> { "1", "2", "3" };


            var result = source.Cast<string>();

            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }

        [TestMethod]
        public void Cast_ReturnsExpectedWithEmptyCollection()
        {
            var source = new ArrayList();
            var expectedResult = new List<string>();

            var result = source.Cast<string>();

            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cast_CollectionIsNull()
        {
            ((ArrayList)null).Cast<string>().ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Cast_Invalid()
        {
            var source = new ArrayList { "1", "2", "3" };

            source.Cast<char>().ToList();
        }
    }
}