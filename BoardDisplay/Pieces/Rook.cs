namespace BoardDisplay.Pieces
{
    class Rook : Piece
    {
        public override bool CanMove((int, int) position)
        {
            int newRow = position.Item1;
            int newColumn = position.Item2;

            return (!(newRow == Position.Item1 && newColumn == newRow) && newRow >= 0 && newColumn >= 0 && newRow <= 8 && newColumn <= 8 && (newRow == Position.Item1 || newColumn == Position.Item2));
        }
    }
}
