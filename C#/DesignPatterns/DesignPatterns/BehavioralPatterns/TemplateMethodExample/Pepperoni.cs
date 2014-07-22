namespace DesignPatterns.BehavioralPatterns.TemplateMethodExample
{
    using System;

    internal class Pepperoni : Pizza
    {
        public override void AddMeat()
        {
            Console.WriteLine("Add salami.");
        }

        public override void AddVegetables()
        {
            Console.WriteLine("Add tomatoes");
            Console.WriteLine("Add cucumbers");
        }

        public override void AddCheese()
        {
            Console.WriteLine("Add yellow cheese.");
        }

        public override void AddSpices()
        {
            Console.WriteLine("Add black pepper.");
        }
    }
}
