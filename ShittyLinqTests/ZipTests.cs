using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ShittyLINQ;

namespace ShittyTests
{
    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void Zip_ItemsMatchUp()
        {
            char[] source = new[] { 'h', 'e', 'l', 'l', 'o' };
            char[] second = new[] { 'w', 'o', 'r', 'l', 'd' };

            var actual = source.Zip(second).ToList();
            var expected = new (char, char)[]
            {
                ('h', 'w'),
                ('e', 'o'),
                ('l', 'r'),
                ('l', 'l'),
                ('o', 'd'),
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Zip_SourceIsLonger()
        {
            int[] source = new[] { 0, 1, 2, 3 };
            int[] second = new[] { 0, 1, 2 };

            var actual = source.Zip(second).Count();
            var expected = 3L;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Zip_SecondIsLonger()
        {
            int[] source = new[] { 0, 1, 2 };
            int[] second = new[] { 0, 1, 2, 3 };

            var actual = source.Zip(second).Count();
            var expected = 3L;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Zip_SourceIsNull()
        {
            int[] a = null;
            int[] b = new[] { 0, 1, 2 };

            Assert.ThrowsException<ArgumentNullException>(() => a.Zip(b).ToList());
        }

        [TestMethod]
        public void Zip_SecondIsNull()
        {
            int[] a = new[] { 0, 1, 2 };
            int[] b = null;

            Assert.ThrowsException<ArgumentNullException>(() => a.Zip(b).ToList());
        }

        [TestMethod]
        public void Zip_BothAreNull()
        {
            int[] a = null;
            int[] b = null;

            Assert.ThrowsException<ArgumentNullException>(() => a.Zip(b).ToList());
        }
    }
}
