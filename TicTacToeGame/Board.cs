using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame
{
    class Board
    {
        int _rows;
        int _columns;

        Cell[,] gameBoard;

        List<Coordinates> winningCoordinates;

        public void SetMove(int x, int y, int value)
        {
            gameBoard[x, y].Value(value);
        }

        public Board(int rows = 3, int columns = 3)
        {
            _rows = rows;
            _columns = columns;

            gameBoard = new Cell[_rows, _columns];

            InitializeBoard();
        }

        // NEEDS COMMENTS
        public void InitializeBoard()
        {
            for (int index = 0; index < 3; index++)
            {
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                     gameBoard[index, columnIndex] = new Cell(index,columnIndex);
                }
            }
        }

        // NEEDS COMMENTS
        public string PrettyPrintBoard()
        {
            string prettyBoard = "";

            for(int index = 0; index < 3; index++)
            {
                for(int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    prettyBoard += gameBoard[index, columnIndex].Value().ToString();

                    if(columnIndex != 2)
                    {
                        prettyBoard += '|';
                    }
                }

                prettyBoard += '\n';

                if (index != 2)
                {
                    prettyBoard += "--------" + '\n';
                }

            }

            return prettyBoard;
        }

        public List<Coordinates> GetWinningCoordinates()
        {
            return winningCoordinates;
        }

        bool IsColumnWinner(int columnIndex)
        {
            List<int> tempList = new List<int>();

            List<Coordinates> wincoords = new List<Coordinates>();

            for(int index = 0; index < _rows; index++)
            {
                tempList.Add(gameBoard[index, columnIndex].Value());
                wincoords.Add(new Coordinates(index, columnIndex));
            }

            if (tempList.Distinct().Count() == 1 && !tempList.Contains(-1))
            {
                winningCoordinates = wincoords;
                return true;
            }
            else
            {
                return false;
            }
        }

        bool isRowWinner(int rowIndex)
        {
            List<int> tempList = new List<int>();

            List<Coordinates> winCoords = new List<Coordinates>();

            for (int index = 0; index < _columns; index++)
            {
                tempList.Add(gameBoard[rowIndex, index].Value());
                winCoords.Add(new Coordinates(rowIndex, index));
            }

            if (tempList.Distinct().Count() == 1 && !tempList.Contains(-1))
            {
                winningCoordinates = winCoords;
                return true;
            }else
            {
                return false;
            }
        }

        bool isLeftDiagWinner()
        {
            List<int> tempList = new List<int>();

            List<Coordinates> winCoords = new List<Coordinates>();

            for (int index = 0; index < _columns; index++)
            {
                tempList.Add(gameBoard[index, index].Value());
                winCoords.Add(new Coordinates(index, index));
            }

            if (tempList.Distinct().Count() == 1 && !tempList.Contains(-1))
            {
                winningCoordinates = winCoords;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isRightDiagWinner()
        {
            List<int> tempList = new List<int>();

            List<Coordinates> winCoords = new List<Coordinates>();

            int columnIndex = 0;

            for (int rowIndex = _rows - 1; rowIndex >= 0; rowIndex--)
            {
                tempList.Add(gameBoard[rowIndex, columnIndex].Value());
                winCoords.Add(new Coordinates(rowIndex, columnIndex));
                columnIndex++;
            }

            if (tempList.Distinct().Count() == 1 && !tempList.Contains(-1))
            {
                winningCoordinates = winCoords;
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsWinningMatch(int x, int y)
        {
            return isRowWinner(x) || IsColumnWinner(y) || isLeftDiagWinner() || isRightDiagWinner();
        }

        public int GetCellValue(int x, int y)
        {
            return gameBoard[x, y].Value();
        }

    }
}
