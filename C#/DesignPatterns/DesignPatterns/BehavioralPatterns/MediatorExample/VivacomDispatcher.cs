namespace DesignPatterns.BehavioralPatterns.MediatorExample
{
    using System;
    using System.Collections.Generic;

    internal class VivacomDispatcher : ITelephoneDispatcher
    {
        private List<Call> calls = new List<Call>();
        private IDictionary<string, Client> clients = new Dictionary<string, Client>();

        public void Register(Client client)
        {
            if (client != null && !clients.ContainsKey(client.Number))
            {
                this.clients.Add(client.Number, client);
            }
        }

        public void Conect(string from, string to)
        {
            if (clients.ContainsKey(from))
            {
                if (clients.ContainsKey(to))
                {
                    clients[to].ReceiveCall(from);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(string.Format("The number {0} doesn't exist."), to);
                }
            }
        }


    }
}
