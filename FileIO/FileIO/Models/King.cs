using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO.Models
{
    class King : Piece
    {
        public King()
        {
            
        }

        public override bool CanMove(ref Piece[][] p, char from_letter, int from_number, char letter, int number, bool light)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
