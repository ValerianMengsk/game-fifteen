[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;

    /// <summary>
    /// Read and Write on the console.
    /// </summary>
    public class ConsoleRenderer : IRenderable
    {
        /// <summary>
        /// Display string text to the console.
        /// </summary>
        /// <param name="toDisplay">String that will be printed on the console.</param>
        public void Display(string toDisplay)
        {
            Console.WriteLine(toDisplay);
        }

        /// <summary>
        /// Show message on the console telling the user what we expect to ne entered.
        /// Reading from the console.
        /// </summary>
        /// <param name="message">Message to be printed before asking for a variable.</param>
        /// <returns>Entered string from the user on the console.</returns>
        public string Read(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
