using BoardDisplay.Models;
using System;
using System.Collections.Generic;

namespace BoardDisplay.Pieces
{
    public class Pawn : Piece
    {
        public bool HasMadeFirstMove { get; set; } = false;
        public Pawn(PieceColor color, BoardPosition position) : base(color, position) { }

        public override List<BoardPosition> GetMoveSet(Piece[,] board)
        {
            List<BoardPosition> list = new List<BoardPosition>();
            if (PieceColor == PieceColor.WHITE)
            {
                list = GetBoardPositions(-1, board);
            }
            else if (PieceColor == PieceColor.BLACK)
            {
                list = GetBoardPositions(1, board);
            }

            return list;
        }
        private List<BoardPosition> GetBoardPositions(int rowDirection, Piece[,] board)
        {
            List<BoardPosition> list = new List<BoardPosition>();
            if (rowDirection < -1 || rowDirection == 0 || rowDirection > 1)
            {
                throw new ArgumentException();
            }
            try
            {
                if (board[Position.Row + rowDirection, Position.Column] == null)
                {
                    list.Add(new BoardPosition(Position.Row + rowDirection, Position.Column));
                    int additionalSquare = rowDirection < 0 ? rowDirection - 1 : rowDirection + 1;
                    if (!HasMadeFirstMove && board[Position.Row + additionalSquare, Position.Column] == null)
                    {
                        list.Add(new BoardPosition(Position.Row + additionalSquare, Position.Column));
                    }
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (board[Position.Row + rowDirection, Position.Column - 1] != null && board[Position.Row + rowDirection, Position.Column - 1].PieceColor != PieceColor)
                {
                    list.Add(new BoardPosition(Position.Row + rowDirection, Position.Column - 1));
                }
            }
            catch (IndexOutOfRangeException) { };
            try
            {
                if (board[Position.Row + rowDirection, Position.Column + 1] != null && board[Position.Row + rowDirection, Position.Column + 1].PieceColor != PieceColor)
                {
                    list.Add(new BoardPosition(Position.Row + rowDirection, Position.Column + 1));
                }
            }
            catch (IndexOutOfRangeException) { };
            return list;
        }
    }

}
