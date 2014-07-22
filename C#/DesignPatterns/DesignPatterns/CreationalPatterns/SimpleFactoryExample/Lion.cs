namespace DesignPatterns.CreationalPatterns.SimpleFactoryExample
{
    using System;

    internal class Lion : IAnimal
    {
        public Lion(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine("I am the king of the jungle and I don't like Guns and Roses.");
        }       
    }
}
