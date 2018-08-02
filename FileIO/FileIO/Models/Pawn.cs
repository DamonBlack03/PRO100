using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO.Models
{
    class Pawn : Piece
    {
        public override bool CanMove(ref Piece[][] p, char from_letter, int from_number, char letter, int number, bool light)
        {
            bool possible = false;

            if(letter != (from_letter - 1))
            {

            }

            return possible;
        }

        public override string ToString()
        {
            return "Pawn";
        }
    }
}
