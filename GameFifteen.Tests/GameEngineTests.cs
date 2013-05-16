namespace GameFifteen.Tests
{
    using GameFifteen.Common;
    using System;
    using System.IO;
    using System.Text;
    using GameFifteen;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.UI;

    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void OveralGameTest()
        {
            StringBuilder stringBilder = new StringBuilder();

            for (long i = 1; i < 2000; i++)
            {
                for (int j = 1; j < 17; j++)
                {
                    stringBilder.Append(j.ToString());
                    stringBilder.Append("\n");
                }
            }

            stringBilder.Append("exit");
            StreamReader reader = new StreamReader(
                new MemoryStream(Encoding.ASCII.GetBytes(stringBilder.ToString())));

            Console.SetIn(reader);
            GameEngine game = new GameEngine();
            IRenderable rend = new ConsoleRenderer();
            game.StartNewGame(rend);
            reader.Close();
        }
    }
}
