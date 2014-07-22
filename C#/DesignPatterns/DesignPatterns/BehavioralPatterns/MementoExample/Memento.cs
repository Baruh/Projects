namespace DesignPatterns.BehavioralPatterns.MementoExample
{
    internal class Memento
    {
        private int age;
        private double length;

        public Memento(int initAge, double initLength)
        {
            this.age = initAge;
            this.length = initLength;
        }

        public double Length 
        { 
            get { return this.length; }
        }

        public int Age 
        {
            get { return this.age; }
        }
    }
}
