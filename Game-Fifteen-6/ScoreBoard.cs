[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Class that deals with scores, best players, etc.
    /// </summary>
    public class ScoreBoard
    {
        /// <summary>
        /// OrderedMultiDictionary that keeps scores of past players.
        /// </summary>
        private OrderedMultiDictionary<int, string> scoreBoard;

        /// <summary>
        /// The console the game will deal with.
        /// The abstraction is increased by IRender interface.
        /// </summary>
        private IRenderable console = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreBoard" /> class.
        /// </summary>
        public ScoreBoard()
        {
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
            this.console = new ConsoleRenderer();
        }

        /// <summary>
        /// Method that add a score to the score board.
        /// Adds integer number that is the score.
        /// </summary>
        /// <param name="score">The score.</param>
        public void Add(int score)
        {
            string message = string.Format("Congratulations! You won the game in {0} moves.", score);
            this.console.Display(message);

            string name = this.console.Read("Please enter your name for the top scoreboard: ");
            this.scoreBoard.Add(score, name);
        }

        /// <summary>
        /// Makes string that contains all added scores.
        /// </summary>
        /// <returns>String of the results (human readable form).</returns>
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
                    var userName = user.Value;
                    var userScore = user.Key;

                    scoreBoardAsString.AppendFormat("{0}. {1} --> {2} moves", position, userName, userScore);
                    position++;
                }
            }

            return scoreBoardAsString.ToString();
        }
    }
}
