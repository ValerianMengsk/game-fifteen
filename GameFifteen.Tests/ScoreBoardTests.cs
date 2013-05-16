namespace GameFifteen.Tests
{
    using System;
    using GameFifteen;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteenCommon;

    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void InitializeEmptyScoreBoardTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            Assert.IsTrue(scoreBoard.ToString() == "Scoreboard is empty.");
        }

        [TestMethod]
        public void AddToScoreBoard()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            scoreBoard.Add("Pesho", 23);
            scoreBoard.Add("Gosho", 13);
            scoreBoard.Add("Tosho", 17);

            Assert.AreEqual(scoreBoard.ToString(), "1. {Gosho} --> 13 moves\r\n2. {Tosho} --> 17 moves\r\n3. {Pesho} --> 23 moves\r\n");
        }

        [TestMethod]
        public void AddMoreThanFiveOnScoreBoardTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            scoreBoard.Add("Pesho", 23);
            scoreBoard.Add("Gosho", 13);
            scoreBoard.Add("Ivan", 18);
            scoreBoard.Add("Kiro", 17);
            scoreBoard.Add("Stamat", 14);
            scoreBoard.Add("Mimi", 12);
            scoreBoard.Add("Tosho", 10);

            Assert.AreEqual(scoreBoard.ToString(), "1. {Tosho} --> 10 moves\r\n2. {Mimi} --> 12 moves\r\n3. {Gosho} --> 13 moves\r\n4. {Stamat} --> 14 moves\r\n5. {Kiro} --> 17 moves\r\n");
        }

        [TestMethod]
        public void AddShortMaxValueNumberOfPlayersTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            for (int i = 0; i < short.MaxValue; i++)
            {
                scoreBoard.Add(i.ToString(), 23);
            }
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void AddTwoPlayersWithSameNameAndScoreTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            scoreBoard.Add("Pesho", 23);
            scoreBoard.Add("Pesho", 23);
        }

        [TestMethod]
        public void AddEmptyNameToScoreBoard()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.Add(string.Empty, 23);

            Assert.AreEqual(scoreBoard.ToString(), "1. {Anonymous} --> 23 moves\r\n");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullNameToScoreBoard()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.Add(null, 23);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeScoreTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.Add("pesho", -23);
        }
    }
}
