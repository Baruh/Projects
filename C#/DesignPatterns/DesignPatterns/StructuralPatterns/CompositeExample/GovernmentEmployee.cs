namespace DesignPatterns.StructuralPatterns.CompositeExample
{
    using System;

    public abstract class GovernmentEmployee
    {
        public GovernmentEmployee(string name, double salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public string Name { get; set; }

        public double Salary { get; set; }

        public abstract void PrintEmployeeInformation();
    }
}
