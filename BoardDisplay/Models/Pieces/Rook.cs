using BoardDisplay.Models;
using System.Collections.Generic;

namespace BoardDisplay.Pieces
{
    class Rook : Piece
    {

        public Rook(PieceColor color, BoardPosition startingPosition) : base(color, startingPosition) { }

        public override List<BoardPosition> GetMoveSet(Piece[,] board)
        {
            List<BoardPosition> list = new List<BoardPosition>();

            list.AddRange(MoveStack(board, -1, 0));
            list.AddRange(MoveStack(board, 1, 0));
            list.AddRange(MoveStack(board, 0, -1));
            list.AddRange(MoveStack(board, 0, 1));

            return list;
        }

        private List<BoardPosition> MoveStack(Piece[,] board, int rowDirection, int columnDirection)
        {
            List<BoardPosition> list = new List<BoardPosition>();
            int currentRow = Position.Row + rowDirection;
            int currentColumn = Position.Column + columnDirection;
            while (currentColumn >= 0 && currentRow >= 0 && currentColumn < 8 && currentRow < 8)
            {
                var locationPiece = board[currentRow, currentColumn];
                if (locationPiece == null)
                {
                    list.Add(new BoardPosition(currentRow, currentColumn));
                }
                else if (locationPiece.PieceColor != PieceColor)
                {
                    list.Add(new BoardPosition(currentRow, currentColumn));
                    return list;
                }
                else if(locationPiece.PieceColor == PieceColor)
                {
                    return list;
                }

                currentRow += rowDirection;
                currentColumn += columnDirection;
            }
            return list;
        }
    }
}
