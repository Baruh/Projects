namespace DesignPatterns.CreationalPatterns.FactoryExample
{
    public class TurkishManufacturer : CarManufacturer
    {
        public override Car CreateCar()
        {
            var audi = new Audi();
            audi.HasLeatherSeats = false;
            audi.YearOfBuild = 2014;
            audi.Wheels = 4;

            return audi;
        }
    }
}
