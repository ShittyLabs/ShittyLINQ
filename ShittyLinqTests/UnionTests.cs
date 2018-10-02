using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;

namespace ShittyTests
{
    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void Union_Numbers()
        {
            int[] first = new int[]{1, 2, 3, 4};
            int[] second = new int[]{3, 4, 5, 6};
            IEnumerable<int> expectedResult = new int[] {1, 2, 3, 4, 5, 6};

            IEnumerable<int> result = first.Union(second);
            
            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }
        
        [TestMethod]
        public void Union_Strings()
        {
            string[] first = new string[]{"apple", "banana", "cucumber"};
            string[] second = new string[]{"banana", "apple", "drewberry", "cucumber", "eggplant"};
            IEnumerable<string> expectedResult = new string[] {"apple", "banana", "cucumber", "drewberry", "eggplant"};

            IEnumerable<string> result = first.Union(second);
            
            TestHelper.AssertCollectionsAreSame(expectedResult, result);
        }

        [TestMethod]
        public void Union_Persons()
        {
            IEnumerable<Person> firstPeople = TestHelper.GetPeople();
            IEnumerable<Person> secondPeople = TestHelper.GetPeople();
            IEnumerable<Person> expectedResult = TestHelper.GetPeople();

            var result = firstPeople.Union(secondPeople, new PersonComparer());
            
            TestHelper.AssertCollectionsAreSame(result, expectedResult);
        }
    }
}