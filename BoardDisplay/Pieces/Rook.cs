namespace BoardDisplay.Pieces
{
    class Rook : Piece
    {

        public Rook(PieceColor color, (int, int) startingPosition) : base(color, startingPosition) { }

        public override bool CanMove((int, int) position)
        {

            if (IsSameLocation(position))
            {
                return false;
            }

            int newRow = position.Item1;
            int newColumn = position.Item2;

            return newRow == Position.Item1 || newColumn == Position.Item2;
        }
    }
}
