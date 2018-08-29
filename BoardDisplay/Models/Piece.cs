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

        public bool check = false;
        public void KingInCheck(bool yesno)
        {
            check = yesno;
        }


        public void Move(ref Piece[,] p, int from_row, int from_column, int row, int column)
        {
            p[row, column] = this;
            p[from_row, from_column] = null;
        }

        //light pieces will be at bottom
        public abstract bool CanMove(ref Piece[,] p, int from_row, int from_column, int row, int column);

        //light-upper
        //dark-lower
        public abstract override string ToString();
    }
}
