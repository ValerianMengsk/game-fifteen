[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteenUI
{
    using GameFifteenCommon;
    using System;
    using System.Linq;

    /// <summary>
    /// Main class of the game.
    /// Just starts the game through the game engine.
    /// </summary>
    public class GameFifteen
    {
        public static void Main()
        {
            IRenderable renderer = new ConsoleRenderer();
            GameEngine.StartGame(renderer);
        }
    }
}
