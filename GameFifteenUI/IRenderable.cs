[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface, handling input and output.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Method, handling output.
        /// </summary>
        /// <param name="toDisplay">String to be displayed.</param>
        void Display(string toDisplay);

        /// <summary>
        /// Method handling input.
        /// </summary>
        /// <param name="message">Guide message the player.</param>
        /// <returns>String entered by player.</returns>
        string Read(string message); 
    }
}
