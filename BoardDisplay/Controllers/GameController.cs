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

        public GameController()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Board[0, 0] = new Rook(PieceColor.BLACK, new BoardPosition(0, 0));
            Board[0, 1] = new Knight(PieceColor.BLACK, new BoardPosition(0, 1));
            Board[0, 2] = new Bishop(PieceColor.BLACK, new BoardPosition(0, 2));
            Board[0, 3] = new King(PieceColor.BLACK, new BoardPosition(0, 3));
            Board[0, 4] = new Queen(PieceColor.BLACK, new BoardPosition(0, 4));
            Board[0, 5] = new Bishop(PieceColor.BLACK, new BoardPosition(0, 5));
            Board[0, 6] = new Knight(PieceColor.BLACK, new BoardPosition(0, 6));
            Board[0, 7] = new Rook(PieceColor.BLACK, new BoardPosition(0, 7));

            for (int i = 0; i < 8; i++)
            {
                Board[1, i] = new Pawn(PieceColor.BLACK, new BoardPosition(1,i));
                Board[6, i] = new Pawn(PieceColor.WHITE, new BoardPosition(6, i));
            }

            Board[7, 0] = new Rook(PieceColor.WHITE, new BoardPosition(7, 0));
            Board[7, 1] = new Knight(PieceColor.WHITE, new BoardPosition(7, 1));
            Board[7, 2] = new Bishop(PieceColor.WHITE, new BoardPosition(7, 2));
            Board[7, 3] = new King(PieceColor.WHITE, new BoardPosition(7, 3));
            Board[7, 4] = new Queen(PieceColor.WHITE, new BoardPosition(7, 4));
            Board[7, 5] = new Bishop(PieceColor.WHITE, new BoardPosition(7, 5));
            Board[7, 6] = new Knight(PieceColor.WHITE, new BoardPosition(7, 6));
            Board[7, 7] = new Rook(PieceColor.WHITE, new BoardPosition(7, 7));
        }

    }
}
