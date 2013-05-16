[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen.UI
{
    using GameFifteen.Common;
    using System;
    using System.Linq;

    /// <summary>
    /// Main class of the game.
    /// Just starts the game through the game engine.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            IRenderable Player = new ConsoleRenderer();
            Player.Write(ConsoleMessages.StartupMessage());
            GameEngine instance = new GameEngine();
            instance.StartNewGame(Player);
        }
    }
}
