namespace DesignPatterns.CreationalPatterns.FactoryExample
{
    using System;

    public abstract class Car
    {
        public int Wheels { get; set; }

        public int YearOfBuild { get; set; }

        public abstract void PrintInfo();
    }
}
