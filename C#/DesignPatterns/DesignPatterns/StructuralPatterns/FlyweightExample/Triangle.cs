namespace DesignPatterns.StructuralPatterns.FlyweightExample
{
    using System;

    internal class Triangle : Shape
    {
        private const int ROWS = 4;
        private const int COLUMNS = 7;
        
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
            int padding = COLUMNS / 2;
            for (int i = 0; i < ROWS; i++)
            {
                int j = 0;
                for (; j < COLUMNS / 2; j++)
                {
                    if (j < padding)
                    {
                        Console.Write(" ");
                        continue;
                    }
                    Console.Write(this.symbol);
                }
                for (; j >= 0; j--)
                {
                    if (j < padding)
                    {
                        Console.Write(" ");
                        continue;
                    }
                    Console.Write(this.symbol);
                }
                padding--;
                Console.WriteLine();
            }
        }
    }
}
