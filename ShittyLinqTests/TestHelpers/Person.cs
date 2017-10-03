using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyTests.TestHelpers
{
    public class Person
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

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if(other == null)
            {
                return false;
            }

            return this.Name.Equals(other.Name) &&
                this.Age.Equals(other.Age) &&
                this.Job.Equals(other.Job) &&
                this.FavoriteColor.Equals(other.FavoriteColor);
        }

        public override int GetHashCode()
        {
            return TestHelper.CombineHashCodes(
                TestHelper.CombineHashCodes(this.Name, this.Age),
                TestHelper.CombineHashCodes(this.Job, this.FavoriteColor));
        }
    }
}
