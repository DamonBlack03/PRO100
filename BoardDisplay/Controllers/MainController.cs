using BoardDisplay.Models;
using BoardDisplay.Pieces;
using System.Linq;

namespace BoardDisplay.Controllers
{
    public class MainController
    {
        #region Properties
        private Piece[,] GameBoard { get; set; }
        private GameController RuleChecker { get; set; }
        #endregion
        #region PieceMovement
        /// <summary>
        /// Move a Selected Piece
        /// </summary>
        /// <param name="p">The piece to be moved</param>
        /// <param name="newRow">The new Row the piece will move</param>
        /// <param name="newColumn">The new Column that the piece will move </param>
        /// <returns>Returns wether or not the piece successfully moved to the new location</returns>
        public bool MoveSelectedPiece(Piece p, BoardPosition newPosition)
        {
            if (p.CanMove(newPosition))
            {
                if (IsPiecePresentAt(newPosition))
                {
                    if (CanCapturePiece(p,newPosition))
                    {
                        TakePiece(newPosition);
                        return true;
                    }
                }
                else
                {
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
        private bool IsPiecePresentAt(BoardPosition newPosition)
        {
            return GameBoard[newPosition.Row, newPosition.Column] != null;
        }
        /// <summary>
        /// Returns wether if the new position is an enemy and can legally capture that piece
        /// </summary>
        /// <param name="p"></param>
        /// <param name="positionToCheck"></param>
        /// <returns></returns>
        private bool CanCapturePiece(Piece p, BoardPosition positionToCheck)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Checks to see if a piece at a given location is the same color
        /// </summary>
        /// <param name="p"></param>
        /// <param name="positionToCheck"></param>
        /// <returns></returns>
        private bool IsLocationAFriendly(Piece p, BoardPosition positionToCheck)
        {
            return GameBoard[positionToCheck.Row, positionToCheck.Column].PieceColor == p.PieceColor;

        }
        /// <summary>
        /// Removes a piece on the board given a position on the board
        /// </summary>
        /// <param name="p">The position of the piece to remove</param>
        public void TakePiece(BoardPosition p)
        {

        }
        #endregion
        #region UpdateGui
        #endregion
    }
}
