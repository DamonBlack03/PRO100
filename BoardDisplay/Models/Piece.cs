using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Models
{
    public abstract class Piece
    {
        //0-light
        //1-dark
        public int Color { get; set; }

        public void Move(ref Piece[,] p, char from_letter, int from_number, char letter, int number)
        {
            p[number, letter] = this;
            p[from_number, from_letter] = null;
        }

        //light pieces will be at bottom
        public abstract bool CanMove(ref Piece[,] p, int from_row, int from_column, int row, int column);

        //light-upper
        //dark-lower
        public abstract override string ToString();
    }
}
