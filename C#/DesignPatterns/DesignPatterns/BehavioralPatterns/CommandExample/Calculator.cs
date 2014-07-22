namespace DesignPatterns.BehavioralPatterns.CommandExample
{
    using System;

    internal class Calculator
    {
        private double current = 0;

        public double CurrentValue
        {
            get { return this.current; }
            private set { this.current = value; }
        }

        public void Operation(char @operation, double operand)
        {
            switch (@operation)
            {
                case '+':
                    this.CurrentValue += operand;
                    break;
                case '-':
                    this.CurrentValue -= operand;
                    break;
                case '*':
                    this.CurrentValue *= operand;
                    break;
                case '/':
                    this.CurrentValue /= operand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Not supported arithmetic operation.");
            }
        }
    }
}
