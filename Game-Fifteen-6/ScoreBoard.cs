namespace GameFifteen
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ScoreBoard
    {
        private OrderedMultiDictionary<int, string> scoreBoard;
        private IRenderer console = null;

        public ScoreBoard()
        {
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
            this.console = new ConsoleRenderer();
        }

        public void Add(int score)
        {
            string message = string.Format("Congratulations! You won the game in {0} moves.", score);
            this.console.Display(message);

            string name = this.console.Read("Please enter your name for the top scoreboard: ");
            this.scoreBoard.Add(score, name);
        }

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
