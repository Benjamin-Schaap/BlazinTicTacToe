using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public class Cell
    {
        int value { get; set; }

        public Coordinates coords;

        public TileColor color;

        public char symbol;

        public Cell()
        {
            value = -1;
            color = TileColor.Black;
        }

        public Cell(int x, int y)
        {
            value = -1;
            coords = new Coordinates(x, y);
            color = TileColor.Black;
        }

        public int Value()
        {
            return value;
        }

        public int Value(int newVal)
        {
            value = newVal;
            return value;
        }


    }
}
