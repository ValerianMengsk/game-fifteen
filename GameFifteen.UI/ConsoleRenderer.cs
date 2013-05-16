[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen.UI
{
    using System;
    using System.Linq;
    using GameFifteen.Common;
    using System.Collections.Generic;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Read and Write on the console.
    /// </summary>
    public class ConsoleRenderer : IRenderable
    {
        /// <summary>
        /// Display string on the console.
        /// </summary>
        /// <param name="toDisplay">String that will be printed on the console.</param>
        public void Write(string toDisplay)
        {
            Console.WriteLine(toDisplay);
        }

        /// <summary>
        /// Show message on the console telling the user what we expect him to entere.
        /// Reading the user input.
        /// </summary>
        /// <param name="message">Message to be printed when asking for input.</param>
        /// <returns>Input data.</returns>
        public string Read(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public void PrintString(IList<int> field)
        {
            int dimensions = (int)Math.Sqrt(field.Count);
            int count = 0;
            StringBuilder fieldAsString = new StringBuilder();

            fieldAsString.AppendLine(' ' + new string('-', 19));
            for (int row = 0; row < dimensions; row++)
            {
                fieldAsString.Append("|");
                for (int col = 0; col < dimensions; col++)
                {
                    if (field[count] == 0)
                    {
                        fieldAsString.Append("    |");
                    }
                    else
                    {
                        fieldAsString.AppendFormat(" {0,2} |", field[count]);
                    }
                    count++;
                }

                fieldAsString.AppendLine();
            }
            fieldAsString.Append(' ' + new string('-', 19));
            Console.WriteLine(fieldAsString.ToString());
        }
        public void PrintScores(OrderedMultiDictionary<int, string> scores)
        {
            if (scores.Count == 0)
            {
                Write("Scoreboard is empty");
            }
            else
            {
                StringBuilder scoreBoardAsString = new StringBuilder();
                int position = 1;
                foreach (var user in scores)
                {
                    if (position == 6)
                    {
                        break;
                    }

                    var userName = user.Value;
                    var userScore = user.Key;

                    scoreBoardAsString.AppendFormat("{0}. {1} --> {2} moves\r\n", position, userName, userScore);
                    position++;
                }
            }
        }
    }
}
