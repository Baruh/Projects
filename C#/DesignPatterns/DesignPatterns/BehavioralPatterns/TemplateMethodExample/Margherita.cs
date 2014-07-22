namespace DesignPatterns.BehavioralPatterns.TemplateMethodExample
{
    using System;

    internal class Margherita : Pizza
    {
        public override void BackedBatter()
        {
            Console.WriteLine("Backed 8 minutes.");
        }

        public override void AddMeat() { }

        public override void AddVegetables() { }

        public override void AddCheese()
        {
            Console.WriteLine("Add yellow cheese."); ;
        }

        public override void AddSpices()
        {
            Console.WriteLine("Add black pepper.");
            Console.WriteLine("Add red pepper.");
        }
    }
}
