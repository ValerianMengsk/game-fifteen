using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public class GameEngine
    {
        private Field gameField = null;
        IRenderer console = null;

        public GameEngine()
        {
            console = new ConsoleRenderer();
            StartNewGame();
        }

        public void StartNewGame()
        {
            this.gameField = new Field();

            do
            {
                this.gameField.GetRandomField();
            } while (this.gameField.IsSolved());

            PrintStartupMessage();

            BeginGame();
        }

        private void PrintStartupMessage()
        {
            StringBuilder startupMessage = new StringBuilder();

            startupMessage.AppendLine("\r\nWelcome to the game “15”.");
            startupMessage.AppendLine("Please try to arrange the numbers sequentially.");
            startupMessage.AppendLine("Use 'top' to view the top scoreboard.");
            startupMessage.AppendLine("Use 'restart' to start a new game.");
            startupMessage.AppendLine("Use 'exit' to quit the game.");

            console.Display(startupMessage.ToString());
        }

        private void BeginGame()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            console.Display(this.gameField.ToString());

            string inputNumber = console.Read("Enter a number to move: ");
            bool gameIsFinished = false;
            int moves = 0;

            while (inputNumber != "exit")
            {
                moves++;
                switch (inputNumber)
                {
                    case "top":
                        console.Display(scoreBoard.ToString());
                        break;
                    case "restart":
                        StartNewGame();
                        break;
                    default:
                        MoveNumberIfValid(inputNumber);
                        break;
                }

                console.Display(this.gameField.ToString());
                gameIsFinished = this.gameField.IsSolved();

                if (gameIsFinished)
                {
                    scoreBoard.Add(moves);
                    moves = 0;
                    StartNewGame();
                }

                inputNumber = console.Read("Enter a number to move: ");
            }
        }

        private void MoveNumberIfValid(string inputNumber)
        {
            int numberToMove = -1;
            int.TryParse(inputNumber, out numberToMove);
            int downBound = 0;
            int upBound = 16;

            if (numberToMove > downBound && numberToMove < upBound)
            {
                TryToMoveNumber(numberToMove);
            }
            else
            {
                console.Display("Illegal command!");
            }
        }

        private void TryToMoveNumber(int index)
        {
            var currCell = this.gameField.NumberCoords[0];
            var cellToBeMoveTo = this.gameField.NumberCoords[index];
            bool validNaighbours = CheckNeighbours(currCell, cellToBeMoveTo);

            if (validNaighbours)
            {
                SwapCoords(index);

                var row = this.gameField.NumberCoords[index].Row;
                var col = this.gameField.NumberCoords[index].Col;

                this.gameField[row, col] = index;

                row = this.gameField.NumberCoords[0].Row;
                col = this.gameField.NumberCoords[0].Col;

                this.gameField[row, col] = 0;
            }
            else
            {
                console.Display("Illegal command!");
            }
        }

        private void SwapCoords(int index)
        {
            var numberCoords = this.gameField.NumberCoords;

            Coords currCoords = numberCoords[0];
            numberCoords[0] = numberCoords[index];
            numberCoords[index] = currCoords;
        }

        public bool CheckNeighbours(Coords currCell, Coords cellToBeMoveTo)
        {
            bool cellsRowsMatch = (currCell.Row == cellToBeMoveTo.Row);
            bool cellsColsMatch = (currCell.Col == cellToBeMoveTo.Col);
            bool isLeftCell = (currCell.Col == cellToBeMoveTo.Col - 1);
            bool isRightCell = (currCell.Col == cellToBeMoveTo.Col + 1);
            bool isUpCell = (currCell.Row == cellToBeMoveTo.Row - 1);
            bool isDownCell = (currCell.Row == cellToBeMoveTo.Row + 1);

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
    }
}
