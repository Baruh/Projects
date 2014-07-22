namespace DesignPatterns.BehavioralPatterns.MediatorExample
{
    using System;

    internal class Call
    {  
        public string CallFromNumber { get; set; }

        public string CallToNumber { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public double PricePerMinute { get; set; }
    }
}
