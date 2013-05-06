using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace GameFifteen
{
    public class ScoreBoard
    {
        private OrderedMultiDictionary<int, string> scoreBoard;

        public ScoreBoard()
        {
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
        }

        public void Add(int score)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", score);
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
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
