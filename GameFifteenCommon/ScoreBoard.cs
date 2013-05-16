[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Class that deals with scores and ranking.
    /// </summary>
    public class ScoreBoard
    {
        /// <summary>
        /// OrderedMultiDictionary that keeps scores of the players.
        /// </summary>
        private readonly OrderedMultiDictionary<int, string> scoreBoard;

        /// <summary>
        /// Controler which will handle the input an output.
        /// </summary>
        private readonly IRendable console = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreBoard" /> class.
        /// </summary>
        public ScoreBoard()
        {
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
            this.console = new ConsoleRenderer();
        }

        /// <summary>
        /// Method that adds a user to the score board.
        /// </summary>
        public void Add(string name, int score)
        {
            if (name == null)
            {
                throw new ArgumentNullException("The name can not be null!");
            }
            else if (name == string.Empty)
            {
                name = "Anonymous";
            }

            if (score < 0)
            {
                throw new ArgumentOutOfRangeException("Score can not be negative!");
            }

            this.scoreBoard.Add(score, name);
        }

        /// <summary>
        /// Makes string that represents the score board.
        /// </summary>
        /// <returns>Score board as string.</returns>
        public override string ToString()
        {
            StringBuilder scoreBoardAsString = new StringBuilder();

            if (this.scoreBoard.Count == 0)
            {
                scoreBoardAsString.Append("Scoreboard is empty.");
            }
            else
            {
                int position = 1;

                foreach (var user in this.scoreBoard)
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

            return scoreBoardAsString.ToString();
        }
    }
}
