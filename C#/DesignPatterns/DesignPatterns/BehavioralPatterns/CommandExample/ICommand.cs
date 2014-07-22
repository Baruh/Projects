namespace DesignPatterns.BehavioralPatterns.CommandExample
{
    internal interface ICommand
    {
        void Execute();

        void UnExecute();
    }
}
