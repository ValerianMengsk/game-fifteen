[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteenUI
{
    using System;
    using System.Linq;
    using GameFifteenCommon;
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

        /// <summary>
        /// Printing game field, i.e. all numbers from 1 to 15
        /// on the console!
        /// </summary>
        /// <param name="field">List with numbers' fields</param>
        public void PrintField(IList<int> field)
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

        /// <summary>
        /// Printing current score board on the console!
        /// </summary>
        /// <param name="scores">scores in orderedMultiDictionary format </param>
        public void PrintScoreboard(OrderedMultiDictionary<int, string> scores)
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

        /// <summary>
        /// Print Startup Message on the Console!
        /// </summary>
        public void StartupMessage()
        {
            StringBuilder startupMessage = new StringBuilder();

            startupMessage.AppendLine("\r\nWelcome to the game “15”.");
            startupMessage.AppendLine("Please try to arrange the numbers sequentially.");
            startupMessage.AppendLine("Use 'top' to view the top scoreboard.");
            startupMessage.AppendLine("Use 'restart' to start a new game.");
            startupMessage.AppendLine("Use 'exit' to quit the game.");

            this.Write(startupMessage.ToString());
        }
    }
}
