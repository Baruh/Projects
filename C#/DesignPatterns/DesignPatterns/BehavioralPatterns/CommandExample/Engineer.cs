namespace DesignPatterns.BehavioralPatterns.CommandExample
{
    using System.Collections.Generic;

    internal class Engineer
    {
        private Calculator calculator = new Calculator();
        private List<ICommand> commands = new List<ICommand>();
        private int current = 0;

        public double Compute(char @operator, double operand)
        {
            var command = new CalculatorCommand(this.calculator, @operator, operand);
            command.Execute();

            this.commands.Add(command);
            this.current++;

            var value = this.calculator.CurrentValue;

            return value;
        }

        public double Redo()
        {
            if (this.current < this.commands.Count)
            {                
                var command = this.commands[this.current];
                command.Execute();
                this.current++;
            }
            
            var value = this.calculator.CurrentValue;

            return value;
        }

        public double Undo()
        {
            if (this.current > 0)
            {
                this.current--;
                var command = this.commands[this.current];
                command.UnExecute();
            }

            var value = this.calculator.CurrentValue;

            return value;
        }
    }
}
