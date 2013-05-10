[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Game manager that control anything (runs) in the game.
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// Singleton eager initialization.
        /// </summary>
        private static GameEngine instance = new GameEngine();

        /// <summary>
        /// Field that holds the playfield in the game. 
        /// </summary>
        private Field gameField = null;

        /// <summary>
        /// Field that holds the console to read and write to.
        /// </summary>
        private IRenderer console = null;

        /// <summary>
        /// Prevents a default instance of the <see cref="GameEngine" /> class from being created.
        /// </summary>
        private GameEngine()
        {
            this.console = new ConsoleRenderer();

            try
            {
                this.StartNewGame();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                this.console.Display(ex.Message);
            }
        }

        /// <summary>
        /// Method that gets the main instance of the game engine.
        /// </summary>
        /// <returns>The instance of the GameEngine.</returns>
        public static GameEngine GetInstace()
        {
            return instance;
        }

        /// <summary>
        /// Method that starts the new game, when it was just loaded or restarted. 
        /// </summary>
        public void StartNewGame()
        {
            this.gameField = new Field();

            do
            {
                this.gameField.GetRandomField();
            } 
            while (this.gameField.IsSolved());

            this.PrintStartupMessage();

            this.BeginGame();
        }

        /// <summary>
        /// Method that checks can the current sell be moved
        /// to new play where the player wants it to.
        /// </summary>
        /// <param name="currCell">Sell to be moved.</param>
        /// <param name="cellToBeMoveTo">New coordinates where the sell will be moved.</param>
        /// <returns>Can be done this operation (true or false).</returns>
        public bool CheckNeighbours(Coords currCell, Coords cellToBeMoveTo)
        {
            bool cellsRowsMatch = currCell.Row == cellToBeMoveTo.Row;
            bool cellsColsMatch = currCell.Col == cellToBeMoveTo.Col;
            bool isLeftCell = currCell.Col == cellToBeMoveTo.Col - 1;
            bool isRightCell = currCell.Col == cellToBeMoveTo.Col + 1;
            bool isUpCell = currCell.Row == cellToBeMoveTo.Row - 1;
            bool isDownCell = currCell.Row == cellToBeMoveTo.Row + 1;

            if (cellsRowsMatch && (isLeftCell || isRightCell))
            {
                return true;
            }
            else if (cellsColsMatch && (isUpCell || isDownCell))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compose the string that will be shown to the player when the game is started.
        /// </summary>
        private void PrintStartupMessage()
        {
            StringBuilder startupMessage = new StringBuilder();

            startupMessage.AppendLine("\r\nWelcome to the game “15”.");
            startupMessage.AppendLine("Please try to arrange the numbers sequentially.");
            startupMessage.AppendLine("Use 'top' to view the top scoreboard.");
            startupMessage.AppendLine("Use 'restart' to start a new game.");
            startupMessage.AppendLine("Use 'exit' to quit the game.");

            this.console.Display(startupMessage.ToString());
        }

        /// <summary>
        /// Method that is responsible to when the game is started or restarted.
        /// It does the things that are needed when the game is started.
        /// </summary>
        private void BeginGame()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            this.console.Display(this.gameField.ToString());

            string inputNumber = this.console.Read("Enter a number to move: ");
            bool gameIsFinished = false;
            int moves = 0;

            while (inputNumber != "exit")
            {
                moves++;
                switch (inputNumber)
                {
                    case "top":
                        this.console.Display(scoreBoard.ToString());
                        break;
                    case "restart":
                        this.StartNewGame();
                        break;
                    default:
                        this.MoveNumberIfValid(inputNumber);
                        break;
                }

                this.console.Display(this.gameField.ToString());
                gameIsFinished = this.gameField.IsSolved();

                if (gameIsFinished)
                {
                    scoreBoard.Add(moves);
                    moves = 0;
                    this.StartNewGame();
                }

                inputNumber = this.console.Read("Enter a number to move: ");
            }
        }

        /// <summary>
        /// Checks move to be valid.
        /// If it is valid it makes it.
        /// Otherwise it reports an error.
        /// </summary>
        /// <param name="inputNumber">String to be checked (after parsing).</param>
        private void MoveNumberIfValid(string inputNumber)
        {
            int numberToMove = -1;
            int.TryParse(inputNumber, out numberToMove);
            int downBound = 0;
            int bound = 16;

            if (numberToMove > downBound && numberToMove < bound)
            {
                this.TryToMoveNumber(numberToMove);
            }
            else
            {
                this.console.Display("Illegal command!");
            }
        }

        /// <summary>
        /// Method try to move.
        /// If it is valid it makes it.
        /// Otherwise it reports an error.
        /// </summary>
        /// <param name="index">Integer to be moved.</param>
        private void TryToMoveNumber(int index)
        {
            var currCell = this.gameField.NumberCoords[0];
            var cellToBeMoveTo = this.gameField.NumberCoords[index];
            bool validNaighbours = this.CheckNeighbours(currCell, cellToBeMoveTo);

            if (validNaighbours)
            {
                this.SwapCoords(index);

                var row = this.gameField.NumberCoords[index].Row;
                var col = this.gameField.NumberCoords[index].Col;

                this.gameField[row, col] = index;

                row = this.gameField.NumberCoords[0].Row;
                col = this.gameField.NumberCoords[0].Col;

                this.gameField[row, col] = 0;
            }
            else
            {
                this.console.Display("Illegal command!");
            }
        }

        /// <summary>
        /// Method that swap coordinates from given integer.
        /// Method used very often.
        /// </summary>
        /// <param name="index">Given integer.</param>
        private void SwapCoords(int index)
        {
            var numberCoords = this.gameField.NumberCoords;

            Coords currCoords = numberCoords[0];
            numberCoords[0] = numberCoords[index];
            numberCoords[index] = currCoords;
        }
    }
}
