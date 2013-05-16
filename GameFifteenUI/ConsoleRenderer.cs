[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;

    /// <summary>
    /// Read and Write on the console.
    /// </summary>
    public class ConsoleRenderer : IRendable
    {
        /// <summary>
        /// Display string on the console.
        /// </summary>
        /// <param name="toDisplay">String that will be printed on the console.</param>
        public void Display(string toDisplay)
        {
            Console.WriteLine(toDisplay);
        }

        /// <summary>
        /// Show message on the console telling the user what we expect him to entere.
        /// Reading the user input.
        /// </summary>
        /// <param name="message">Message to be printed when asking for input.</param>
        /// <returns>Input data.</returns>
        public string Read(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
