namespace GameFifteen
{
    using System;
    using System.Linq;

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
