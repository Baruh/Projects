namespace DesignPatterns.CreationalPatterns.BuilderExample
{
    public interface IGameConsoleBuilder
    {
        GameConsole Console { get; }

        void BuildName();
        void BuildProcessor();
        void BuildVideoCard();
        void BuildMemory();
        void BuildProductPrice();
    }
}