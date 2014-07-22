namespace DesignPatterns.CreationalPatterns.FactoryExample
{
    using System;

    internal class Audi : Car
    {
        public bool HasLeatherSeats { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine("I am Audi(cheaper than bmw) with {0} wheels and left the factory in {1} year.",
                this.Wheels, this.YearOfBuild);
        }
    }
}
