namespace DesignPatterns.StructuralPatterns.DecoratorExample
{
    public class KetchupDecorator : SandwichDecorator
    {
        private const string description = "ketchup";
        private const double cost = 0.30;

        public KetchupDecorator(ISandwich sandwich)
            : base(sandwich)
        {
            this.Description = description;
            this.Cost = cost;
        }
    }
}
