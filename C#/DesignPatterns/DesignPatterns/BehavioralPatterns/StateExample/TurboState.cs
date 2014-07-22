namespace DesignPatterns.BehavioralPatterns.StateExample
{
    internal class TurboState : EngineState
    {
        public override void Handle(Engine engine)
        {
            engine.Power = 800;
            engine.Depreciation = 65;
        }
    }
}
