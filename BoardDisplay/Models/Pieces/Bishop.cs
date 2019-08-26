using BoardDisplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color, BoardPosition position) : base(color, position) { }

        public override List<BoardPosition> GetMoveSet(Piece[,] board)
        {
            List<BoardPosition> list = new List<BoardPosition>();

            list.AddRange(GetDiagnolMoves(board, -1, 1));
            list.AddRange(GetDiagnolMoves(board, -1, -1));
            list.AddRange(GetDiagnolMoves(board, 1, 1));
            list.AddRange(GetDiagnolMoves(board, 1, -1));



            return list;
        }

        private List<BoardPosition> GetDiagnolMoves(Piece[,] board, int rowDirection, int columnDirection)
        {

            List<BoardPosition> list = new List<BoardPosition>();
            int currentRow = Position.Row + rowDirection;
            int currentColumn = Position.Column + columnDirection;
            while (currentColumn >= 0 && currentRow >= 0 && currentColumn < 8 && currentRow < 8)
            {
                if (board[currentRow, currentColumn] == null)
                {
                    list.Add(new BoardPosition(currentRow, currentColumn));
                }
                else if (board[currentRow, currentColumn].PieceColor != PieceColor)
                {
                    list.Add(new BoardPosition(currentRow, currentColumn));
                    return list;
                }
                else
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
