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
        private const int Dimensions = 4;

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
                if (value < 0 || value >= Dimensions)
                {
                    throw new ArgumentOutOfRangeException("The value you entered for row is either too big or too small!");
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
                if (value < 0 || value >= Dimensions)
                {
                    throw new ArgumentOutOfRangeException("The value you entered for col is either too big or too small!");
                }

                col = value;
            }
        }
    }
}
