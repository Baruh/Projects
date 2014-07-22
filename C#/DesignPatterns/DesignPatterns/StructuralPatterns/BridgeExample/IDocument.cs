namespace DesignPatterns.StructuralPatterns.BridgeExample
{
    internal interface IDocument
    {
        string Title { get; set; }

        string Content { get; set; }

        void Print();
    }
}
