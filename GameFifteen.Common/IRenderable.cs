[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteenCommon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Interface, handling input and output.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Method, handling output.
        /// </summary>
        /// <param name="toDisplay">String to be displayed.</param>
        void Write(string toDisplay);

        /// <summary>
        /// Method handling input.
        /// </summary>
        /// <param name="message">Guide message the player.</param>
        /// <returns>String entered by player.</returns>
        string Read(string message);

        /// <summary>
        /// Method that prints the field in the UI
        /// </summary>
        void PrintField(IList<int> fieldNumbers);

        /// <summary>
        /// Method that prints the scorebroard in th UI
        /// </summary>
        void PrintScoreboard(OrderedMultiDictionary<int, string> scores);

        /// <summary>
        /// Method that shows the welcome message
        /// </summary>
        void StartupMessage();
    }
}
