using BoardDisplay.Models;
using System;
namespace BoardDisplay.Pieces
{
    class King : Piece
    {
        public King(PieceColor color, BoardPosition startingPosition) : base(color, startingPosition) { }

        public bool IsInCheck { get; set; }
        public bool IsInCheckMate { get; set; }
        public override bool CanMove(BoardPosition newPosition)
        {
            if (IsSameLocation(newPosition))
            {
                return false;
            }
            return
                (Math.Abs(Position.Row - newPosition.Row) == 1 && Math.Abs(Position.Column - newPosition.Column) == 0) ||
                (Math.Abs(Position.Column - newPosition.Column) == 1 && Math.Abs(Position.Row - newPosition.Row) == 0) ||
                (Math.Abs(Position.Column - newPosition.Column) == 1 && Math.Abs(Position.Row - newPosition.Row) == 1);
        }
    }
}
