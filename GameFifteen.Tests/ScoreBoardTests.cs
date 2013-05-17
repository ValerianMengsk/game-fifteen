namespace GameFifteen.Tests
{
    using System;
    using GameFifteen;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteenCommon;
    using Wintellect.PowerCollections;
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void InitializeEmptyScoreBoardTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            string str = scoreBoard.Scores().Values.ToString();
            str += scoreBoard.Scores().Keys.ToString();
            Assert.IsTrue(str == "{}{}");
        }

        [TestMethod]
        public void AddToScoreBoard()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            scoreBoard.Add("Pesho", 23);
            scoreBoard.Add("Gosho", 13);
            scoreBoard.Add("Tosho", 17);
            string str = scoreBoard.Scores().Values.ToString();
            str += scoreBoard.Scores().Keys.ToString();

            Assert.AreEqual(str, "{Gosho,Tosho,Pesho}{13,17,23}");
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

            string str = scoreBoard.Scores().Values.ToString();
            str += scoreBoard.Scores().Keys.ToString();
            Assert.AreEqual(str, "{Tosho,Mimi,Gosho,Stamat,Kiro,Ivan,Pesho}{10,12,13,14,17,18,23}");
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

            string str = scoreBoard.Scores().Values.ToString();
            str += scoreBoard.Scores().Keys.ToString();
            Assert.AreEqual(str, "{Anonymous}{23}");
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