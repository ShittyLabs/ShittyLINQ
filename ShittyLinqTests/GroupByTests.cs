using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using ShittyTests.TestHelpers;

namespace ShittyTests
{
	[TestClass]
	public class GroupByTests
	{
		
		[TestMethod]
		public void GroupBy_Person()
		{
			var adam = new Person("Adam", 20, "Arquitech", "Amber");
			var brian = new Person("Brian", 45, "Arquitech", "Blue");
			var charles = new Person("Charles", 33, "Arquitech", "Cyan");
			var dani = new Person("Dani", 33, "Developer", "Deep Purple");
			IEnumerable<Person> people = new[] { adam, brian, charles, dani };

			var result = people.GroupBy(person => person.Age);

			Assert.AreEqual(result.Count, 3);
			Assert.AreEqual(result.GetValueOrDefault(20).First(), adam);
		}

		[TestMethod]
		public void GroupBy_Person_WithResultSelector()
		{
			var adam = new Person("Adam", 20, "Arquitech", "Amber");
			var brian = new Person("Brian", 45, "Arquitech", "Blue");
			var charles = new Person("Charles", 33, "Arquitech", "Cyan");
			var dani = new Person("Dani", 33, "Developer", "Deep Purple");
			IEnumerable<Person> people = new[] { adam, brian, charles, dani };

			var result = people.GroupBy(person => person.Age, 
				(baseAge, ages) => new
							{
								Key = baseAge,
								Count = (int)ages.Count()
							});

			Assert.AreEqual(result.ToList().Count, 3);
			Assert.AreEqual(result.ToList().Max(a => a.Count), 2);
		}
	}
}