using System;

namespace BoardDisplay.Pieces
{
    class Queen : Piece
    {
        public Queen(PieceColor color, (int, int) startingPosition) : base(color, startingPosition) { }

        public override bool CanMove((int, int) position)
        {
            return new Bishop(PieceColor, Position).CanMove(position) || new King(PieceColor, Position).CanMove(position) || new Rook(PieceColor, Position).CanMove(position);
        }
    }
}
