namespace DesignPatterns.CreationalPatterns.AbstractFactoryExample
{
    using System;

    internal class Kawasaki : Motor
    {
        public override void PrintInfo()
        {
            Console.WriteLine("Kawasaki manufactured in Germany.");
        }
    }
}
