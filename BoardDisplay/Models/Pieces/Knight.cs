using BoardDisplay.Models;
using System;

namespace BoardDisplay.Pieces
{
    public class Knight : Piece
    {
        public Knight(PieceColor color, BoardPosition position) : base(color, position) { }

        public override bool CanMove(BoardPosition newPositon)
        {
            return (
                        (
                            Math.Abs(newPositon.Row - Position.Row) == 1 && Math.Abs(newPositon.Column - Position.Column) == 2
                        ) ||
                        (
                            Math.Abs(newPositon.Row - Position.Row) == 2 && Math.Abs(newPositon.Column - Position.Column) == 1
                        )
                   ) ? 
                   true : 
                   false;
        }
    }
}
