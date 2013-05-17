namespace GameFifteen.Tests
{
    using System;
<<<<<<< HEAD
    using GameFifteenCommon;
=======
    using Microsoft.VisualStudio.TestTools.UnitTesting;
>>>>>>> bug fix, code update.
    using GameFifteenUI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void OveralGameTest()
        {
            IRenderable rend = new ConsoleRenderer();
            GameEngine.StartGame(rend);
        }
    }
}
