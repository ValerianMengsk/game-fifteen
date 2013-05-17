namespace GameFifteen.Tests
{
    using System;
    using GameFifteenCommon;
    using GameFifteenUI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void OveralGameTest()
        {
            IRenderable rend = new TestRenderer();
            GameEngine.StartGame(rend);
        }
    }
}
