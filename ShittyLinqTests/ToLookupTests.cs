using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;

namespace ShittyTests
{
	[TestClass]
	public class ToLookupTests
	{
		[TestMethod]
		public void ToLookup_Numbers()
		{
			IEnumerable<int> numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			var result = numbers.ToLookup(x => x, x => true);
			
			Assert.AreEqual(result.Count, 9);

			foreach (int number in numbers)
			{
				Assert.IsTrue(result.ContainsKey(number));
			}
		}

		[TestMethod]
		public void ToLookup_Person()
		{
			var adam = new Person("Adam", 20, "Arquitech", "Amber");
			var brian = new Person("Brian", 45, "Arquitech", "Blue");
			var charles = new Person("Charles", 33, "Arquitech", "Cyan");
			var dani = new Person("Dani", 33, "Developer", "Deep Purple");

			IEnumerable<Person> people = new[] { adam, brian, charles, dani };

			var result = people.ToLookup(person => person.Age);

			Assert.AreEqual(result.TryGetValue(brian.Age, out var expectedBrian), true);
			Assert.IsNotNull(expectedBrian);
		}
	}
}