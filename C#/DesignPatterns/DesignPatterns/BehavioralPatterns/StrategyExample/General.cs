namespace DesignPatterns.BehavioralPatterns.StrategyExample
{
    using System;
    using System.Collections.Generic;

    internal class General
    {
        private IEnumerable<IAttackStrategy> attackStrategy;

        public General(IEnumerable<IAttackStrategy> initAttackStrategy)
        {
            if (initAttackStrategy != null)
            {
                this.attackStrategy = initAttackStrategy;
            }
            else
            {
                throw new ArgumentNullException("Attack strategy cannot be null.");
            }
        }

        public void StartAttackOperation()
        {
            foreach (var specialAttack in this.attackStrategy)
	        {
		        specialAttack.Attack((report) => Console.WriteLine(report));
	        }
        }
    }
}
