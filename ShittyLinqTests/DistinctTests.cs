using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;
using Enumerable = System.Linq.Enumerable;

namespace ShittyTests
{
    [TestClass]
    public class DistinctTests
    {
        [TestMethod]
        public void Distinct_Numbers()
        {
            int[] numbers = new int[] {1, 2, 3, 3, 4, 4, 5, 6, 7};
            int[] expectedResult = new int[]{1, 2, 3, 4, 5, 6, 7};

            var result = Enumerable.ToArray(numbers.Distinct());
            
            Assert.AreEqual(expectedResult.Length, result.Length);
            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }
        
        [TestMethod]
        public void Distinct_Strings()
        {
            string[] strings = new string[] {"apple", "apple", "banana", "cucumber", "banana", "drewberry"};
            string[] expectedResult = new string[]{"apple", "banana", "cucumber", "drewberry"};
            

            var result = Enumerable.ToArray(strings.Distinct());
            
            Assert.AreEqual(expectedResult.Length, result.Length);
            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod]
        public void Distinct_Objects()
        {
            var person1 = new Person("John Doe", 20, "Developer", "Red");
            var person2 = new Person("Peter Appleseed", 35, "Craftman", "Orange");
            
            var persons = new Person[] {person1, person1, person2, person1};
            var expectedResult = new Person[]{person1, person2};
            

            var result = Enumerable.ToArray(persons.Distinct());
            
            Assert.AreEqual(expectedResult.Length, result.Length);
            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod]
        public void Distinct_SourceIsEmpty()
        {
            int[] numbers = { };

            var result = Enumerable.ToArray(numbers.Distinct());
            
            Assert.AreEqual(result.Length, 0);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Distinct_SourceIsNull()
        {
            int[] numbers = null;

            numbers.Distinct();
        }
    }
}