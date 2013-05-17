namespace GameFifteen.Tests
{
    using System;
    using GameFifteen;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteenCommon;

    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void FieldsEqualLength()
        {
            Field firstGameField = new Field(4);
            Field secondGameField = new Field(4);

            int firstGameFieldLength = firstGameField.ToString().Length;
            int secondGameFieldLength = secondGameField.ToString().Length;

            Assert.AreEqual(firstGameFieldLength, secondGameFieldLength);
        }

        [TestMethod]
        public void FieldNumbersCountTest()
        {
            Field gameField = new Field(4);
            int numbersCount = gameField.NumberCoords.Count;

            Assert.AreEqual(16, numbersCount);
        }

        [TestMethod]
        public void FieldIsSolvedTest()
        {
            Field gameField = new Field(4);
            bool isSolved = gameField.IsSolved();

            Assert.IsFalse(isSolved);
        }

        [TestMethod]
        public void GetRandomFieldTest()
        {
            Field gameField = new Field(4);
            var numbersBefore = gameField.NumberCoords;

            gameField = new Field(4);
            gameField.GetRandomField();

            var numbersAfter = gameField.NumberCoords;

            Assert.IsFalse(numbersBefore.Equals(numbersAfter));
        }

        [TestMethod]
        public void SolvedFieldTest()
        {
            Field gameField = new Field(4);
            int number = 1;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    gameField[row, col] = number;
                    number++;
                }
            }

            gameField[3, 3] = 0;

            Assert.IsTrue(gameField.IsSolved());
        }

        [TestMethod]
        public void NumberCoordsTest()
        {
            Field gameField = new Field(4);
            var numbers = gameField.NumberCoords;

            Assert.AreEqual(16, numbers.Count);
        }

        [TestMethod]
        public void FieldGetNumberTest()
        {
            Field gameField = new Field(4);

            var number = gameField[0, 0];

            bool isValidNumber = number >= 0 && number < 16;

            Assert.IsTrue(isValidNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FieldGetNumberNegativeDimentionsTest()
        {
            Field gameField = new Field(4);

            var number = gameField[-10, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FieldGetNumberTooBigDimentionsTest()
        {
            Field gameField = new Field(4);

            var number = gameField[10, 10];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FieldInvalidDimentionsTest()
        {
            Field gameField = new Field(-23);
        }
    }
}