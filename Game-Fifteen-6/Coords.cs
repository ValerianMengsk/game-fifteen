using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public class Coords
    {
        private int row;
        private int col;

        public Coords(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return row;
            }

            private set
            {
                if (value < 0 || value >= int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The row is either too big or too small!");
                }

                row = value;
            }
        }

        public int Col
        {
            get
            {
                return col;
            }

            private set
            {
                if (value < 0 || value >= int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The col is either too big or too small!");
                }

                col = value;
            }
        }
    }
}
