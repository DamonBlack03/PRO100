using BoardDisplay.Models;

namespace BoardDisplay.Pieces
{
    class Rook : Piece
    {

        public Rook(PieceColor color, BoardPosition startingPosition) : base(color, startingPosition) { }

        public override bool CanMove(BoardPosition newPosition)
        {

            if (IsSameLocation(newPosition))
            {
                return false;
            }

            return Position.Row == newPosition.Row || Position.Column == newPosition.Column;
        }
    }
}
