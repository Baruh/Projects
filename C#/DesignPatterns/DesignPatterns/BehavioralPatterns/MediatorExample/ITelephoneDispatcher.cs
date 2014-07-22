namespace DesignPatterns.BehavioralPatterns.MediatorExample
{
    using System;

    internal interface ITelephoneDispatcher
    {
        void Register(Client client);

        void Conect(string from, string to);
        
    }
}
