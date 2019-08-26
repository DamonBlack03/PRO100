using BoardDisplay.Models;
using System;
using System.Collections.Generic;

namespace BoardDisplay.Pieces
{
    public class Knight : Piece
    {
        public Knight(PieceColor color, BoardPosition position) : base(color, position) { }
        public override List<BoardPosition> GetMoveSet(Piece[,] board)
        {
            List<BoardPosition> list = new List<BoardPosition>();

            list.AddRange(GetPositions(board, 2, -1));
            list.AddRange(GetPositions(board, 2, 1));
            list.AddRange(GetPositions(board, -2, -1));
            list.AddRange(GetPositions(board, -2, 1));

            list.AddRange(GetPositions(board, 1, -2));
            list.AddRange(GetPositions(board, 1, 2));
            list.AddRange(GetPositions(board, -1, -2));
            list.AddRange(GetPositions(board, -1, 2));

            return list;
        }

        private List<BoardPosition> GetPositions(Piece[,] board, int rowDiff, int colDiff)
        {
            List<BoardPosition> list = new List<BoardPosition>();

            int row = Position.Row + rowDiff;
            int col = Position.Column + colDiff;

            if (row >= 0 && col >= 0 && row < 8 && col < 8 && (board[row, col] == null || board[row, col].PieceColor != PieceColor))
            {
                list.Add(new BoardPosition(row, col));
            }
            return list;
        }

        public override string ToString()
        {
            return (PieceColor == 0) ? GetType().Name[0].ToString() + "n" : GetType().Name[0].ToString().ToLower() + "n";
        }
    }
}
