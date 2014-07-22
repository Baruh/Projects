namespace DesignPatterns.BehavioralPatterns.StateExample
{
    using System;

    internal class Engine
    {
        private EngineState engineState;

        public Engine (EngineState initEngineState)
	    {
            if (initEngineState != null)
            {
                this.engineState = initEngineState;
            }
            else
            {
                throw new ArgumentNullException("Engine state cannot be null.");
            }
	    }

        public int YearOfMade { get; set; }

        public int Power { get; set; }

        public int Depreciation { get; set; }

        public void SetNewState(EngineState newEngineState)
        {
            if (newEngineState != null)
            {
                this.engineState = newEngineState;
            }
            else
            {
                throw new ArgumentNullException("The new engine state cannot be null.");
            }
        }

        public void Work()
        {
            this.engineState.Handle(this);
            Console.WriteLine("Power: {0}, Depreciation per second: {1}", this.Power, this.Depreciation);
        }
    }
}
