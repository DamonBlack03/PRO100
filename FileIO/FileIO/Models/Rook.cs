using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO.Models
{
    class Rook : Piece
    {
        public override bool CanMove(ref Piece[][] p, char from_letter, int from_number, char letter, int number, bool light)
        {
            bool possible = false;
            from_letter -= 'A';
            letter -= 'A';

            if ((from_letter < 8 && from_letter > -1) && (from_number < 8 && from_number > -1) &&
                (letter < 8 && letter > -1) && (number < 8 && number > -1))
            {
                if (light)
                {
                    if (from_letter == letter && from_number != number)
                    {
                     // Loop through and check each position between the from position and the desired position   
                    }
                    else if (from_letter != letter && from_number == number)
                    {
                        // Loop through and check each position between the from position and the desired position
                    }
                }
                else
                {

                }
            }
            

                return possible;
        }

        public override string ToString()
        {
            return "Rook";
        }
    }
}
