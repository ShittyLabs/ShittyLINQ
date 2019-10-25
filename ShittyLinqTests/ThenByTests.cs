using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;

namespace ShittyTests
{
    [TestClass]
    public class ThenByTests
    {

        [TestMethod]
        public void ThenBy_WithoutComparer()
        {
            // Arrange
            var items = System.Linq.Enumerable.OrderBy(new (string prop1, int prop2)[]
            {
                ("test", 3),
                ("test", 2),
                ("test", 1),
            }, i => i.prop1);

            // Act
            var result = items.ThenBy(i => i.prop2);

            // Assert
            Assert.IsNotNull(result);
            using (var enumerator = result.GetEnumerator())
            {
                enumerator.MoveNext();
                Assert.AreEqual(1, enumerator.Current.prop2);
                enumerator.MoveNext();
                Assert.AreEqual(2, enumerator.Current.prop2);
                enumerator.MoveNext();
                Assert.AreEqual(3, enumerator.Current.prop2);
            }
        }


        [TestMethod]
        public void ThenBy_WithComparer()
        {
            // Arrange
            var items = System.Linq.Enumerable.OrderBy(new (string prop1, string prop2)[]
            {
                ("test", "c"),
                ("test", "B"),
                ("test", "a"),
            }, i => i.prop1);

            // Act
            var result = items.ThenBy(i => i.prop2, StringComparer.OrdinalIgnoreCase);

            // Assert
            Assert.IsNotNull(result);
            using (var enumerator = result.GetEnumerator())
            {
                enumerator.MoveNext();
                Assert.AreEqual("a", enumerator.Current.prop2);
                enumerator.MoveNext();
                Assert.AreEqual("B", enumerator.Current.prop2);
                enumerator.MoveNext();
                Assert.AreEqual("c", enumerator.Current.prop2);
            }
        }
    }
}
