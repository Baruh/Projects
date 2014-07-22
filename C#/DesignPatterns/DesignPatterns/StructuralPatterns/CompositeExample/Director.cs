namespace DesignPatterns.StructuralPatterns.CompositeExample
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Director : GovernmentEmployee
    {        
        public Director(string name = "Undefined", double salary = 1.0, int mandate = 4)
            : base(name, salary)
        {
            this.Mandate = mandate;
            if (this.Employees == null)
            {
                this.Employees = new List<GovernmentEmployee>();
            }
        }

        public int Mandate { get; set; }

        public List<GovernmentEmployee> Employees { get; set; }

        public void HiresEmployee(GovernmentEmployee employee)
        {
            if (employee != null)
            {
                this.Employees.Add(employee);
            }
            else
            {
                throw new ArgumentNullException("Employee cannot be null.");
            }
        }

        public void FireEmployee(string name)
        {
            var i = 0;
            while (i < this.Employees.Count)
            {
                if (string.Equals(this.Employees[i].Name, name))
                {
                    break;
                }
                i++;
            }

            this.Employees.RemoveAt(i);
        }

        public override void PrintEmployeeInformation()
        {
            Console.WriteLine("Director\nName: {0}, Salary: {1}, Mandate: {2}\nEmployees",
                                            this.Name, this.Salary, this.Mandate);
            Parallel.ForEach(this.Employees, employee => employee.PrintEmployeeInformation());
        } 
    }
}
