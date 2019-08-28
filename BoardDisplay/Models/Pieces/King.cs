using BoardDisplay.Models;
using System;
using System.Collections.Generic;

namespace BoardDisplay.Pieces
{
    class King : Piece
    {
        public King(PieceColor color, BoardPosition startingPosition) : base(color, startingPosition) { }

        public bool IsInCheck { get; set; }
        public bool IsInCheckMate { get; set; }
        public override List<BoardPosition> GetMoveSet(Piece[,] board)
        {
            List<BoardPosition> list = new List<BoardPosition>();

            list.AddRange(GetPositions(board, 1, -1));
            list.AddRange(GetPositions(board, 1, 0));
            list.AddRange(GetPositions(board, 1, 1));
            list.AddRange(GetPositions(board, -1, -1));
            list.AddRange(GetPositions(board, -1, 0));
            list.AddRange(GetPositions(board, -1, 1));
            list.AddRange(GetPositions(board, 0, 1));
            list.AddRange(GetPositions(board, 0, -1));

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
            return (PieceColor == 0) ? "\u265a" : "\u2654";
        }
    }
}
