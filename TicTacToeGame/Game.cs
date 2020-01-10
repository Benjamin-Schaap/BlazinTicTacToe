using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public class Game
    {
        Board gameBoard = new Board();

        Status gameStatus;

        int playerOne = 1;
        int playerTwo = 2;

        int currentPlayer = -1;

        int filledTiles = 0;

        bool aWinningSequenceExists = false;
        bool aTieSequenceExists = false;

        public Game()
        {
            UpdateStatus();
        }

        // Starts a new game of Tic Tac Toe
        public void StartGame()
        {
            UpdateCurrentPlayer();

            UpdateStatus();
        }

        // Updates the current player
        void UpdateCurrentPlayer()
        {
            if (gameStatus == Status.GameFinished)
            {
                currentPlayer = -1;
            }
            else if (currentPlayer == -1)
            {
                currentPlayer = playerOne;

            }else if (currentPlayer == playerTwo)
            {
                currentPlayer = playerOne;
            }
            else
            {
                currentPlayer = playerTwo;
            }
    }

        // SUpdates the status to reflect any game changes
        void UpdateStatus()
        {
            if(aWinningSequenceExists || aTieSequenceExists)
            {
                gameStatus = Status.GameFinished;

            }else if (currentPlayer == 1)
            {
                gameStatus = Status.Player1Turn;
            }
            else if (currentPlayer == 2)
            {
                gameStatus = Status.Player2Turn;
            }
            else
            {
                gameStatus = Status.GameNotStarted;
            }
        }

        // Returns the current game status
        public Status GetStatus()
        {
            return gameStatus;
        }

        public int GetCurrentPlayer()
        {
            return currentPlayer;
        }

        // Saves the move made by a player
        public void SaveMove(int x, int y, int value)
        {
            gameBoard.SetMove(x, y, value);

            if (isWinner(x, y))
            {
                aWinningSequenceExists = true;
                gameStatus = Status.GameFinished;

            }
            else if (isTie())
            {
                aTieSequenceExists = true;
                gameStatus = Status.GameFinished;
            }
            else
            {
                UpdateCurrentPlayer();
                UpdateStatus();
            }


        }

        public bool isWinner(int x, int y)
        {
            return gameBoard.IsWinningMatch(x, y);
        }

        public bool isTie()
        {
            if (filledTiles == 9 && !aWinningSequenceExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string PrettyPrint()
        {
            return gameBoard.PrettyPrintBoard();
        }

        public int GetCellValue(int x, int y)
        {
            return gameBoard.GetCellValue(x, y);
        }

        public List<Coordinates> GetWinningCoordinates()
        {
            return gameBoard.GetWinningCoordinates();
        }


    }
}
