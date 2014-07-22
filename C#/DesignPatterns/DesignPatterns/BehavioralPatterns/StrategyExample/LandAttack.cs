namespace DesignPatterns.BehavioralPatterns.StrategyExample
{
    using System;

    internal class LandAttack : IAttackStrategy
    {
        public void Attack(Action<string> report)
        {
            Console.WriteLine("Attack with fifty-five tanks and eight thousand soldiers.");
            Console.WriteLine("After one hour add new three thousand soldiers and ten tanks.");
            // Some conditions on the basis of which we desiting
            report("The attack was successful.");
        }
    }
}
