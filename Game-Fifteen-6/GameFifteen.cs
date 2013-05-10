[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;

    /// <summary>
    /// Main class of the game, includes Main() Method.
    /// Just start the game and the game engine.
    /// </summary>
    public class GameFifteen
    {
        /// <summary>
        /// Main Method than start the game and the game manager.
        /// </summary>
        public static void Main()
        {
            GameEngine engine = GameEngine.GetInstace();
        }
    }
}
