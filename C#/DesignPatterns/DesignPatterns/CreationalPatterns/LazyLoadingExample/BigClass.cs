namespace DesignPatterns.CreationalPatterns.LazyLoadingExample
{
    public class BigClass
    {
        public BigClass() : this(0) {}

        public BigClass(int size)
        {
            System.Console.WriteLine("I was created");
            this.Size = size;
        }

        public int Size { get; private set; }

        public override string ToString()
        {
            return string.Format("I am the Biggest class in this application. My size is {0}", this.Size);
        }
    }
}
