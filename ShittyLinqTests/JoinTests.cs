using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;

namespace ShittyTests
{
    [TestClass]
    public class JoinTests
    {
        class Person
        {
            public string Name { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        [TestMethod]
        public void Join_PerformsJoinOperation()
        {
            Person magnus = new Person { Name = "Hedlund, Magnus" };
            Person terry = new Person { Name = "Adams, Terry" };
            Person charlotte = new Person { Name = "Weiss, Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            // Create a list of Person-Pet pairs where 
            // each element is an anonymous type that contains a
            // Pet's name and the name of the Person that owns the Pet.
            var query =
                people.Join(pets,
                            person => person,
                            pet => pet.Owner,
                            (person, pet) =>
                                new { OwnerName = person.Name, Pet = pet.Name })
                                .ToList();

            Assert.AreEqual("Hedlund, Magnus", query[0].OwnerName);
            Assert.AreEqual("Daisy", query[0].Pet);

            Assert.AreEqual("Adams, Terry", query[1].OwnerName);
            Assert.AreEqual("Barley", query[1].Pet);

            Assert.AreEqual("Adams, Terry", query[2].OwnerName);
            Assert.AreEqual("Boots", query[2].Pet);

            Assert.AreEqual("Weiss, Charlotte", query[3].OwnerName);
            Assert.AreEqual("Whiskers", query[3].Pet);
        }
    }
}