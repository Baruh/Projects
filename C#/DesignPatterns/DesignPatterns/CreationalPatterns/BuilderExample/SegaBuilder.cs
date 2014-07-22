namespace DesignPatterns.CreationalPatterns.BuilderExample
{
    internal class SegaBuilder : IGameConsoleBuilder
    {
        private GameConsole console;

        public SegaBuilder()
        {
            this.console = new GameConsole();
        }

        public GameConsole Console
        {
            get { return console; }
        }

        public void BuildName()
        {
            this.console.Name = "Sega 2";
        }

        public void BuildProcessor()
        {
            this.console.Processor = Processors.Unknown;
        }

        public void BuildVideoCard()
        {
            this.console.VideoCard = VideoCards.Embedded;
        }

        public void BuildMemory()
        {
            this.console.Memory = 0.04;
        }

        public void BuildProductPrice()
        {
            this.console.Price = 15;
        }
    }
}
