using System;
namespace BoardDisplay.Pieces
{
    class King : Piece
    {
        public King(PieceColor color, (int, int) startingPosition) : base(color, startingPosition) { }

        public bool IsInCheck { get; set; }
        public bool IsInCheckMate { get; set; }
        public override bool CanMove((int, int) position)
        {
            if (IsSameLocation(position))
            {
                return false;
            }
            int newRow = position.Item1;
            int newColumn = position.Item2;

            int rowDiff = Position.Item1 - newRow;
            int colDiff = position.Item2 - newColumn;
            return (Math.Abs(rowDiff) == 1 || Math.Abs(rowDiff) == 0) && (Math.Abs(colDiff) == 1 || Math.Abs(colDiff) == 0);
        }
    }
}
