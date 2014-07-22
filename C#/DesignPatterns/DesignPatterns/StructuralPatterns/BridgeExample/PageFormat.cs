namespace DesignPatterns.StructuralPatterns.BridgeExample
{
    internal abstract class PageFormat
    {
        public double Width { get; protected set; }

        public double Height { get; protected set; }

        public abstract char BorderSymbol { get; protected set; }
    }
}
