using BoardDisplay.Models;
namespace BoardDisplay.Pieces
{
    public class Pawn : Piece
    {
        public bool HasMadeFirstMove { get; set; } = true;
        public Pawn(PieceColor color, BoardPosition position) : base(color, position) {}

        public override bool CanMove(BoardPosition newPosition)
        {
            if (IsSameLocation(newPosition))
            {
                return false;
            }

            if (newPosition.Column != Position.Column)
            {
                return false;
            }

            if (PieceColor == PieceColor.WHITE)
            {
                return newPosition.Row == Position.Row - 1 || (HasMadeFirstMove && newPosition.Row == Position.Row - 2);
            }else if (PieceColor == PieceColor.BLACK)
            {
                return newPosition.Row == Position.Row + 1 || (HasMadeFirstMove && newPosition.Row == Position.Row + 2);
            }

            return false;

        }

        public bool CanAttack(BoardPosition newPosition)
        {
            return (
                        (this.PieceColor == PieceColor.WHITE &&
                            (newPosition.Row == Position.Row - 1) &&
                            (newPosition.Column == Position.Column + 1 || newPosition.Column == Position.Column - 1)
                        ) ||
                        (this.PieceColor == PieceColor.BLACK &&
                            (newPosition.Row == Position.Row + 1) &&
                            (newPosition.Column == Position.Column + 1 || newPosition.Column == Position.Column - 1)
                        )
                   );
        }

    }
}
