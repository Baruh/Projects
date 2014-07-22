namespace DesignPatterns.CreationalPatterns.BuilderExample
{
    public class GameConsole
    {
        public string Name { get; set; }

        public Processors Processor { get; set; }

        public VideoCards VideoCard { get; set; }

        public double Memory { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}\nProcessor: {1}\nVideo: {2}\nMemory: {3} Gb\nPrice: {4}",
                            this.Name, this.Processor, this.VideoCard, this.Memory, this.Price);
        }
    }
}
