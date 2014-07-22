namespace DesignPatterns.BehavioralPatterns.MementoExample
{
    using System;

    internal class Adder
    {
        public Adder(string initKind, int initAge = 0, double initLength = 0)
        {
            if (!string.IsNullOrWhiteSpace(initKind))
            {
                this.Kind = initKind;
            }
            else
            {
                throw new ArgumentException("Kind cannot be null or empty.");
            }

            this.Age = initAge;
            this.Length = initLength;
        }

        public string Kind { get; set; }

        public int Age { get; set; }

        public double Length { get; set; }

        public Memento getState()
        {
            var memento = new Memento(this.Age, this.Length);
            return memento;
        }

        public void RestorState(Memento memento)
        {
            this.Age = memento.Age;
            this.Length = memento.Length;
        }

        public override string ToString()
        {
            return string.Format("Kind: {0}, Age: {1} months, Length: {2} cm.", this.Kind, this.Age, this.Length);
        }
    }
}
