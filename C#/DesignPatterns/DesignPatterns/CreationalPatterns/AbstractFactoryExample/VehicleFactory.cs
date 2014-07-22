namespace DesignPatterns.CreationalPatterns.AbstractFactoryExample
{
    using DesignPatterns.CreationalPatterns.FactoryExample;

    public abstract class VehicleFactory
    {
        public abstract Motor CreateMotor();

        public abstract Car CreateCar();
    }
}
