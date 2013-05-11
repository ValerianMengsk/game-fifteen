[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;

    /// <summary>
    /// Main class of the game, includes Main() Method.
    /// Just starts the game through the game engine.
    /// </summary>
    public class GameFifteen
    {
        /// <summary>
        /// Main Method than starts the game.
        /// </summary>
        public static void Main()
        {
            GameEngine.StartGame();
        }
    }
}
