using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Models
{
    class Pawn : Piece
    {
        public Pawn(bool light)
        {
            if (light)
            {
                this.Color = 0;
            }
            else
            {
                this.Color = 1;
            }
        }

        public override bool CanMove(ref Piece[,] p, int from_row, int from_column, int row, int column)
        {
            bool possible = false;

            if ((from_row < 8 && from_row > -1) && (from_column < 8 && from_column > -1) &&
                (row < 8 && row > -1) && (column < 8 && column > -1))
            {
                if (Color == 0)
                {
                    if (row == (from_row - 1))
                    {
                        if (from_column == column && p[row, column] == null)
                        {
                            possible = true;
                        }
                        else if (column == (from_column - 1) || column == (from_column + 1))
                        {
                            if (p[row, column] != null && p[row, column].Color != p[from_row, from_column].Color)
                            {
                                possible = true;
                            }
                        }
                    }
                    else if (from_row == 6)
                    {
                        if (row == 4 && (from_column == column))
                        {
                            if (p[row, column] == null && p[row, column - 1] == null)
                            {
                                possible = true;
                            }
                        }
                    }
                }
                else
                {
                    if (row == (from_row + 1))
                    {
                        if (from_column == column && p[row, column] == null)
                        {
                            possible = true;
                        }
                        else if (column == (from_column - 1) || column == (from_column + 1))
                        {
                            if (p[row, column] != null && p[row, column].Color != p[from_row, from_column].Color)
                            {
                                possible = true;
                            }
                        }
                    }
                    else if (from_row == 1)
                    {
                        if (row == 3 && (from_column == column))
                        {
                            if (p[row, column] == null && p[row, column - 1] == null)
                            {
                                possible = true;
                            }
                        }
                    }
                }
            }

            return possible;
        }

        public override string ToString()
        {
            return (Color == 0) ? "P": "p";
        }
    }
}
