using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO.Models
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

        public override bool CanMove(ref Piece[,] p, char from_letter, int from_number, char letter, int number, bool light)
        {
            bool possible = false;
            from_letter -= 'A';
            letter -= 'A';

            if ((from_letter < 8 && from_letter > -1) && (from_number < 8 && from_number > -1) &&
                (letter < 8 && letter > -1) && (number < 8 && number > -1))
            {
                if (from_letter == letter && from_number != number)
                {
                    if (from_number < number)
                    {
                        for (int i = 0; i < number - from_number; i++)
                        {
                            if (from_number + i < 8)
                            {
                                if (p[from_number + i, from_letter] == null)
                                {
                                    possible = true;
                                }
                                else
                                {
                                    if (p[from_number, from_letter].Color != p[number, letter].Color)
                                    {
                                        possible = true;
                                        i = from_number;
                                    }
                                    else
                                    {
                                        if (i != number - from_number)
                                        {
                                            if (p[from_number, from_letter].Color != p[number, letter].Color)
                                            {
                                                possible = true;
                                                i = number;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = from_number - number; i > 0; i--)
                        {
                            if (p[from_number + i, from_letter] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (p[from_number, from_letter].Color != p[number, letter].Color)
                                {
                                    possible = true;
                                    i = number;
                                }
                                else
                                {
                                    if (i != from_number - number)
                                    {
                                        if (p[from_number, from_letter].Color != p[number, letter].Color)
                                        {
                                            possible = true;
                                            i = from_number;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (from_letter != letter && from_number == number)
                {
                    if (from_letter < letter)
                    {
                        for (int i = 0; i < letter - from_letter; i++)
                        {
                            if (p[from_number, from_letter + i] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (i == letter - from_letter)
                                {
                                    if (p[from_number, from_letter].Color != p[number, letter].Color)
                                    {
                                        possible = true;
                                        i = letter;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = from_letter - letter; i > 0; i--)
                        {
                            if (p[from_number, from_letter + i] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (i == from_letter - letter)
                                {
                                    if (p[from_number, from_letter].Color != p[number, letter].Color)
                                    {
                                        possible = true;
                                        i = from_letter;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (from_letter != letter && from_number != number)
                {
                    if (from_letter > letter && from_number > number)
                    {
                        for (int i = from_number - number; i > 0; i--)
                        {
                            for (int j = from_letter - letter; j > 0; j--)
                            {

                            }
                        }
                    }
                    else if (from_letter > letter && from_number < number)
                    {
                        for (int i = 0; i < number - from_letter; i++)
                        {
                            for (int j = from_letter - letter; j > 0; j--)
                            {

                            }
                        }
                    }
                    else if (from_letter < letter && from_number > number)
                    {
                        for (int i = from_number - number; i > 0; i--)
                        {
                            for (int j = 0; j < letter - from_letter; j++)
                            {

                            }
                        }
                    }
                    else if (from_letter < letter && from_number < number)
                    {
                        for (int i = 0; i < number - from_number; i++)
                        {
                            for (int j = 0;  j < letter - from_letter;  j++)
                            {
                                
                            }
                        }
                    }
                }

                int x = number - from_number;
                int y = letter - from_letter;
                if (Math.Abs(x) == Math.Abs(y))
                {
                    if (x > 0)
                    {
                        if (y > 0)
                        {
                            for (int i = 1; i <= Math.Abs(x); i++)
                            {
                                if (p[from_number + i, from_letter + i] == null)
                                {
                                    if (from_letter + i == letter && from_number + i == number)
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
            return "Queen";
        }
    }
}
