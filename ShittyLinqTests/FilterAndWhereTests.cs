using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class FilterAndWhereTests
    {
        [TestMethod]
        public void FilterAndWhere_OddNumbers()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> expectedResult = new int[] { 1, 3, 5 };

            IEnumerable<int> filterResult = numbers.Filter((x) => x % 2 == 1);
            IEnumerable<int> whereResult = numbers.Where((x) => x % 2 == 1);

            TestHelper.AssertCollectionsAreSame(expectedResult, filterResult);
            TestHelper.AssertCollectionsAreSame(expectedResult, whereResult);
        }

        [TestMethod]
        public void FilterAndWhere_StringAboveCertainLength()
        {
            string[] names = new string[] { "a", "ab", "abc", "ab", "a" };
            IEnumerable<string> expectedResult = new string[] { "ab", "abc", "ab" };

            IEnumerable<string> filterResult = names.Filter(x => x.Length >= 2);
            IEnumerable<string> whereResult = names.Filter(x => x.Length >= 2);

            TestHelper.AssertCollectionsAreSame(expectedResult, filterResult);
            TestHelper.AssertCollectionsAreSame(expectedResult, whereResult);
        }

        [TestMethod]
        public void FilterAndWhere_Objects()
        {
            IEnumerable<Person> people = TestHelper.GetPeople();
            IEnumerable<Person> expectedResult = new List<Person>
            {
                new Person("Hollyanne Menhenitt", 20,"Dev","Red"),
                new Person("Stephana Jameson", 18,"PM","Green"),
                new Person("Templeton Shirland", 20,"Dev","Yellow"),
                new Person("Barnaby Bilbey", 20,"QA","Green"),
                new Person("Basil Tidridge", 20,"PM","Orange"),
                new Person("Cornelius Fuente", 20,"QA","Violet"),
            };

            IEnumerable<Person> filterResult = people.Filter(x => x.Age <= 20);
            IEnumerable<Person> whereResult = people.Filter(x => x.Age <= 20);

            TestHelper.AssertCollectionsAreSame(expectedResult, filterResult);
            TestHelper.AssertCollectionsAreSame(expectedResult, whereResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Filter_PredicateIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            IEnumerable<int> result = numbers.Filter(null);
            foreach(var num in result) { }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Where_PredicateIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            IEnumerable<int> result = numbers.Where(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Filter_SourceIsNull()
        {
            int[] numbers = null;

            IEnumerable<int> result = numbers.Filter(x => x % 2 == 1);
            foreach (var num in result) { }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Where_SourceIsNull()
        {
            int[] numbers = null;

            IEnumerable<int> result = numbers.Where(x => x % 2 == 1);
        }

        [TestMethod]
        public void FilterAndWhere_SourceIsEmpty()
        {
            int[] numbers = new int[] { };
            int[] expectedResult = new int[] { };

            IEnumerable<int> filterResult = numbers.Filter(x => x % 2 == 1);
            IEnumerable<int> whereResult = numbers.Where(x => x % 2 == 1);

            TestHelper.AssertCollectionsAreSame(expectedResult, filterResult);
            TestHelper.AssertCollectionsAreSame(expectedResult, whereResult);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Filter_CollectionHasBeenModified()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<int> result = numbers.Filter(x => numbers.Remove(x));

            foreach(int number in result)
            { }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Where_CollectionHasBeenModified()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<int> result = numbers.Where(x => numbers.Remove(x));

            foreach (int number in result)
            { }
        }
    }
}
