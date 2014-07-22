namespace DesignPatterns.BehavioralPatterns.StrategyExample
{
    using System;

    internal interface IAttackStrategy
    {
        void Attack(Action<string> report);
    }
}
