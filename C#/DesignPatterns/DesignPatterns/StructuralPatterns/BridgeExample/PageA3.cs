namespace DesignPatterns.StructuralPatterns.BridgeExample
{
    internal class PageA3 : PageFormat
    {
        private char symbol = '*';

        public override char BorderSymbol
        {
            get
            {
                return symbol;
            }
            protected set
            {
                this.symbol = value;
            }
        }
    }
}
