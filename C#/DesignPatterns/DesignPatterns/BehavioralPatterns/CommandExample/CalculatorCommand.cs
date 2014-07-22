namespace DesignPatterns.BehavioralPatterns.CommandExample
{
    using System;

    internal class CalculatorCommand : ICommand
    {
        private Calculator calculator;
        private char @operator;
        private double operand;

        public CalculatorCommand(Calculator initCalculator, char initOperator, double initOperand)
        {
            this.calculator = initCalculator;
            this.@operator = initOperator;
            this.operand = initOperand;
        }

        public void Execute()
        {
            this.calculator.Operation(this.@operator, this.operand);
        }

        public void UnExecute()
        {
            var undoOperation = this.OppositeOperator(this.@operator);
            this.calculator.Operation(undoOperation, this.operand);
        }

        private char OppositeOperator(char initOperator)
        {
            switch (initOperator)
            {
                case '+':
                    return '-';
                case '-':
                    return '+';
                case '*':
                    return '/';
                case '/':
                    return '*';
                default:
                    throw new ArgumentOutOfRangeException("Not supported arithmetic operation.");
            }
        }
    }
}
