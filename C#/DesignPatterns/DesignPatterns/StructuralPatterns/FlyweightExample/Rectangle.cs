namespace DesignPatterns.StructuralPatterns.FlyweightExample
{
    using System;

    internal class Rectangle : Shape
    {
        private const int ROWS = 5;
        private const int COLUMNS = 15;
        
        public override int Rows
        {
            get { return ROWS; }
        }

        public override int Columns
        {
            get { return COLUMNS; }
        }

        public override void Draw()
        {
            base.CheckForEmptyChar();
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    Console.Write(this.symbol);
                }
                Console.WriteLine();
            }            
        }
    }
}
