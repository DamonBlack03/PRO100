using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Models
{
    class Rook : Piece
    {
        public Rook(bool light)
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
                if (from_row == row && from_column != column)//going side to side
                {
                    if (from_column < column)//going  right
                    {
                        for (int i = 0; i < column - from_column; i++)
                        {
                            if (from_column + i < 8)
                            {
                                if (p[from_row + i, from_column] == null)
                                {
                                    possible = true;
                                }
                                else
                                {
                                    if (p[from_row, from_column].Color != p[row, column].Color)
                                    {
                                        possible = true;
                                        i = 56;
                                    }
                                }
                            }
                        }
                    }
                    else// going left
                    {
                        for (int i = from_column - column; i > 0; i--)
                        {
                            if (p[from_row, from_column - i] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (p[from_row, from_column].Color != p[row, column].Color)
                                {
                                    possible = true;
                                    i = 56;
                                }
                            }
                        }
                    }
                }
                else if (from_row != row && from_column == column)//going uo or down
                {
                    if (from_row < row) // moving down
                    {
                        for (int i = 0; i < row - from_row; i++)
                        {
                            if (from_row + i < 8)
                            {
                                if (p[from_row + i, from_column] == null)
                                {
                                    possible = true;
                                }
                                else
                                {
                                    if (i == row - from_row)
                                    {
                                        if (p[from_row, from_column].Color != p[row, column].Color)
                                        {
                                            possible = true;
                                            i = 56;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else // moving up
                    {
                        for (int i = from_row - row; i > 0; i--)
                        {
                            if (p[from_row, from_column + i] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (i == from_row - row)
                                {
                                    if (p[from_row, from_column].Color != p[row, column].Color)
                                    {
                                        possible = true;
                                        i = 56;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return possible;
        }

        public override string ToString()
        {
            return (Color == 0) ? "R" : "r";
        }
    }
}
