namespace DesignPatterns.StructuralPatterns.DecoratorExample
{
    internal class MayonnaiseDecorator : SandwichDecorator
    {
        private const string description = "mayonnaise";
        private const double cost = 0.40;

        public MayonnaiseDecorator(ISandwich sandwich)
            : base(sandwich)
        {
            this.Description = description;
            this.Cost = cost;
        }
    }
}
