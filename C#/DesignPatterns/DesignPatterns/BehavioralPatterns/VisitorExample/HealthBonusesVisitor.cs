namespace DesignPatterns.BehavioralPatterns.VisitorExample
{
    using System;

    internal class HealthBonusesVisitor : IVisitor
    {
        public void Visit(Person person)
        {
            if (person.HealthCareFactor < 100)
            {
                person.HealthCareFactor += 20;
                person.VacantionDay += 5;
            }
            else if (person.HealthCareFactor < 500)
            {
                person.HealthCareFactor += 5;
                person.VacantionDay += 1;
            }
            else
            {
                person.HealthCareFactor += 1;
            }
        }
    }
}
