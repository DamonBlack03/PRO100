using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color, (int, int) position) : base(color, position) { }

        public override bool CanMove((int, int) position)
        {
            throw new NotImplementedException();
        }
    }
}
