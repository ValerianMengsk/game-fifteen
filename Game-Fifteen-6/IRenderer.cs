[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface that ensure that his childes will have those methods,
    /// that reads and writes on the console.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Method that will display some string on the console.
        /// </summary>
        /// <param name="toDisplay">String to be displayed.</param>
        void Display(string toDisplay);

        /// <summary>
        /// Method that will get information from the console set by the player,
        /// and return it as string.
        /// </summary>
        /// <param name="message">Message to be shown to the player.</param>
        /// <returns>String set by the player.</returns>
        string Read(string message); 
    }
}
