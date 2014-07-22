namespace DesignPatterns.CreationalPatterns.BuilderExample
{
    internal class PlayStationBuilder : IGameConsoleBuilder
    {
        private GameConsole console;

        public PlayStationBuilder()
        {
            this.console = new GameConsole();
        }

        public GameConsole Console
        {
            get { return console; }
        }

        public void BuildName()
        {
            this.console.Name = "PlayStation 4";
        }

        public void BuildProcessor()
        {
            this.console.Processor = Processors.AMD;
        }

        public void BuildVideoCard()
        {
            this.console.VideoCard = VideoCards.Radeon;
        }

        public void BuildMemory()
        {
            this.console.Memory = 120;
        }

        public void BuildProductPrice()
        {
            this.console.Price = 450;
        }
    }
}
