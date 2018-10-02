using System.Collections.Generic;

namespace ShittyTests.TestHelpers
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            
            return x.Age == y.Age && x.FavoriteColor == y.FavoriteColor && x.Job == y.Job && x.Name == y.Name;
        }

        public int GetHashCode(Person obj)
        {
            return $"{obj.Age}{obj.FavoriteColor}{obj.Job}{obj.Name}".GetHashCode();
        }
    }
}