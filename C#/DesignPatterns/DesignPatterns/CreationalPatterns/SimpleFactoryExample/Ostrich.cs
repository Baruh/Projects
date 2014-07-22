namespace DesignPatterns.CreationalPatterns.SimpleFactoryExample
{
    using System;

    internal class Ostrich : IAnimal
    {
        public Ostrich(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine("I am the Prime Minister of England and I don't like unemployed bulgarians.");
        }     
    }
}
