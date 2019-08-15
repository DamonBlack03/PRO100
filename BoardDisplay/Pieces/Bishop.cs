using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color, (int, int) position) : base(color, position){ }

        public override bool CanMove((int, int) position)
        {
            return (
                        Math.Abs(position.Item1 - Position.Item1) == Math.Abs(position.Item2 - Position.Item2)
                   ) ? 
                   true : 
                   false;
        }
    }
}
