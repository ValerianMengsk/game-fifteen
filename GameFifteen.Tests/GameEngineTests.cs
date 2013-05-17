namespace GameFifteen.Tests
{
    using GameFifteenCommon;
    using System;
    using System.IO;
    using System.Text;
    using GameFifteen;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteenUI;

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
