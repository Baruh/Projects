namespace DesignPatterns.CreationalPatterns.AbstractFactoryExample
{
    using DesignPatterns.CreationalPatterns.FactoryExample;

    public class BurgasVehicleFactory : VehicleFactory
    {
        public override Motor CreateMotor()
        {
            return new BalkanMotor();
        }
        
        public override Car CreateCar()
        {
            return new Trabant();
        }
    }
}
