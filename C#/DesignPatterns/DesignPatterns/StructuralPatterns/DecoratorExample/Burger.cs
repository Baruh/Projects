namespace DesignPatterns.StructuralPatterns.DecoratorExample
{
    using System;

    public class Burger : ISandwich
    {
        private string description = "Two slices of bread, slice of tomatoes, beef";
        private double cost = 1.25;

        public string Description
        {
            get { return description; }    
        }

        public double Cost
        {
            get { return cost; }
        }
    }
}
