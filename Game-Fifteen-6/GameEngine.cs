using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public class GameEngine
    {
        private Field gameField;

        public GameEngine()
        {
            this.gameField = new Field();
        }

        public void StartNewGame()
        {
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

            Console.WriteLine(startupMessage);
        }

        private void BeginGame()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            Console.WriteLine(this.gameField);

            Console.Write("Enter a number to move: ");
            string inputNumber = Console.ReadLine();
            bool gameIsFinished = false;
            int moves = 0;

            //Need a documentation
            while (inputNumber != "exit")
            {
                moves++;
                switch (inputNumber)
                {
                    case "top":
                        Console.WriteLine(scoreBoard);
                        break;
                    case "restart":
                        StartNewGame();
                        break;
                    default:
                        MoveNumberIfValid(inputNumber);
                        break;
                }

                Console.WriteLine(this.gameField);
                gameIsFinished = this.gameField.IsSolved();

                if (gameIsFinished)
                {
                    scoreBoard.Add(moves);
                    moves = 0;
                    StartNewGame();
                }

                Console.Write("Enter a number to move: ");
                inputNumber = Console.ReadLine();
            }
        }

        private void MoveNumberIfValid(string inputNumber)
        {
            int numberToMove = -1;

            int.TryParse(inputNumber, out numberToMove);

            if (numberToMove > 0 && numberToMove < 16)
            {
                TryToMoveNumber(numberToMove);
            }
            else
            {
                Console.WriteLine("Illegal command!");
            }
        }

        private void TryToMoveNumber(int numberToMove)
        {
            if (CheckNeighbours(this.gameField.NumberCoords[0], this.gameField.NumberCoords[numberToMove]))
            {
                SwapCoords(numberToMove, this.gameField.NumberCoords);

                var row = this.gameField.NumberCoords[numberToMove].Row;
                var col = this.gameField.NumberCoords[numberToMove].Col;

                this.gameField[row, col] = numberToMove;

                row = this.gameField.NumberCoords[0].Row;
                col = this.gameField.NumberCoords[0].Col;

                this.gameField[row, col] = 0;
            }
            else
            {
                Console.WriteLine("Illegal command!");
            }
        }

        private void SwapCoords(int index, Dictionary<int, Coords> numberCoords)
        {
            Coords currCoords = numberCoords[0];
            numberCoords[0] = numberCoords[index];
            numberCoords[index] = currCoords;
        }

        public bool CheckNeighbours(Coords currCell, Coords otherCell)
        {
            bool cellsRowsMatch = (currCell.Row == otherCell.Row);
            bool cellsColsMatch = (currCell.Col == otherCell.Col);
            bool isLeftCell = (currCell.Col == otherCell.Col - 1);
            bool isRightCell = (currCell.Col == otherCell.Col + 1);
            bool isUpCell = (currCell.Row == otherCell.Row - 1);
            bool isDownCell = (currCell.Row == otherCell.Row + 1);

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
