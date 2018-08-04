using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO.Models
{
    class Knight : Piece
    {
        public Knight(bool light)
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
            //bool possible = false;
            //from_letter -= 'A';
            //letter -= 'A';

            //if ((from_letter < 8 && from_letter > -1) && (from_number < 8 && from_number > -1) &&
            //    (letter < 8 && letter > -1) && (number < 8 && number > -1))
            //{
            //    if (letter == (from_letter + 1) || letter == (from_letter - 1))
            //    {
            //        if (number == (from_number + 2) || number == (from_number - 2))
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
            //    else if (number == (from_number + 1) || number == (from_number - 1))
            //    {
            //        if (letter == (from_letter + 2) || letter == (from_letter - 2))
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
            from_letter -= 'A';
            letter -= 'A';
            bool possible = ((from_letter < 8 && from_letter > -1) && (from_number < 8 && from_number > -1) && (letter < 8 && letter > -1) && (number < 8 && number > -1)) ? (letter == (from_letter + 1) || letter == (from_letter - 1)) ? (number == (from_number + 2) || number == (from_number - 2)) ? (p[number,letter] == null) ? true : (p[number,letter].Color != p[from_number,from_letter].Color) ? true : false : false : (number == (from_number + 1) || number == (from_number - 1)) ? (letter == (from_letter + 2) || letter == (from_letter - 2)) ? (p[number,letter] == null) ? true : (p[number,letter].Color != p[from_number,from_letter].Color) ? true : false : false : false : false;


            return possible;
        }

        public override string ToString()
        {
            return "Knight";
        }
    }
}
