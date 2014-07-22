namespace DesignPatterns.CreationalPatterns.AbstractFactoryExample
{
    using System;
    using DesignPatterns.CreationalPatterns.FactoryExample;

    internal class Trabant : Car
    {
        public override void PrintInfo()
        {
            Console.WriteLine("Trabant manufactured in Bulgaria.");
        }
    }
}
