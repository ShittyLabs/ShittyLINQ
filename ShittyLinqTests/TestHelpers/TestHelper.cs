using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ShittyTests.TestHelpers
{
    public static class TestHelper
    { 
        public static void AssertCollectionsAreSame<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.AreEqual(expected.Count(), actual.Count());

            for(int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i), actual.ElementAt(i));
            }
        }

        public static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person("Vladamir Littefair", 58,"Dev","Yellow"),
                new Person("Lamond Roscrigg", 67,"QA","Violet"),
                new Person("King Gossage", 49,"PM","Red"),
                new Person("Ailis Cadreman", 49,"QA","Blue"),
                new Person("Cassie Dickens", 40,"Dev","Orange"),
                new Person("Hanny Ritelli", 37,"Dev","Yellow"),
                new Person("Rani Moulds", 71,"QA","Blue"),
                new Person("Dalis Ick", 67,"Dev","Green"),
                new Person("Nahum Andrault", 58,"PM","Yellow"),
                new Person("Claribel Sunnucks", 56,"QA","Yellow"),
                new Person("Willem McCandless", 60,"Dev","Yellow"),
                new Person("Mahmud Domelaw", 25,"QA","Yellow"),
                new Person("Hollyanne Menhenitt", 20,"Dev","Red"),
                new Person("Mario Wooton", 63,"Dev","Violet"),
                new Person("Melany Coppock.", 54,"PM","Green"),
                new Person("Kristy Laterza", 60,"PM","Orange"),
                new Person("Sileas Royston", 46,"PM","Yellow"),
                new Person("Althea Durram", 66,"PM","Red"),
                new Person("Michell Fowkes", 69,"Dev","Orange"),
                new Person("Lynde Farlam", 44,"QA","Green"),
                new Person("Lyn MacNish", 74,"QA","Blue"),
                new Person("Stephana Jameson", 18,"PM","Green"),
                new Person("Kit Zanetello", 38,"PM","Yellow"),
                new Person("Bettina Rook", 52,"PM","Yellow"),
                new Person("Amargo Ostridge", 76,"QA","Green"),
                new Person("Darlleen Northen", 30,"QA","Blue"),
                new Person("Laverna Goodswen", 36,"QA","Yellow"),
                new Person("Dallis Coddington", 31,"QA","Violet"),
                new Person("Zachary Vouls", 34,"PM","Yellow"),
                new Person("Anderson Pley", 69,"PM","Yellow"),
                new Person("Alice Regorz", 52,"QA","Green"),
                new Person("Brendin Dines", 56,"PM","Blue"),
                new Person("Alina Brissard", 33,"Dev","Green"),
                new Person("Ashbey O'Geneay", 68,"Dev","Green"),
                new Person("Skell Lantry", 74,"PM","Yellow"),
                new Person("Yehudi Norquay", 30,"PM","Blue"),
                new Person("Adoree Piesold", 36,"Dev","Yellow"),
                new Person("Trista Formilli", 78,"QA","Blue"),
                new Person("Quinn Fahey", 54,"QA","Yellow"),
                new Person("Madelina Gobel", 66,"QA","Yellow"),
                new Person("Thomasine Laweles", 30,"QA","Yellow"),
                new Person("Adelind Albrooke", 27,"Dev","Violet"),
                new Person("Efrem Hutchinson", 49,"PM","Green"),
                new Person("Templeton Shirland", 20,"Dev","Yellow"),
                new Person("Clo Housaman", 69,"QA","Violet"),
                new Person("Read McCutheon", 35,"PM","Green"),
                new Person("Tyson Barrus", 34,"QA","Orange"),
                new Person("Margarita Marlin", 28,"Dev","Violet"),
                new Person("Basia Francke", 77,"PM","Green"),
                new Person("Gusti Durand", 32,"Dev","Red"),
                new Person("Eleanore Izkovici", 40,"PM","Violet"),
                new Person("Arthur Gregoletti", 64,"Dev","Red"),
                new Person("Cchaddie Dinnington", 40,"Dev","Yellow"),
                new Person("Isaiah Schaumaker", 56,"QA","Blue"),
                new Person("Grantham Ellington", 22,"Dev","Blue"),
                new Person("Christos Moro", 70,"QA","Red"),
                new Person("Abbey Stading", 71,"QA","Violet"),
                new Person("Fiona Abbay", 35,"PM","Green"),
                new Person("Barnaby Bilbey", 20,"QA","Green"),
                new Person("Ewart Murkin", 76,"PM","Red"),
                new Person("Elena Vobes", 62,"Dev","Blue"),
                new Person("Cyrill Algy", 51,"QA","Red"),
                new Person("Kissie Havercroft", 73,"PM","Blue"),
                new Person("Dyana Ragborne", 54,"PM","Red"),
                new Person("Almira Dunnion", 44,"Dev","Orange"),
                new Person("Wynn Piercy", 51,"Dev","Green"),
                new Person("Gib Eddies", 77,"Dev","Red"),
                new Person("Noel Heathcoat", 76,"PM","Green"),
                new Person("Rowan Danzey", 66,"QA","Yellow"),
                new Person("Helenelizabeth Gorelli", 24,"PM","Blue"),
                new Person("Grier McCafferty", 30,"PM","Blue"),
                new Person("Welbie Bloxsome", 57,"PM","Orange"),
                new Person("Caryl Longson", 77,"Dev","Violet"),
                new Person("Joshua Myles", 25,"Dev","Orange"),
                new Person("Rollo Skidmore", 71,"Dev","Yellow"),
                new Person("Cassaundra MacCurley", 41,"Dev","Yellow"),
                new Person("Chloette MacConnell", 73,"PM","Green"),
                new Person("Sal Dudderidge", 68,"PM","Yellow"),
                new Person("Marlin Braitling", 28,"QA","Yellow"),
                new Person("Tynan Issacov", 73,"Dev","Violet"),
                new Person("Sally Lawlance", 31,"QA","Yellow"),
                new Person("Lou Rochford", 64,"Dev","Orange"),
                new Person("Denyse Reide", 66,"QA","Orange"),
                new Person("Terrell Bedburrow", 72,"PM","Violet"),
                new Person("Gabriello Ellaway", 49,"Dev","Green"),
                new Person("Daniella Morkham", 53,"PM","Orange"),
                new Person("Basil Tidridge", 20,"PM","Orange"),
                new Person("Lynnette Langlois", 34,"QA","Green"),
                new Person("Dolli Linstead", 26,"Dev","Blue"),
                new Person("Garreth Carlaw", 67,"QA","Yellow"),
                new Person("Agneta Gurling", 37,"PM","Green"),
                new Person("Che Reynold", 47,"Dev","Green"),
                new Person("Heloise Shorton", 47,"QA","Yellow"),
                new Person("Cornelius Fuente", 20,"QA","Violet"),
                new Person("Jayme Loxly", 26,"Dev","Orange"),
                new Person("Mela De Malchar", 62,"PM","Green"),
                new Person("Abba Schroeder", 55,"Dev","Yellow"),
                new Person("Hermie Defau", 22,"Dev","Blue"),
                new Person("Keslie Bernath", 51,"PM","Orange"),
                new Person("Jayson Reeders", 41,"QA","Yellow")
            };
        }

        public static int CombineHashCodes(object first, object second)
        {
            int hash = 17;
            hash = hash * 31 + first.GetHashCode();
            hash = hash * 31 + second.GetHashCode();
            return hash;
        }
    }
}
