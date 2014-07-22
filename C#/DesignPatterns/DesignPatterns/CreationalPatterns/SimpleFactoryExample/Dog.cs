namespace DesignPatterns.CreationalPatterns.SimpleFactoryExample
{
    using System;

    internal class Dog : IAnimal
    {
        public Dog(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine("I am the king of the Lyulin and I love Iordanka Fandakova.");
        }     
    }
}
