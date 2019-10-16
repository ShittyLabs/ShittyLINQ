using System;
using System.Collections.Generic;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShittyTests
{
    [TestClass]
    public class ToHashSetTests
    {
        [TestMethod]
        public void ToHashSet_Numbers()
        {
            IEnumerable<int> numbers = new[] {1, 2, 2, 3, 3, 3, 4, 4, 4};

            var result = numbers.ToHashSet();
            Assert.AreEqual(result.Count, 4);

            foreach (var number in numbers)
            {
                Assert.IsTrue(result.Contains(number));
            }
        }

        [TestMethod]
        public void ToHashSet_Person1()
        {
            IEnumerable<Person> people =
                new[]
                {
                    new Person("Adam", 20, "Arquitech", "Amber"),
                    new Person("Brian", 45, "Arquitech", "Blue"),
                    new Person("Brian", 45, "Arquitech", "Blue"),
                    new Person("Charles", 32, "Arquitech", "Cyan"),
                    new Person("Charles", 32, "Arquitech", "Cyan"),
                    new Person("Charles", 32, "Arquitech", "Cyan"),
                    new Person("Dani", 33, "Developer", "Deep Purple"),
                    new Person("Dani", 33, "Developer", "Deep Purple"),
                    new Person("Dani", 33, "Developer", "Deep Purple"),
                    new Person("Dani", 33, "Developer", "Deep Purple")
                };

            var result = people.ToHashSet();
            Assert.AreEqual(result.Count, 4);

            foreach (var person in people)
            {
                Assert.IsTrue(result.Contains(person));
            }
        }

        [TestMethod]
        public void ToHashSet_Person2()
        {
            var rng = new Random();
            var ages = new[]
                       {
                           rng.Next(20, 50), rng.Next(20, 50), rng.Next(20, 50), rng.Next(20, 50), rng.Next(20, 50),
                           rng.Next(20, 50), rng.Next(20, 50), rng.Next(20, 50), rng.Next(20, 50), rng.Next(20, 50)
                       };

            IEnumerable<Person> people =
                new[]
                {
                    new Person("Adam", ages[0], "Arquitech", "Amber"),
                    new Person("Brian", ages[1], "Arquitech", "Blue"),
                    new Person("Brian", ages[2], "Arquitech", "Blue"),
                    new Person("Charles", ages[3], "Arquitech", "Cyan"),
                    new Person("Charles", ages[4], "Arquitech", "Cyan"),
                    new Person("Charles", ages[5], "Arquitech", "Cyan"),
                    new Person("Dani", ages[6], "Developer", "Deep Purple"),
                    new Person("Dani", ages[7], "Developer", "Deep Purple"),
                    new Person("Dani", ages[8], "Developer", "Deep Purple"),
                    new Person("Dani", ages[9], "Developer", "Deep Purple")
                };

            var result = people.ToHashSet(new WeakCompare());
            Assert.AreEqual(result.Count, 4);

            foreach (var person in people)
            {
                Assert.IsTrue(result.Contains(person));
            }
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// This is weak comparator that ignores the age of a Person
    /// </summary>
    internal class WeakCompare : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null | y == null)
            {
                return false;
            }

            return x.Name.Equals(y.Name) &&
                   x.Job.Equals(y.Job) &&
                   x.FavoriteColor.Equals(y.FavoriteColor);
        }

        /// <inheritdoc />
        /// <summary>
        /// Weak hash code that ignores the age of the person
        /// </summary>
        /// <param name="obj">Person to get the hash code of</param>
        /// <returns>hash code of the person</returns>
        public int GetHashCode(Person obj)
        {
            return TestHelper.CombineHashCodes(
                obj.Name,
                TestHelper.CombineHashCodes(
                    obj.Job, obj.FavoriteColor
                )
            );
        }
    }
}
