using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;

namespace ShittyTests
{
    [TestClass]
    public class ToDictionaryTests
    {
        [TestMethod]
        public void ToDictionary_Numbers()
        {
            IEnumerable<int> numbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

            var result = numbers.ToDictionary(x => x, x=> true);

            Assert.AreEqual(result.Count, 9);
            
            foreach (int number in numbers)
            {
                Assert.IsTrue(result.ContainsKey(number));
            }
        }

        [TestMethod]
        public void ToDictionary_Person()
        {
            var adam = new Person("Adam", 20, "Arquitech", "Amber");
            var brian = new Person("Brian", 45, "Arquitech", "Blue");
            var charles = new Person("Charles", 32, "Arquitech", "Cyan");
            var dani = new Person("Dani", 33, "Developer", "Deep Purple");
            
            IEnumerable<Person> people = new[] { adam, brian, charles, dani };

            var result = people.ToDictionary(person => person.Age);

            Assert.AreEqual(result.TryGetValue(brian.Age, out var expectedBrian), true);
            Assert.IsNotNull(expectedBrian);
            Assert.AreEqual(expectedBrian.Name, brian.Name);
        }
    }
}