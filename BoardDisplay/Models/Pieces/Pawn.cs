using BoardDisplay.Models;
namespace BoardDisplay.Pieces
{
    public class Pawn : Piece
    {
        public bool HasMadeFirstMove { get; set; } = true;
        public Pawn(PieceColor color, BoardPosition position) : base(color, position) {}

        public override bool CanMove(BoardPosition newPosition)
        {
            return (
                        (this.PieceColor == PieceColor.WHITE &&
                            (newPosition.Row == Position.Row - 2 && !HasMadeFirstMove && newPosition.Column == Position.Column) ||
                            (newPosition.Row == Position.Row - 1 && newPosition.Column == Position.Column)
                        ) ||
                        (this.PieceColor == PieceColor.BLACK &&
                            (newPosition.Row == Position.Row + 2 && !HasMadeFirstMove && newPosition.Column == Position.Column) ||
                            (newPosition.Row == Position.Row + 1 && newPosition.Column == Position.Column)
                        )
                   ) ? 
                   true : 
                   false;
            //ternary for fun cause why not
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
