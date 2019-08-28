using BoardDisplay.Models;
using System.Collections.Generic;

namespace BoardDisplay.Pieces
{
    class Queen : Piece
    {
        public Queen(PieceColor color, BoardPosition startingPosition) : base(color, startingPosition) { }

        public override List<BoardPosition> GetMoveSet(Piece[,] board)
        {
            List<BoardPosition> list = new List<BoardPosition>();

            list.AddRange(new Rook(PieceColor,Position).GetMoveSet(board));
            list.AddRange(new Bishop(PieceColor,Position).GetMoveSet(board));

            return list;
        }

        public override string ToString()
        {
            return (PieceColor == 0) ? "\u265b" : "\u2655";
        }
    }
}
