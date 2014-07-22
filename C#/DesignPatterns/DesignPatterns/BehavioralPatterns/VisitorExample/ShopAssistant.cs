namespace DesignPatterns.BehavioralPatterns.VisitorExample
{
    using System;
    internal class ShopAssistant : Person
    {
        public void ShowInformation()
        {
            Console.WriteLine("Name: {0}, Age: {1}, Health: {2}, Employed: {3}, Vacation Days: {4}", this.Name, this.Age,
                this.HealthCareFactor, this.IsEmployed, this.VacantionDay);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
