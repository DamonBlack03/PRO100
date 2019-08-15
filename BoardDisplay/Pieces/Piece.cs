namespace BoardDisplay.Pieces
{
    public abstract class Piece
    {
        //position is (row, column)
        #region properties
        public PieceColor PieceColor { get; private set; }
        public (int, int) Position { get; set; }
        #endregion
        #region Constructors
        public Piece(PieceColor color, (int, int) position)
        {
            PieceColor = color;
            Position = position;
        }
        #endregion
        #region Methods
        public bool IsSameLocation((int,int) newPosition)
        {
            return Position.Item1 == newPosition.Item1 && Position.Item2 == newPosition.Item2;
        }
        #endregion
        #region Abstract Methods
        public abstract bool CanMove((int, int) position);
        #endregion
        public override string ToString()
        {
            return (PieceColor == 0) ? this.GetType().Name[0].ToString() : this.GetType().Name[0].ToString().ToLower();
        }
    }
}
