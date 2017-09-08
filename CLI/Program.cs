using System;
using System.Collections.Generic;
using ShittyLINQ;

namespace CLI
{
    class Program
    {
        class Person
        {
            public Person(string name, int age, string job, string color)
            {
                Name = name;
                Age = age;
                Job = job;
                FavoriteColor = color;
            }

            public string Name { get; private set; }
            public int Age { get; private set; }
            public string Job { get; private set; }
            public string FavoriteColor { get; private set; }

            public Person WithName(string value) { return value == Name ? this : new Person(value, Age, Job, FavoriteColor); }
            public Person WithAge(int value) { return value == Age ? this : new Person(Name, value, Job, FavoriteColor); }
            public Person WithJob(string value) { return value == Job ? this : new Person(Name, Age, value, FavoriteColor); }
            public Person WithFavoriteColor(string value) { return value == FavoriteColor ? this : new Person(Name, Age, Job, value); }

            public override string ToString()
            {
                return $"{Name}, {Age}, {Job}, {FavoriteColor}";
            }
        }
        private static List<Person> _data = new List<Person> {
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

        /// <summary>
        /// Produces some console output to show off ShittyLINQ.
        /// </summary>
        static void Main(string[] args)
        {
            Action<Person> print = x => Console.WriteLine(x);
            Func<Person, bool> over35 = x => x.Age > 35;
            Func<Person, bool> isDev = x => x.Job == "Dev";
            Func<Person, bool> likesYellow = x => x.FavoriteColor == "Yellow";
            Func<int, Person, int> count = (x, y) => x + 1;
            Func<string, string, string> csvNames = (x, y) => x + (string.IsNullOrEmpty(x) ? string.Empty : ",") + y;
            Func<string, string> getFirstName = x => x.Split(' ')[0];
            Func<Person, string> getName = x => x.Name;

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("----------------- Using the methods that have their own logic ------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var oldDevsThatLikeYellow = _data.Filter(over35).Filter(isDev).Filter(likesYellow);
            oldDevsThatLikeYellow.ForEach(print);
            var howMany = oldDevsThatLikeYellow.Foldl(0, count);
            var names = oldDevsThatLikeYellow.Map(getName).Map(getFirstName).Foldl(string.Empty, csvNames);
            Console.WriteLine($"We have {howMany} old devs who like the collor yellow!");
            Console.WriteLine($"Here are their names in CSV format: {names}");


            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("----------------------- Using the methods that reuse Foldl ---------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var oldDevsThatLikeYellow2 = _data.Where(over35).Where(isDev).Where(likesYellow);
            oldDevsThatLikeYellow2.ForEach(print);
            var howMany2 = oldDevsThatLikeYellow2.Aggregate(0, count);
            var names2 = oldDevsThatLikeYellow2.Select(getName).Select(getFirstName).Aggregate(string.Empty, csvNames);
            Console.WriteLine($"We have {howMany} old devs who like the collor yellow!");
            Console.WriteLine($"Here are their names in CSV format: {names}");

            Console.ReadLine();
        }
    }
}