namespace DesignPatterns.BehavioralPatterns.TemplateMethodExample
{
    using System;

    internal abstract class Pizza
    {
        public virtual void BackedBatter()
        {
            Console.WriteLine("Backed 10 minutes.");
        }

        public abstract void AddMeat();
        public abstract void AddVegetables();
        public abstract void AddCheese();
        public abstract void AddSpices();


        public void Make()
        {
            this.BackedBatter();
            this.AddMeat();
            this.AddVegetables();
            this.AddCheese();
            this.AddSpices();
        }
    }
}
