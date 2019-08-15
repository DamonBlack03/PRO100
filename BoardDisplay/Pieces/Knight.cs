using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Pieces
{
    public class Knight : Piece
    {
        public Knight(PieceColor color, (int, int) position) : base(color, position) { }

        public override bool CanMove((int, int) position)
        {
            return (
                        (
                            Math.Abs(position.Item1 - Position.Item1) == 1 && Math.Abs(position.Item2 - Position.Item2) == 2
                        ) ||
                        (
                            Math.Abs(position.Item1 - Position.Item1) == 2 && Math.Abs(position.Item2 - Position.Item2) == 1
                        )
                   ) ? 
                   true : 
                   false;
        }
    }
}
