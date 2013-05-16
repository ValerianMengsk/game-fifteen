using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace GameFifteenTests
{
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
           
            GameEngine.StartGame();
            reader.Close();
        }
    }
}
