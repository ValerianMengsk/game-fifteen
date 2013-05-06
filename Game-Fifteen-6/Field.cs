using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public class Field
    {
        private int[,] field;
        private Dictionary<int, Coords> numberCoords;

        public Field()
        {
            this.field = new int[4, 4];
            this.numberCoords = new Dictionary<int, Coords>();
            GetRandomField();
        }

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

        public bool IsSolved()
        {
            int[,] matrix =
            {
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,0}
            };

            bool isSolved = true;

            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    if (this.field[row, col] != matrix[row, col])
                    {
                        isSolved = false;
                        break;
                    }
                }
            }

            return isSolved;
        }

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

        public int this[int row, int col]
        {
            get { return this.field[row, col]; }
            set { this.field[row, col] = value; }
        }

        public override string ToString()
        {
            StringBuilder fieldAsString = new StringBuilder();

            fieldAsString.Append(" -------------------\r\n");
            for (int row = 0; row < field.GetLength(0); row++)
            {
                fieldAsString.Append("|");
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 0)
                    {
                        fieldAsString.Append("    |");
                        continue;
                    }

                    fieldAsString.AppendFormat(" {0,2} |", field[row, col]);
                }

                fieldAsString.Append("\r\n");
            }

            fieldAsString.Append(" -------------------");

            return fieldAsString.ToString();
        }
    }
}
