using BoardDisplay.Models;

namespace BoardDisplay.Pieces
{
    public abstract class Piece
    {
        //position is (row, column)
        #region properties
        public PieceColor PieceColor { get; private set; }
        public BoardPosition Position { get; set; }
        #endregion
        #region Constructors
        public Piece(PieceColor color, BoardPosition position)
        {
            PieceColor = color;
            Position = position;
        }
        #endregion
        #region Methods
        public bool IsSameLocation(BoardPosition positionToCeck)
        {
            return Position.Row == positionToCeck.Row && Position.Column == positionToCeck.Column;
        }
        #endregion
        #region Abstract Methods
        public abstract bool CanMove(BoardPosition newBoardPosition);
        #endregion
        public override string ToString()
        {
            return (PieceColor == 0) ? this.GetType().Name[0].ToString() : this.GetType().Name[0].ToString().ToLower();
        }
    }
}
