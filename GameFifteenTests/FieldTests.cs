using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace GameFifteenTests
{
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
        public void NumberCoordsTest()
        {
            Field gameField = new Field(4);
            var numbers = gameField.NumberCoords;

            Assert.AreEqual(16, numbers.Count);
        }

        [TestMethod]
        public void FieldLengthTest()
        {
            Field GameField = new Field(4);

            int firstGameFieldLength = GameField.ToString().Length;

            Assert.AreEqual(134, firstGameFieldLength);
        }

        [TestMethod]
        public void FieldGetNumberTest()
        {
            Field GameField = new Field(4);

            var number = GameField[0, 0];

            bool isValidNumber = number >= 0 && number < 16;

            Assert.IsTrue(isValidNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FieldInvalidDimentionsTest()
        {
            Field gameField = new Field(-23);
        }
    }
}
