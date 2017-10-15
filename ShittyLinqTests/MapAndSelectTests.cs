using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class MapAndSelectTests
    {
        [TestMethod]
        public void Map_PowerOfTwoNumbers()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            double[] expectedResult = new double[] { 1, 4, 9, 16, 25 };

            IEnumerable<double> mapResult = numbers.Map(x => Math.Pow((double)x, 2));
            IEnumerable<double> selectResult = numbers.Select(x => Math.Pow((double)x, 2));

            TestHelper.AssertCollectionsAreSame(expectedResult, mapResult);
            TestHelper.AssertCollectionsAreSame(expectedResult, selectResult);
        }

        [TestMethod]
        public void MapAndSelect_MapPeopleToColors()
        {
            IEnumerable<Person> people = System.Linq.Enumerable.Take(TestHelper.GetPeople(), 18);
            IEnumerable<string> expectedResult = new List<string>()
            {
                "Yellow", "Violet", "Red", "Blue", "Orange", "Yellow", "Blue",
                "Green", "Yellow", "Yellow", "Yellow", "Yellow", "Red", "Violet",
                "Green", "Orange", "Yellow",  "Red"
            };

            IEnumerable<string> mapResult = people.Map(x => x.FavoriteColor);
            IEnumerable<string> selectResult = people.Select(x => x.FavoriteColor);

            TestHelper.AssertCollectionsAreSame(expectedResult, mapResult);
            TestHelper.AssertCollectionsAreSame(expectedResult, selectResult);
        }

        [TestMethod]
        public void MapAndSelect_SourceIsEmpty()
        {
            int[] numbers = new int[] { };
            double[] expectedResult = new double[] { };

            IEnumerable<double> mapResult = numbers.Map(x => Math.Pow((double)x, 2));
            IEnumerable<double> selectResult = numbers.Select(x => Math.Pow((double)x, 2));

            TestHelper.AssertCollectionsAreSame(expectedResult, mapResult);
            TestHelper.AssertCollectionsAreSame(expectedResult, selectResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Map_SourceIsNull()
        {
            int[] numbers = null;

            IEnumerable<double> result = numbers.Map(x => Math.Pow((double)x, 2));
            foreach (var num in result) { }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Select_SourceIsNull()
        {
            int[] numbers = null;

            IEnumerable<double> result = numbers.Select(x => Math.Pow((double)x, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Map_TransformIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            IEnumerable<double> result = numbers.Map<int, double>(null);
            foreach (var num in result) { }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Select_TransformIsNull()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            IEnumerable<double> result = numbers.Select<int, double>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Map_CollectionIsModified()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<int> result = numbers.Map(x => 
            {
                numbers.Remove(x);
                return x;
            });

            foreach (int number in result)
            { }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Select_CollectionIsModified()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<int> result = numbers.Select(x =>
            {
                numbers.Remove(x);
                return x;
            });

            foreach (int number in result)
            { }
        }
    }
}
