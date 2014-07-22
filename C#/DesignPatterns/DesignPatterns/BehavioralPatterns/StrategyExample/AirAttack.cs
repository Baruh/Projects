namespace DesignPatterns.BehavioralPatterns.StrategyExample
{
    using System;

    internal class AirAttack : IAttackStrategy
    {
        public void Attack(Action<string> report)
        {
            Console.WriteLine("Attack with ten bomber.");
            // Some conditions on the basis of which we desiting
            report("The attack was unsuccessful. The bombers missed the target.");
        }
    }
}
