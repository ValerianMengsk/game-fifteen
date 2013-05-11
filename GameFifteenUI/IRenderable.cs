[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface that ensure that his childes will have those methods,
    /// that reads and writes on the console.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Method that will display some string data.
        /// </summary>
        /// <param name="toDisplay">String to be displayed.</param>
        void Display(string toDisplay);

        /// <summary>
        /// Method that will get input data and return it as string.
        /// </summary>
        /// <param name="message">Message to be shown to the player.</param>
        /// <returns>String entered by player.</returns>
        string Read(string message); 
    }
}
