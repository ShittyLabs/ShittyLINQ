using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;

namespace ShittyTests
{
    [TestClass]
    public class TakeLastTests
    {
        [TestMethod]
        [DataRow(4, new int[]{6,7,8,9})]
        [DataRow(9, new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9})]
        [DataRow(2, new int[]{8, 9})]
        public void TakeLast_Numbers(int nElements, IEnumerable<int> expectedResult)
        {
            IEnumerable<int> numbers = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9};

            var result = numbers.TakeLast(nElements);
            
            TestHelper.AssertCollectionsAreSame(result, expectedResult);
        }
        
        [TestMethod]
        public void TakeLast_Strings()
        {
            IEnumerable<string> strings = new string[]
                {"apple", "banana", "cucumber", "dreberry", "eggplant", "fig", "grape"};
            IEnumerable<string> expectedResult = new string[]{"eggplant", "fig", "grape"};
            var result = strings.TakeLast(3);
            
            TestHelper.AssertCollectionsAreSame(result, expectedResult);
        }

        [TestMethod]
        public void TakeLast_Person()
        {
            IEnumerable<Person> people = TestHelper.GetPeople();
            IEnumerable<Person> expectedResult = new Person[]
            {
                new Person("Abba Schroeder", 55, "Dev", "Yellow"),
                new Person("Hermie Defau", 22, "Dev", "Blue"),
                new Person("Keslie Bernath", 51, "PM", "Orange"),
                new Person("Jayson Reeders", 41, "QA", "Yellow")
            };
            
            var result = people.TakeLast(4);

            TestHelper.AssertCollectionsAreSame(result, expectedResult);
        }
    }
}