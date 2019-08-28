using BoardDisplay.Models;
using BoardDisplay.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Controllers
{
    public class GameController
    {
        //Row, Column
        public Piece[,] Board { get; set; }

        private PieceColor ActivePlayer = PieceColor.BLACK;

        public GameController(Piece[,] board)
        {
            Board = board;
        }

        public bool IsInCheckmate(PieceColor checkingFor)
        {
            bool isInCheckmate = true;

            //check each piece for a valid move
            isInCheckmate = !AnyValidMoves(checkingFor);

            return isInCheckmate;
        }

        private bool AnyValidMoves(PieceColor allyColor)
        {
            bool anyValidMoves = false;

            //get each piece of same color
            foreach (var piece in Board)
            {
                if (piece != null && piece.PieceColor.Equals(allyColor))
                {
                    //get list of possible moves
                    List<BoardPosition> possibleMoves = piece.GetMoveSet(Board);

                    //see if any moves leave the board not in check
                    foreach (var move in possibleMoves)
                    {
                        anyValidMoves = IsValidMove(move, piece.Position, allyColor) ? true : anyValidMoves;
                    }
                }
                if (anyValidMoves)
                {
                    return anyValidMoves;
                }
            }


            return anyValidMoves;
        }

        private bool IsValidMove(BoardPosition newPosition, BoardPosition oldPosition, PieceColor allyColor)
        {
            bool valid = true;

            //get replica of board
            Piece[,] replicate = duplicateBoard(Board);

            //swap out positions
            MainController m = new MainController();
            m.MoveSelectedPiece(oldPosition, newPosition, replicate);

            //check for check
            valid = !m.IsInCheck(allyColor, replicate);



            return valid;
        }

        private Piece[,] duplicateBoard(Piece[,] board)
        {
            Piece[,] result = new Piece[8, 8];

            foreach (var peice in board)
            {
                if (peice != null)
                {
                    if (peice is Bishop b)
                    {
                        result[peice.Position.Row, peice.Position.Column] = new Bishop(peice.PieceColor, new BoardPosition(peice.Position.Row, peice.Position.Column));

                    } else if(peice is King ki)
                    {
                        result[peice.Position.Row, peice.Position.Column] = new King(peice.PieceColor, new BoardPosition(peice.Position.Row, peice.Position.Column));

                    }
                    else if(peice is Knight kn)
                    {
                        result[peice.Position.Row, peice.Position.Column] = new Knight(peice.PieceColor, new BoardPosition(peice.Position.Row, peice.Position.Column));

                    }
                    else if(peice is Pawn pa)
                    {
                        result[peice.Position.Row, peice.Position.Column] = new Pawn(peice.PieceColor, new BoardPosition(peice.Position.Row, peice.Position.Column));

                    }
                    else if(peice is Queen q)
                    {
                        result[peice.Position.Row, peice.Position.Column] = new Queen(peice.PieceColor, new BoardPosition(peice.Position.Row, peice.Position.Column));

                    }
                    else if(peice is Rook p)
                    {
                        result[peice.Position.Row, peice.Position.Column] = new Rook(peice.PieceColor, new BoardPosition(peice.Position.Row, peice.Position.Column));

                    }

                }
            }

            return result;

        }
    }
}
