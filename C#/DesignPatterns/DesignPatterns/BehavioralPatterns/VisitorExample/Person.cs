namespace DesignPatterns.BehavioralPatterns.VisitorExample
{
    internal abstract class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
        
        public int HealthCareFactor { get; set; }

        public int VacantionDay { get; set; }

        public bool IsEmployed { get; set; }

        public abstract void Accept(IVisitor visitor);
    }
}
