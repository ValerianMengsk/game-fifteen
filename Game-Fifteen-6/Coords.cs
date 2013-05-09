namespace GameFifteen
{
    using System;
    using System.Linq;

    public class Coords
    {
        private const int Dimensions = 4;
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
                return this.row;
            }

            private set
            {
                CheckIfIsInRange(value);

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            private set
            {
                CheckIfIsInRange(value);

                this.col = value;
            }
        }

        private void CheckIfIsInRange(int dimension)
        {
            if (dimension < 0 || dimension >= Dimensions)
            {
                throw new ArgumentOutOfRangeException("The value you entered for col is either too big or too small!");
            }
        }
    }
}
