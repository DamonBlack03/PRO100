using BoardDisplay.Models;
namespace BoardDisplay.Pieces
{
    public class Pawn : Piece
    {
        public bool HasMadeFirstMove { get; set; }
        public Pawn(PieceColor color, BoardPosition position) : base(color, position) {}

        public override bool CanMove(BoardPosition newPosition)
        {
            //if ((position.Item1 == this.Position.Item1 + 2))
            //{
            //    return true;
            //}
            //else if ((position.Item1 == Position.Item1 + 1) &&
            //         (position.Item2 == Position.Item2 || position.Item2 == Position.Item2 + 1 || position.Item2 == Position.Item2 - 1))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return (
                        (newPosition.Row == Position.Row + 2 && !HasMadeFirstMove) ||
                        (
                            (newPosition.Row == Position.Row + 1) && 
                            (newPosition.Column == Position.Column || newPosition.Column == Position.Column + 1 || newPosition.Column == Position.Column - 1)
                        )
                    ) ? 
                    true : 
                    false;
            //ternary for fun cause why not
        }

    }
}
