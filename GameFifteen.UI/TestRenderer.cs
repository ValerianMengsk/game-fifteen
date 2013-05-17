namespace GameFifteenUI
{
    using System;
    using System.Collections.Generic;
    using GameFifteenCommon;
    using Wintellect.PowerCollections;

    public class TestRenderer : IRenderable
    {
        public void Write(string toDisplay)
        {
        }

        public string Read(string message)
        {
            Random num = new Random();
            ////the bigger endNum is 
            ////the harder to hit the "exit", and the longer the Test is
            int endNum = 41;
            int myNum = num.Next(1, endNum);

            switch (myNum)
            {
                case 17:
                    return "restart";
                case 18:
                    return "top";
                case 19:
                    return "exit";
                default:
                    return myNum.ToString();
            }
        }

        public void PrintField(IList<int> field)
        {
        }

        public void PrintScoreboard(OrderedMultiDictionary<int, string> scores)
        {
        }
    }
}