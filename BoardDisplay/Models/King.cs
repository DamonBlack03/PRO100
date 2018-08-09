using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Models
{
    class King : Piece
    {
        public King(bool light)
        {
            if (light)
            {
                this.Color = 0;
            }
            else
            {
                this.Color = 1;
            }
        }

        public override bool CanMove(ref Piece[,] p, char from_letter, int from_number, char letter, int number, bool light)
        {
            from_letter -= 'A';
            letter -= 'A';
            bool possible = ((from_letter < 8 && from_letter > -1) && (from_number < 8 && from_number > -1) && (letter < 8 && letter > -1) && (number < 8 && number > -1)) ? (letter == (from_letter - 1) || letter == (from_letter + 1)) ? (number == from_number || number == (from_number - 1) || number == (from_number + 1)) ? (p[number, letter] == null) ? true : (p[number, letter].Color != p[from_number, from_letter].Color) ? true : false : false : (letter == from_letter) ? (number == (from_number - 1) || number == (from_number + 1)) ? (p[number, letter] == null) ? true : (p[number, letter].Color != p[from_number, from_letter].Color) ? true : false : false : false : false;

            //if ((from_letter < 8 && from_letter > -1) && (from_number < 8 && from_number > -1) &&
            //    (letter < 8 && letter > -1) && (number < 8 && number > -1))
            //{
            //    if(letter == (from_letter - 1) || letter == (from_letter + 1))
            //    {
            //        if(number == from_number || number == (from_number - 1) || number == (from_number + 1))
            //        {
            //            if (p[number,letter] == null)
            //            {
            //                possible = true;
            //            }
            //            else if (p[number,letter].Color != p[from_number,from_letter].Color)
            //            {
            //                possible = true;
            //            }
            //        }
            //    }
            //    else if (letter == from_letter)
            //    {
            //        if (number == (from_number - 1) || number == (from_number + 1))
            //        {
            //            if (p[number,letter] == null)
            //            {
            //                possible = true;
            //            }
            //            else if (p[number,letter].Color != p[from_number,from_letter].Color)
            //            {
            //                possible = true;
            //            }
            //        }
            //    }
            //}

            return possible;
        }

        public override string ToString()
        {
            return "King";
        }
    }
}
