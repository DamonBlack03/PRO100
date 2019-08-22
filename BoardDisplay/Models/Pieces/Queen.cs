using BoardDisplay.Models;

namespace BoardDisplay.Pieces
{
    class Queen : Piece
    {
        public Queen(PieceColor color, BoardPosition startingPosition) : base(color, startingPosition) { }

        public override bool CanMove(BoardPosition newPositon)
        {
            return new Bishop(PieceColor, Position).CanMove(newPositon) || new Rook(PieceColor, Position).CanMove(newPositon);
        }
    }
}
