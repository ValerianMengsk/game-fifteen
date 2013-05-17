namespace GameFifteen.Tests
{
    using GameFifteenCommon;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Read and Write on the console.
    /// </summary>
    public class TestRenderer : IRenderable
    {
        /// <summary>
        /// Display string on the console.
        /// </summary>
        public void Write(string toDisplay)
        {
        }

        /// <summary>
        /// The method test the logic.
        /// It runs through different game scenarous.
        /// </summary>

        public string Read(string message)
        {
            Random num = new Random();

            int myNum = num.Next(1, 20);
            switch (myNum)
            {
                case 17:
                    return "top";
                case 18:
                    return "restart";
                case 19:
                    return "exit";
                default:
                    return myNum.ToString();
            }
        }

        /// <summary>
        /// not implemented.
        /// </summary>
        public void PrintField(IList<int> field)
        {
            
        }

        /// <summary>
        /// not implemented.
        /// </summary>
        public void PrintScoreboard(OrderedMultiDictionary<int, string> scores)
        {
            
        }

        /// <summary>
        /// not implemented.
        /// </summary>
        public void StartupMessage()
        {

        }
    }
}
