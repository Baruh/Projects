namespace DesignPatterns.CreationalPatterns.AbstractFactoryExample
{
    using System;

    internal class BalkanMotor : Motor
    {
        public override void PrintInfo()
        {
            Console.WriteLine("Balkan motor manufactured in Bulgaria.");
        }
    }
}
