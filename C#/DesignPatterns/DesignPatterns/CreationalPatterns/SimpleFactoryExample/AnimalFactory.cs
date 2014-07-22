namespace DesignPatterns.CreationalPatterns.SimpleFactoryExample
{
    using System;

    public static class AnimalFactory
    {
        public static IAnimal CreateAnimal(AnimalType type, string name)
        {
            switch (type)
            {
                case AnimalType.Dog:
                    return new Dog(name);
                case AnimalType.Lion:
                    return new Lion(name);
                case AnimalType.Ostrich:
                    return new Ostrich(name);
                default:
                    throw new ArgumentException("The animal " + type.ToString() + " can not be created because is not part of our animal.");
            }
        }
    }
}
