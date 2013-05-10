[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class for defining the coordinates in the playfield.
    /// It contains rows, columns, etc.
    /// </summary>
    public class Coords
    {
        /// <summary>
        /// Constant that hold number for dimensions.
        /// </summary>
        private const int Dimensions = 4;

        /// <summary>
        /// Field that hold a number initializing rows.
        /// </summary>
        private int row;

        /// <summary>
        /// Field that hold a number initializing columns.
        /// </summary>
        private int col;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coords" /> class.
        /// Constructor that defines current coordinates by given row and column.
        /// </summary>
        /// <param name="row">Given row.</param>
        /// <param name="col">Given column.</param>
        public Coords(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        /// <summary>
        /// Gets row, encapsulating it.
        /// </summary>
        /// <value>Property for row.</value>
        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                this.CheckIfIsInRange(value);

                this.row = value;
            }
        }

        /// <summary>
        /// Gets col, encapsulating it.
        /// </summary>
        /// <value>Property for col.</value>
        public int Col
        {
            get
            {
                return this.col;
            }

            private set
            {
                this.CheckIfIsInRange(value);

                this.col = value;
            }
        }

        /// <summary>
        /// Checks the range, if it is out of range, throws an exception.
        /// </summary>
        /// <param name="dimension">Integer number that sets the up range.</param>
        private void CheckIfIsInRange(int dimension)
        {
            if (dimension < 0 || dimension >= Dimensions)
            {
                throw new ArgumentOutOfRangeException("The value you entered for col is either too big or too small!");
            }
        }
    }
}
