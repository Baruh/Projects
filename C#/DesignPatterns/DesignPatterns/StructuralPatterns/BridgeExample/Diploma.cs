namespace DesignPatterns.StructuralPatterns.BridgeExample
{
    using System;
    using System.Linq;

    internal class Diploma : IDocument
    {
        private readonly PageFormat pageFormat;

        private string title = "Diploma";
        private string content = "Bla, bla, bla...";

        public Diploma(PageFormat format)
        {
            this.pageFormat = format;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }

        public void Print()
        {
            Console.WriteLine(string.Join("", Enumerable.Repeat(this.pageFormat.BorderSymbol, 20)));
            Console.WriteLine("Title: {0}", this.Title);
            Console.WriteLine("Content: {0}", this.Content);
            Console.WriteLine(string.Join("", Enumerable.Repeat(this.pageFormat.BorderSymbol, 20)));
        }
    }
}
