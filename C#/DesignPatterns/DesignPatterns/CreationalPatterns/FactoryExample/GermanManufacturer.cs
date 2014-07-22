namespace DesignPatterns.CreationalPatterns.FactoryExample
{
    public class GermanManufacturer : CarManufacturer
    {
        public override Car CreateCar()
        {
            var audi = new Audi();
            audi.HasLeatherSeats = true;
            audi.YearOfBuild = 2013;
            audi.Wheels = 4;

            return audi;
        }
    }
}
