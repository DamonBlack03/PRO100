using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Models
{
    class Queen : Piece
    {
        public Queen(bool light)
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
                if (x > 0)//right side
                {
                    if (y > 0)//going down
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
                                    possible = false;
                                    break;
                                }
                            }
                        }
                    }
                    else// going up
                    {
                        for (int i = 1; i <= Math.Abs(x); i++)
                        {
                            if (from_row - i >= 0 && from_column + i < 8)
                            {
                                if (p[from_row - i, from_column + i] == null)
                                {
                                    //if (from_row - i >= 0 && from_column + i < 8)
                                    //{
                                    //    if (from_row - i == row && from_column + i == column)
                                    //    {
                                    //        possible = true;
                                    //    }
                                    //}
                                    possible = true;
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
                                        possible = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else//going left
                {
                    if (y > 0) // going down
                    {
                        for (int i = 1; i <= Math.Abs(x); i++)
                        {
                            if (from_row + i < 8 && from_column - i >= 0)
                            {
                                if (p[from_row + i, from_column - i] == null)
                                {
                                    if (from_row + i == row && from_column - i == column)
                                    {
                                        possible = true;
                                    }
                                }
                                else
                                {
                                    //if (from_row + i < 8 && from_column - i >= 0)
                                    //{
                                    if (from_row + i == row && from_column - i == column &&
                                    p[row, column].Color != p[from_row, from_column].Color)
                                    {
                                        possible = true;
                                    }
                                    else
                                    {
                                        possible = false;
                                        break;
                                    }
                                    //}
                                    //else
                                    //{
                                    //    break;
                                    //}
                                }
                            }
                        }
                    }
                    else// going up
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
                                    possible = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if ((from_row < 8 && from_row > -1) && (from_column < 8 && from_column > -1) &&
                (row < 8 && row > -1) && (column < 8 && column > -1))
            {
                if (from_row == row && from_column != column)//going side to side
                {
                    if (from_column < column)//going  right
                    {
                        for (int i = column; i >= from_column + 1; i--)
                        {
                            //if (i < 8)
                            //{
                            if (p[from_row, i] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (p[from_row, from_column].Color != p[row, i].Color)
                                {
                                    if (i == column)
                                    {
                                        possible = true;
                                        for (int z = i - 1; z > from_column; z--)
                                        {
                                            if (p[row, z] != null)
                                            {
                                                possible = false;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        possible = false;
                                    }
                                }
                                else
                                {
                                    possible = false;
                                }
                                break;
                            }
                            //}
                        }
                    }
                    else// going left
                    {
                        for (int i = column; i <= from_column - 1; i++)
                        {
                            //if (i > -1)
                            //{
                            if (p[from_row, i] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (p[from_row, from_column].Color != p[row, i].Color)
                                {
                                    if (i == column)
                                    {
                                        possible = true;
                                        for (int z = i + 1; z < from_column; z++)
                                        {
                                            if (p[row, z] != null)
                                            {
                                                possible = false;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        possible = false;
                                    }
                                }
                                else
                                {
                                    possible = false;
                                }
                                break;
                            }
                            //}
                        }
                    }
                }
                else if (from_row != row && from_column == column)//going up or down
                {
                    if (from_row < row) // moving down
                    {
                        for (int i = row; i >= from_row + 1; i--)
                        {
                            //if (i < 8)
                            //{
                            if (p[i, from_column] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                //if (i == row - from_row)
                                //{
                                if (p[from_row, from_column].Color != p[i, column].Color)
                                {
                                    if (i == row)
                                    {
                                        possible = true;
                                        for (int z = i - 1; z > from_row; z--)
                                        {
                                            if (p[z, column] != null)
                                            {
                                                possible = false;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        possible = false;
                                    }
                                }
                                else
                                {
                                    possible = false;
                                }
                                break;
                                //}
                            }
                            //}
                        }
                    }
                    else // moving up
                    {
                        for (int i = row; i <= from_row - 1; i++)
                        {
                            //if (i > -1)
                            //{
                            if (p[i, from_column] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                //if (i == from_row - row)
                                //{
                                if (p[from_row, from_column].Color != p[i, column].Color)
                                {
                                    if (i == row)
                                    {
                                        possible = true;
                                        for (int z = i + 1; z < from_row; z++)
                                        {
                                            if (p[z, column] != null)
                                            {

                                                possible = false;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        possible = false;
                                    }
                                }
                                else
                                {
                                    possible = false;
                                }
                                break;
                                //}
                            }
                            //}
                        }
                    }
                }
            }
            return possible;
        }

        public override string ToString()
        {
            return (Color == 0) ? "Q" : "q";
        }
        //Copy paste a success
    }
}
