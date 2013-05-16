[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace GameFifteen.Common
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
        /// Constant for down bound of the field.
        /// </summary>
        private const int DownBound = 0;

        /// <summary>
        /// Constant for up bound of the field.
        /// </summary>
        private const int UpBound = 16;

        /// <summary>
        /// Constant for the field dimentions.
        /// </summary>
        private const int Dimentions = 4;

        /// <summary>
        /// Generates string representation of the field.
        /// </summary>
        /// <returns>String representation of the field.</returns>


        public GameEngine()
        {
        }

        /// <summary>
        /// Field that holds the gamefield.
        /// </summary>
        private Field gameField = null;

        /// <summary>
        /// Method that starts the new game, when it was just loaded or restarted. 
        /// </summary>
        public void StartNewGame(IRenderable renderer)
        {
            this.gameField = new Field(Dimentions);

            do
            {
                this.gameField.GetRandomField();
            }
            while (this.gameField.IsSolved());

            this.BeginGame(renderer);
        }

        /// <summary>
        /// Method that checks if the current cell can be moved to new position.
        /// </summary>
        /// <param name="currCell">Sell to be moved.</param>
        /// <param name="cellToBeMoveTo">New coordinates where the sell will be moved.</param>
        /// <returns>Retruns true if the operation is valid and false otherwise.</returns>
        private bool CheckNeighbours(Coords currCell, Coords cellToBeMoveTo)
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
        private void BeginGame(IRenderable render)
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            render.PrintString(gameField.GetFieldNumbers());
            //string inputCommand = this.console.Read("Enter a number to move: ").Trim();
            bool gameIsFinished = false;
            int moves = 0;

            while (true)
            {
                string inputCommand = render.Read("give me command: ");
                switch (inputCommand.Trim())
                {
                    case "top":
                        render.PrintScores(scoreBoard.Scores());
                        break;
                    case "restart":
                        this.StartNewGame(render);
                        break;
                    case "exit":
                        return;
                    default:
                        if (this.IsNumberMovable(inputCommand))
                        {
                            this.MoveNumber(int.Parse(inputCommand));
                            moves++;
                        }
                        else
                        {
                            render.Write("Invalid Command");
                        }
                        break;
                }

                render.PrintString(this.gameField.GetFieldNumbers());
                gameIsFinished = this.gameField.IsSolved();

                if (gameIsFinished)
                {
                    string message = string.Format("Congratulations! You won the game in {0} moves.", moves);
                    render.Write(message);

                    this.AddUserToScoreBoard(scoreBoard, moves, render);
                    moves = 0;
                    this.StartNewGame(render);
                }


            }
        }

        private void AddUserToScoreBoard(ScoreBoard scoreBoard, int score, IRenderable render)
        {
            string name = render.Read("Please enter your name for the top scoreboard: ");
            scoreBoard.Add(name, score);
        }

        /// <summary>
        /// Validates the passed index.
        /// /// </summary>
        /// <param name="inputNumber">String inputNumber to be moved.</param>
        /// <returns>True if the number is movable and false otherwise.</returns>
        private bool IsNumberMovable(string inputNumber)
        {
            int numberToMove = -1;

            if (!int.TryParse(inputNumber, out numberToMove))
            {
                return false;
            }

            if (!((numberToMove > DownBound) && (numberToMove < UpBound)))
            {
                return false;
            }
            var currCell = this.gameField.NumberCoords[0];
            var cellToBeMoveTo = this.gameField.NumberCoords[numberToMove];
            return this.CheckNeighbours(currCell, cellToBeMoveTo);
        }

        /// <summary>
        /// This method moves a number from one position to another.
        /// </summary>
        /// <param name="index">Integer to use for moving a number.</param>
        private void MoveNumber(int index)
        {
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
