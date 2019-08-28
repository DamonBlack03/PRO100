using BoardDisplay.Models;
using BoardDisplay.Pieces;
using System;
using System.Windows.Controls;

namespace BoardDisplay.Controllers
{
    public class MainController
    {
        //Should Move Most of this logic into the Game Controller. Game controller should handle movement and checking whereas this controller should handle
        //updating the GUI with correct information.
        #region PieceMovement
        /// <summary>
        /// Move a Selected Piece
        /// </summary>
        /// <param name="newPosition">The new Row and Column the piece will move</param>
        /// <param name="gameBoard">The 2d array with all the pieces</param>
        /// <returns>Returns wether or not the piece successfully moved to the new location</returns>
        public bool MoveSelectedPiece(BoardPosition oldPosition, BoardPosition newPosition, Piece[,] gameBoard)
        {

            var piece = gameBoard[oldPosition.Row, oldPosition.Column];

            if (piece.GetMoveSet(gameBoard).Contains(newPosition))
            {
                if (IsPiecePresentAt(newPosition, gameBoard))
                {
                    if (CanCapturePiece(piece,newPosition, gameBoard))
                    {
                        TakePiece(newPosition, gameBoard);
                        Move(piece, newPosition, gameBoard);
                        return true;
                    }
                }
                else
                {
                    Move(piece, newPosition, gameBoard);
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Checks wether or not a piece is present
        /// </summary>
        /// <param name="newPosition">The position (row, column) to check</param>
        /// <returns></returns>
        private bool IsPiecePresentAt(BoardPosition newPosition, Piece[,] gameBoard)
        {
            return gameBoard[newPosition.Row, newPosition.Column] != null;
        }
        /// <summary>
        /// Returns wether the new position is an enemy and can legally capture that piece
        /// </summary>
        /// <param name="p"></param>
        /// <param name="positionToCheck"></param>
        /// <returns></returns>
        private bool CanCapturePiece(Piece p, BoardPosition positionToCheck, Piece[,] gameBoard)
        {
            return !IsLocationAFriendly(p, positionToCheck, gameBoard);
        }
        /// <summary>
        /// Checks to see if a piece at a given location is the same color
        /// </summary>
        /// <param name="p"></param>
        /// <param name="positionToCheck"></param>
        /// <returns></returns>
        private bool IsLocationAFriendly(Piece p, BoardPosition positionToCheck, Piece[,] gameBoard)
        {
            return gameBoard[positionToCheck.Row, positionToCheck.Column].PieceColor == p.PieceColor;

        }
        /// <summary>
        /// Removes a piece on the board given a position on the board
        /// </summary>
        /// <param name="position">The position of the piece to remove</param>
        private void TakePiece(BoardPosition position,Piece[,] gameBoard)
        {
            gameBoard[position.Row, position.Column] = null;
        }
        private void Move(Piece p, BoardPosition newPosition, Piece[,] gameBoard)
        {
            gameBoard[p.Position.Row, p.Position.Column] = null;
            p.Position = newPosition;
            gameBoard[newPosition.Row, newPosition.Column] = p;
            if (p is Pawn pawn)
            {
                pawn.HasMadeFirstMove = true;
            }
        }

        internal bool IsInCheck(PieceColor allyColor, Piece[,] replicate)
        {
            bool inCheck = false;

            Piece king = null;

            foreach (var canKing in replicate)
            {
                if (canKing != null && canKing is King k)
                {
                    if (k.PieceColor.Equals(allyColor))
                    {
                        king = k;
                    }
                }
            }


            foreach (var piece in replicate)
            {
                if (piece != null && !piece.PieceColor.Equals(allyColor))
                {
                    inCheck = piece.GetMoveSet(replicate).Contains(king.Position) ? true : inCheck;
                }
                if (inCheck)
                {
                    break;
                }
            }

            return inCheck;
        }
        #endregion
        #region UpdateGui
        #endregion
    }
}
