using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace GameFifteenTests
{
    [TestClass]
    public class CoordsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))] 
        public void CheckRangeExceptionWithBorderValue()
        {
            Coords coordinates = new Coords(0, 0);
            coordinates.CheckIfIsInRange(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckRangeExceptionWithBigNumber()
        {
            Coords coordinates = new Coords(0, 0);
            coordinates.CheckIfIsInRange(10000000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckRangeExceptionWithNegative()
        {
            Coords coordinates = new Coords(0, 0);
            coordinates.CheckIfIsInRange(-1);
        }

        [TestMethod]
        public void CheckRangeExceptionNotWated()
        {
            Coords coordinates = new Coords(0, 0);
            Assert.AreEqual()
            
        }
    }
}
