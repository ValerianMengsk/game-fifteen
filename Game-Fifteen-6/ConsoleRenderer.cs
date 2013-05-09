using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public class ConsoleRenderer : IRenderer
    {
        public void Display(string toDisplay)
        {
            Console.WriteLine(toDisplay);
        }

        public string Read(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
