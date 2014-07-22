namespace DesignPatterns.CreationalPatterns.BuilderExample
{
    public class GameConsoleManufacturer
    {
        public GameConsole Construct(IGameConsoleBuilder consoleBuilder)
        {
            consoleBuilder.BuildProductPrice();
            consoleBuilder.BuildProcessor();
            consoleBuilder.BuildVideoCard();
            consoleBuilder.BuildMemory();
            consoleBuilder.BuildName();

            return consoleBuilder.Console;
        }
    }
}
