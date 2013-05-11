﻿[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Game manager that controls the game.
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// Singleton eager initialization.
        /// </summary>
        private static GameEngine GameEngineInstance = new GameEngine();

        /// <summary>
        /// Field that holds the gamefield.
        /// </summary>
        private Field gameField = null;

        /// <summary>
        /// Field that holds the console. It will handle input and output.
        /// </summary>
        private IRenderable console = null;

        /// <summary>
        /// Constant for down bound of the field.
        /// </summary>
        private const int DownBound = 0;

        /// <summary>
        /// Constant for up bound of the field.
        /// </summary>
        private const int UpBound = 16;

        /// <summary>
        /// Prevents a default instance of the <see cref="GameEngine" /> class from being created.
        /// Part of Singleton.
        /// Starts the game if there are no errors.
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
        public static GameEngine StartGame()
        {
            return GameEngineInstance;
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

            this.BeginGame();
        }

        /// <summary>
        /// Method that checks if the current cell can be moved to new position.
        /// </summary>
        /// <param name="currCell">Sell to be moved.</param>
        /// <param name="cellToBeMoveTo">New coordinates where the sell will be moved.</param>
        /// <returns>Retruns true if the operation is valid and false otherwise.</returns>
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
        /// Method that is responsible for communication between the user and the engine.
        /// Handles user input and outputs game response.
        /// </summary>
        private void BeginGame()
        {
            string startUpMessage = this.ComposeStartupMessage();
            this.console.Display(startUpMessage);

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
        /// Checks if the move is valid.
        /// If it is, moves the number.
        /// Otherwise it reports an error.
        /// </summary>
        /// <param name="inputNumber">Number to be moved.</param>
        private void MoveNumberIfValid(string inputNumber)
        {
            int numberToMove = -1;
            int.TryParse(inputNumber, out numberToMove);
            
            bool isNumberMoved = this.IsNumberMoved(numberToMove);

            if (!isNumberMoved)
            {
                this.console.Display("Illegal command!");
            }
        }

        /// <summary>
        /// Validates the passed index.
        /// If it's valid moves the number and returns true. 
        /// If it isn't returns false.
        /// </summary>
        /// <param name="index">Number index in numbers coords.</param>
        /// <returns>True if the number is moved and false otherwise.</returns>
        private bool IsNumberMoved(int index)
        {
            bool inRange = (index > DownBound) && (index < UpBound);
            bool numberMoved = true;

            if (inRange)
            {
                var currCell = this.gameField.NumberCoords[0];
                var cellToBeMoveTo = this.gameField.NumberCoords[index];
                bool validNaighbours = this.CheckNeighbours(currCell, cellToBeMoveTo);

                if (validNaighbours)
                {
                    MoveNumber(index);
                }
                else
                {
                    numberMoved = false;
                }
            }
            else
            {
                numberMoved = false;
            }

            return numberMoved;
        }

        /// <summary>
        /// This method moves a number from one position to another.
        /// </summary>
        /// <param name="index">Integer to use for moving a number.</param>
        private void MoveNumber(int index)
        {
            // Just in case validation.
            if (index < DownBound || index > UpBound)
            {
                throw new ArgumentOutOfRangeException("Index is not in correct range. The range is between 0 and 16.");
            }

            this.SwapCoords(index);

            var row = this.gameField.NumberCoords[index].Row;
            var col = this.gameField.NumberCoords[index].Col;

            this.gameField[row, col] = index;

            row = this.gameField.NumberCoords[0].Row;
            col = this.gameField.NumberCoords[0].Col;

            this.gameField[row, col] = 0;
        }

        /// <summary>
        /// Compose the string that will be shown to the player when the game is started.
        /// </summary>
        private string ComposeStartupMessage()
        {
            StringBuilder startupMessage = new StringBuilder();

            startupMessage.AppendLine("\r\nWelcome to the game “15”.");
            startupMessage.AppendLine("Please try to arrange the numbers sequentially.");
            startupMessage.AppendLine("Use 'top' to view the top scoreboard.");
            startupMessage.AppendLine("Use 'restart' to start a new game.");
            startupMessage.AppendLine("Use 'exit' to quit the game.");

            return startupMessage.ToString();
        }

        /// <summary>
        /// Method that swaps coordinates from given integer.
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
