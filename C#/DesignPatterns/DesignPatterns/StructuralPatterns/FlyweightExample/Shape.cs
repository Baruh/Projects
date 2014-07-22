namespace DesignPatterns.StructuralPatterns.FlyweightExample
{
    using System;

    public abstract class Shape
    {
        protected char symbol; // extrinsic state
        
        public abstract int Rows { get; } // intrinsic state

        public abstract int Columns { get; } // intrinsic state

        public virtual void SetSymbol(char initSymbol)
        {
            if (this.IsSymbolCorrect(initSymbol))
            {
                this.symbol = initSymbol;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The symbol " + initSymbol + " is not supported.");
            }
        }

        public abstract void Draw();

        protected void CheckForEmptyChar()
        {
            if (this.symbol == '\0')
            {
                throw new Exception("Cannot draw empty symbol.");
            }
        }

        protected virtual bool IsSymbolCorrect(char symbol)
        {
            return symbol == '*' || symbol == '+' || symbol == '@'
                || symbol == '#' || symbol == 'o' || symbol == '.';
        }
    }
}
