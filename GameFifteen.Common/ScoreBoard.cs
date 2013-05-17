﻿[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteenCommon
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Class that deals with scores and ranking.
    /// </summary>
    public class ScoreBoard
    {
        /// <summary>
        /// OrderedMultiDictionary that keeps scores of the players.
        /// </summary>
        private readonly OrderedMultiDictionary<int, string> scores;

        /// <summary>
        /// Initializes a new instance of the <see cref="Count" /> class.
        /// </summary>
        public ScoreBoard()
        {
            this.scores = new OrderedMultiDictionary<int, string>(true);
        }

        /// <summary>
        /// Holds the number of scores.
        /// </summary>
        public int Count
        {
<<<<<<< HEAD
            get { return this.scores.Count; }
        }

        /// <summary>
        /// Makes string that represents the score board.
        /// </summary>
        /// <returns>Score board as string.</returns>
        public OrderedMultiDictionary<int, string> Scores()
        {
            return this.scores;
=======
            get 
            { 
                return scores.Count; 
            }
>>>>>>> bug fix, code update.
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

            this.scores.Add(score, name);
        }
    }
}