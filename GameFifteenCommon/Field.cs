﻿[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class that represents the playfield.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Readonly field, holding field dimentions.
        /// </summary>
        private readonly int Dimentions;

        /// <summary>
        /// Place to keep the playfield.
        /// </summary>
        private int[,] field;

        /// <summary>
        /// Field that keeps a dictionary list for the numbers and their coordinates.
        /// </summary>
        private Dictionary<int, Coords> numberCoords;

        /// <summary>
        /// Initializes a new instance of the <see cref="Field" /> class.
        /// Constructor that initializes and fills the field with numbers.
        /// </summary>
        public Field(int dimentions)
        {
            this.Dimentions = dimentions;
            this.field = new int[this.Dimentions, this.Dimentions];
            this.numberCoords = new Dictionary<int, Coords>();
            this.GetRandomField();
        }

        /// <summary>
        /// Gets and sets field.
        /// </summary>
        /// <value>
        /// Gets and sets value for numbers coordinates.
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
        /// <param name="row">row index.</param>
        /// <param name="col">column index.</param>
        /// <returns>The value in the sell at current position in the field.</returns>
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
        /// Check if the field is solved.
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
        /// Gets playfield filled with mixed numbers form 0 to 15.
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
                    this.numberCoords.Add(numbers[index], new Coords(row, col, this.Dimentions));
                    numbers.RemoveAt(index);
                }
            }
        }

        /// <summary>
        /// Generates string representation of the field.
        /// </summary>
        /// <returns>String representation of the field.</returns>
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
        /// <returns>Returns true if number is in range or false if it's not.</returns>
        private bool IsInRange(int dimension)
        {
            if (dimension < 0 || dimension >= this.Dimentions)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if row and column are in the range of the playfield.
        /// </summary>
        /// <param name="row">Integer value for row.</param>
        /// <param name="col">Integer value for column.</param>
        private void ValidateDimensions(int row, int col)
        {
            if (!this.IsInRange(row) || !this.IsInRange(col))
            {
                throw new ArgumentOutOfRangeException("The dimensions you have provided are out of range!");
            }
        }
    }
}