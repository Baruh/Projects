namespace DesignPatterns.CreationalPatterns.BuilderExample
{
    internal class XBoxBuilder : IGameConsoleBuilder
    {
        private GameConsole console;

        public XBoxBuilder()
        {
            this.console = new GameConsole();
        }

        public GameConsole Console
        {
            get { return console; }
        }

        public void BuildName()
        {
            this.console.Name = "XBox 360";
        }

        public void BuildProcessor()
        {
            this.console.Processor = Processors.Intel;
        }

        public void BuildVideoCard()
        {
            this.console.VideoCard = VideoCards.NVidia;
        }

        public void BuildMemory()
        {
            this.console.Memory = 100;
        }

        public void BuildProductPrice()
        {
            this.console.Price = 380;
        }
    }
}
