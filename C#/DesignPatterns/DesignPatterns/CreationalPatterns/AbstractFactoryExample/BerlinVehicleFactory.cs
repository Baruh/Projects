namespace DesignPatterns.CreationalPatterns.AbstractFactoryExample
{
    using DesignPatterns.CreationalPatterns.FactoryExample;

    public class BerlinVehicleFactory : VehicleFactory
    {
        public override Motor CreateMotor()
        {
            return new Kawasaki();
        }

        public override Car CreateCar()
        {
            return new Audi();
        }
    }
}
