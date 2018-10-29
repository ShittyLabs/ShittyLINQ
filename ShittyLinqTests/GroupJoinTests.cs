using Microsoft.VisualStudio.TestTools.UnitTesting; 
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using ShittyLINQ;

namespace ShittyTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class GroupJoinTests
    {
        [TestMethod]
        public void GroupJoin_Example()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create a list where each element is an anonymous type
            // that contains the person's first name and a collection of 
            // pets that are owned by them.
            var query = from person in people
                        join pet in pets on person equals pet.Owner into gj
                        select new { OwnerName = person.FirstName, Pets = gj };

            var expected = "Magnus:\r\n  Daisy\r\nTerry:\r\n  Barley\r\n  Boots\r\n  Blue Moon\r\nCharlotte:\r\n  Whiskers\r\nArlene:\r\n";
            var actual = new StringBuilder();
            foreach (var v in query)
            {
                // Output the owner's name.
                actual.AppendLine($"{v.OwnerName}:");
                // Output each of the owner's pet's names.
                foreach (Pet pet in v.Pets)
                    actual.AppendLine($"  {pet.Name}");
            }
            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void GroupJoin_XmlExample()
        {
            var expected = "<PetOwners><Person FirstName=\"Magnus\" LastName=\"Hedlund\"><Pet>Daisy</Pet></Person><Person FirstName=\"Terry\" LastName=\"Adams\"><Pet>Barley</Pet><Pet>Boots</Pet><Pet>Blue Moon</Pet></Person><Person FirstName=\"Charlotte\" LastName=\"Weiss\"><Pet>Whiskers</Pet></Person><Person FirstName=\"Arlene\" LastName=\"Huff\" /></PetOwners>";


            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create XML to display the hierarchical organization of people and their pets.
            XElement ownersAndPets = new XElement("PetOwners",
                from person in people
                join pet in pets on person equals pet.Owner into gj
                select new XElement("Person",
                    new XAttribute("FirstName", person.FirstName),
                    new XAttribute("LastName", person.LastName), gj.Select(subpet => new XElement("Pet", subpet.Name))));

            var actual = ownersAndPets.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual(expected, actual);
        }
        private class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        private class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

    }
}
