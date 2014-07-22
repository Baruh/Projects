using System;
namespace DesignPatterns.StructuralPatterns.CompositeExample
{
    public class CityHallEmployee : GovernmentEmployee
    {
        public CityHallEmployee(string name, double salary, string education = "unknown")
            : base(name, salary)
        {
            this.Education = education;
        }

        public string Education { get; set; }

        public override void PrintEmployeeInformation()
        {
            Console.WriteLine("Name: {0}, Salary: {1}, Education: {2}", this.Name, this.Salary, this.Education);
        }
    }
}
