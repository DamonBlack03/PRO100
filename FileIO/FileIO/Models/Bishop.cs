using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO.Models
{
    class Bishop : Piece
    {
        public Bishop(int color)
        {
            // 0 = white 1 = black
            this.Color = color;
        }

        public override bool CanMove(ref Piece[,] p, char from_letter, int from_number, char letter, int number, bool light)
        {
            bool possible = false;
            from_letter -= 'A';
            letter -= 'A';
            int x = number - from_number;
            int y = letter - from_letter;

            if ((from_letter < 8 && from_letter > -1) && (from_number < 8 && from_number > -1) &&
                (letter < 8 && letter > -1) && (number < 8 && number > -1))
            {                             
                if(Math.Abs(x) == Math.Abs(y))
                {
                    if (x > 0)
                    {
                        if(y > 0)
                        {
                            for(int i = 1; i <= Math.Abs(x); i++)
                            {
                                if(p[from_number + i, from_letter + i]==null)
                                {
                                    if(from_letter + i == letter && from_number + i == number)
                                    {
                                        possible = true;
                                    }
                                }
                                else
                                {
                                    if (from_letter + i == letter && from_number + i == number &&
                                        p[number, letter].Color != p[from_number, from_letter].Color)
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
                                if (p[from_number + i, from_letter - i] == null)
                                {
                                    if (from_letter - i == letter && from_number + i == number)
                                    {
                                        possible = true;
                                    }
                                }
                                else
                                {
                                    if (from_letter - i == letter && from_number + i == number &&
                                        p[number, letter].Color != p[from_number, from_letter].Color)
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
                                if (p[from_number - i, from_letter + i] == null)
                                {
                                    if (from_letter + i == letter && from_number - i == number)
                                    {
                                        possible = true;
                                    }
                                }
                                else
                                {
                                    if (from_letter + i == letter && from_number - i == number &&
                                        p[number, letter].Color != p[from_number, from_letter].Color)
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
                                if (p[from_number - i, from_letter - i] == null)
                                {
                                    if (from_letter - i == letter && from_number - i == number)
                                    {
                                        possible = true;
                                    }
                                }
                                else
                                {
                                    if (from_letter - i == letter && from_number - i == number &&
                                        p[number, letter].Color != p[from_number, from_letter].Color)
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
            }

            return possible;
        }

        public override string ToString()
        {
            return "Bishop";
        }
    }
}
