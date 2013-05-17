namespace GameFifteen.Tests
{
    using System;
    using GameFifteenCommon;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoordsTests
    {
        [TestMethod]
        public void CoordsTestZero()
        {
            Coords coords = new Coords(0, 0, 1);

            Assert.AreEqual(0, coords.Row);
            Assert.AreEqual(0, coords.Col);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoordsTestNegativeRow()
        {
            Coords coords = new Coords(-1, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoordsTestNegativeCol()
        {
            Coords coords = new Coords(1, -1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoordsTestNegativeDimentions()
        {
            Coords coords = new Coords(1, 1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoordsTestTooBigRowAndCol()
        {
            Coords coords = new Coords(10099, 132454, 4);
        }
    }
}