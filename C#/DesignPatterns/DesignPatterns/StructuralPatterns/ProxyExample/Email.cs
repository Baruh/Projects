namespace DesignPatterns.StructuralPatterns.ProxyExample
{
    using System;

    internal class Email : IEmail
    {
        public void GoIn(string username, string password)
        {
            Console.WriteLine("I'm in the original email!");
            // do something very special
        }
    }
}
