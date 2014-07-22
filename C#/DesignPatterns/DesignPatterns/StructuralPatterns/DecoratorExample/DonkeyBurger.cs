namespace DesignPatterns.StructuralPatterns.DecoratorExample
{
    public class DonkeyBurger : SandwichDecorator        
    {
        private const string description = "donkey meal";
        private const double cost = 25.67;

        public DonkeyBurger(ISandwich sandwich)
            : base(sandwich)
        {
            this.Description = description;
            this.Cost = cost;
        }

        public void printInfo()
        {
            System.Console.WriteLine("!!!Warning!!!\nTO EAT THIS BURGER YOU NEED TO BE ADULT!");
            System.Console.WriteLine("Donke burger:\nDescription: {0}.\nPrice: {1}.", base.Description + this.Description,
                base.Cost + this.Cost);
        }
    }
}
