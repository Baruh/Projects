namespace DesignPatterns.StructuralPatterns.DecoratorExample
{
    using System;

    public class SandwichDecorator : ISandwich
    {
        private string description = "nothing";
        private double cost = 0;
        private ISandwich sandwich = null;

        public SandwichDecorator(ISandwich initSandwich)
        {
            this.sandwich = initSandwich;
        }

        public string Description
        {
            get
            {
                return string.Format("{0}, {1}", this.sandwich.Description, description);
            }
            protected set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.description = value;
                }
                else
                {
                    throw new ArgumentNullException("The description cannot be null or empty string.");
                }
            }
        }

        public double Cost
        {
            get
            {
                return this.sandwich.Cost + cost;
            }
            protected set
            {
                if (value >= 0)
                {
                    this.cost = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The cost value cannot be negative number.");
                }
            }
        }

    }
}
