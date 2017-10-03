namespace ShittyTests.TestHelpers
{
    public class MutablePerson : Person
    {
        public MutablePerson(string name, int age, string job, string color, int salary) : base(name, age, job, color)
        {
            this.Salary = salary;
        }

        public int Salary { get; set; }
    }
}
