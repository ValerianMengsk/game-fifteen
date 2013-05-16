namespace GameFifteenCommon
{
    using System;
    using System.Linq;
    using System.Text;

    public static class Messages
    {
        /// <summary>
        /// Compose the string that will be shown to the player when the game is started.
        /// </summary>
        public static string StartupMessage()
        {
            StringBuilder startupMessage = new StringBuilder();

            startupMessage.AppendLine("\r\nWelcome to the game “15”.");
            startupMessage.AppendLine("Please try to arrange the numbers sequentially.");
            startupMessage.AppendLine("Use 'top' to view the top scoreboard.");
            startupMessage.AppendLine("Use 'restart' to start a new game.");
            startupMessage.AppendLine("Use 'exit' to quit the game.");

            return startupMessage.ToString();
        }
    }
}
