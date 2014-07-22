namespace DesignPatterns.CreationalPatterns.ObjectPoolExample
{
    public class Military : IRecyclable
    {
        private static int initCounter = 0;

        public Military(string name = "Joh Doe", int age = 21, double damage = 10)
        {
            initCounter++;
            this.Name = name + (initCounter).ToString();
            this.Age = age;
            this.Damage = damage;            
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Damage { get; set; }

        public void Reset()
        {
            this.Name = "John Doe";
        }
    }
}
