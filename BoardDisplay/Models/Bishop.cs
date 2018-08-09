using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Models
{
    class Bishop : Piece
    {
        public Bishop(bool light)
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
            int x = column - from_column;
            int y = row - from_row;
            if (Math.Abs(x) == Math.Abs(y))
            {
                if (x > 0)
                {
                    if (y > 0)
                    {
                        for (int i = 1; i <= Math.Abs(x); i++)
                        {
                            if (p[from_row + i, from_column + i] == null)
                            {
                                if (from_row + i == row && from_column + i == column)
                                {
                                    possible = true;
                                }
                            }
                            else
                            {
                                if (from_row + i == row && from_column + i == column &&
                                    p[row, column].Color != p[from_row, from_column].Color)
                                {
                                    possible = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= Math.Abs(x); i++)
                        {
                            if (p[from_row + i, from_column - i] == null)
                            {
                                if (from_row - i == row && from_column + i == column)
                                {
                                    possible = true;
                                }
                            }
                            else
                            {
                                if (from_row - i == row && from_column + i == column &&
                                    p[row, column].Color != p[from_row, from_column].Color)
                                {
                                    possible = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (y > 0)
                    {
                        for (int i = 1; i <= Math.Abs(x); i++)
                        {
                            if (p[from_row - i, from_column + i] == null)
                            {
                                if (from_row + i == row && from_column - i == column)
                                {
                                    possible = true;
                                }
                            }
                            else
                            {
                                if (from_row + i == row && from_column - i == column &&
                                    p[row, column].Color != p[from_row, from_column].Color)
                                {
                                    possible = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= Math.Abs(x); i++)
                        {
                            if (p[from_row - i, from_column - i] == null)
                            {
                                if (from_row - i == row && from_column - i == column)
                                {
                                    possible = true;
                                }
                            }
                            else
                            {
                                if (from_row - i == row && from_column - i == column &&
                                    p[row, column].Color != p[from_row, from_column].Color)
                                {
                                    possible = true;
                                }
                                else
                                {
                                    break;
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
            return (Color == 0) ? "B" : "b";
        }
    }
}
