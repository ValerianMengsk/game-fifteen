[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class that works on the playfield.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Sets constant for the range of the playfield.
        /// </summary>
        private const int Dimesions = 4;

        /// <summary>
        /// Field that keep the values for the playfield's sells.
        /// </summary>
        private int[,] field;

        /// <summary>
        /// Field that keeps a dictionary list for the number and its current coordinates.
        /// </summary>
        private Dictionary<int, Coords> numberCoords;

        /// <summary>
        /// Initializes a new instance of the <see cref="Field" /> class.
        /// Constructor that sets initial field.
        /// </summary>
        public Field()
        {
            this.field = new int[Dimesions, Dimesions];
            this.numberCoords = new Dictionary<int, Coords>();
            this.GetRandomField();
        }

        /// <summary>
        /// Gets and sets, encapsulating field.
        /// </summary>
        /// <value>
        /// Gets and sets field.
        /// </value>
        public Dictionary<int, Coords> NumberCoords
        {
            get
            {
                return this.numberCoords;
            }

            private set
            {
                this.numberCoords = value;
            }
        }

        /// <summary>
        /// Indexer for the class that set a sell be rows and columns.
        /// </summary>
        /// <param name="row">Set the row.</param>
        /// <param name="col">Set the column.</param>
        /// <returns>The value in the indexed sell.</returns>
        public int this[int row, int col]
        {
            get 
            {
                this.ValidateDimensions(row, col);

                return this.field[row, col];
            }

            set 
            {
                this.ValidateDimensions(row, col);

                this.field[row, col] = value;
            }
        }

        /// <summary>
        /// Check if the quest is solved.
        /// </summary>
        /// <returns>Returns true or false.</returns>
        public bool IsSolved()
        {
            int[,] matrix =
            {
                {
                    1, 2, 3, 4
                },
                {
                    5, 6, 7, 8
                },
                {
                    9, 10, 11, 12
                },
                {
                    13, 14, 15, 0
                }
            };

            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    if (this.field[row, col] != matrix[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the sell from the playfield (random).
        /// </summary>
        public void GetRandomField()
        {
            this.numberCoords.Clear();
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Random randomIndex = new Random();

            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    int index = randomIndex.Next(0, numbers.Count);
                    this.field[row, col] = numbers[index];
                    this.numberCoords.Add(numbers[index], new Coords(row, col));
                    numbers.RemoveAt(index);
                }
            }
        }

        /// <summary>
        /// Draws the picture of the field in some way for fancy looking.
        /// </summary>
        /// <returns>A multiline string of the field.</returns>
        public override string ToString()
        {
            StringBuilder fieldAsString = new StringBuilder();

            fieldAsString.Append(" -------------------\r\n");
            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                fieldAsString.Append("|");
                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    if (this.field[row, col] == 0)
                    {
                        fieldAsString.Append("    |");
                        continue;
                    }

                    fieldAsString.AppendFormat(" {0,2} |", this.field[row, col]);
                }

                fieldAsString.Append("\r\n");
            }

            fieldAsString.Append(" -------------------");

            return fieldAsString.ToString();
        }

        /// <summary>
        /// Checks if integer number is in range of the field.
        /// </summary>
        /// <param name="dimension">Integer number to be checked.</param>
        /// <returns>Gives true or false is the number is in range.</returns>
        private bool IsInRange(int dimension)
        {
            if (dimension < 0 || dimension >= Dimesions)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate all parameters used in the coordinate a once.
        /// Check both (row and column) are in the range of the playfield.
        /// </summary>
        /// <param name="row">The given number for row.</param>
        /// <param name="col">The given number for column.</param>
        private void ValidateDimensions(int row, int col)
        {
            if (!this.IsInRange(row) || !this.IsInRange(col))
            {
                throw new ArgumentOutOfRangeException("The dimensions you have provided are out of range!");
            }
        }
    }
}
