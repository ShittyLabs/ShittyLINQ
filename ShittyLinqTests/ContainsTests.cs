using ShittyLINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShittyLinqTests
{
    [TestClass]
    public class ContainsTests
    {
        [TestMethod]
        public void ContainsAllShouldReturnTrue()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var otherNumbers = new[] { 2, 3, 4 };

            var result = numbers.Contains(otherNumbers);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsSomeShouldReturnFalse()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var otherNumbers = new[] { 4, 5, 6 };

            var result = numbers.Contains(otherNumbers);

            Assert.IsFalse(result);
        }
    }
}
