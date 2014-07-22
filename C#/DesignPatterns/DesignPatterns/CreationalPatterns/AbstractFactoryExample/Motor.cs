namespace DesignPatterns.CreationalPatterns.AbstractFactoryExample
{
    public abstract class Motor
    {
        public int Wheels { get; set; }

        public int Color { get; set; }

        public int HorsePower { get; set; }

        public abstract void PrintInfo();
    }
}
