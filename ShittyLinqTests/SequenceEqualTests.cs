using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShittyLINQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyTests
{
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class ProductA
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }

    class ProductComparer : IEqualityComparer<ProductA>
    {

        public bool Equals(ProductA x, ProductA y)
        { 
            if (ReferenceEquals(x, y)) return true;
            
            return x != null && y != null && x.Code.Equals(y.Code) && x.Name.Equals(y.Name);
        }

        public int GetHashCode(ProductA obj)
        {
            int hashProductName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            
            int hashProductCode = obj.Code.GetHashCode();
            
            return hashProductName ^ hashProductCode;
        }
    }

    /// <summary>
    /// The code for the tests is the same than in the Microsoft example
    /// for the SequenceEqual extension
    /// </summary>
    [TestClass]
    public class SequenceEqualTests
    {
        [TestMethod]
        public void When_Two_List_Are_Fill_With_Same_Objects_Then_Should_Be_Equals()
        {
            var pet1 = new Pet { Name = "Turbo", Age = 2 };
            var pet2 = new Pet { Name = "Peanut", Age = 8 };
            
            var pets1 = new List<Pet> { pet1, pet2 };
            var pets2 = new List<Pet> { pet1, pet2 };

            var equal = pets1.SequenceEqual(pets2);

            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void When_Two_List_Are_Fill_With_Same_Objects_But_Different_References_Then_Should_Be_Not_Equals()
        {
            var pet1 = new Pet() { Name = "Turbo", Age = 2 };
            var pet2 = new Pet() { Name = "Peanut", Age = 8 };

            // Create two lists of pets.
            var pets1 = new List<Pet> { pet1, pet2 };
            var pets2 =
                new List<Pet> { new Pet { Name = "Turbo", Age = 2 },
                        new Pet { Name = "Peanut", Age = 8 } };

            var equal = pets1.SequenceEqual(pets2);

            Assert.IsFalse(equal);
        }

        [TestMethod]
        public void When_Two_Lists_Are_Fill_With_Different_References_But_With_Comparer_Then_Should_Be_Equals()
        {
            ProductA[] storeA = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "orange", Code = 4 } };

            ProductA[] storeB = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "orange", Code = 4 } };

            bool equalAB = storeA.SequenceEqual(storeB, new ProductComparer());

            Assert.IsTrue(equalAB);
        }
    }
}
