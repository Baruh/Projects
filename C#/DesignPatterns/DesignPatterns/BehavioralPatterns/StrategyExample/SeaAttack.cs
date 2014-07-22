namespace DesignPatterns.BehavioralPatterns.StrategyExample
{
    using System;

    internal class SeaAttack : IAttackStrategy
    {
        public void Attack(Action<string> report)
        {
            Console.WriteLine("Attack with two submarines.");
            Console.WriteLine("After 10 minutes attack with five ships.");
            // Some conditions on the basis of which we desiting
            report("The attack was unsuccessful.");
        }
    }
}
