using BoardDisplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color,BoardPosition position) : base(color, position){ }

        public override bool CanMove(BoardPosition newPosition)
        {

            if (IsSameLocation(newPosition))
            {
                return false;
            }

            return (
                        Math.Abs(newPosition.Row - Position.Row) == Math.Abs(newPosition.Column - Position.Column)
                   ) ? 
                   true : 
                   false;
        }
    }
}
