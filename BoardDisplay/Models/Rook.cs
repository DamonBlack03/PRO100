﻿using System;
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
                                    if (p[number, letter] != null)
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
            }

            return possible;
        }

        public override string ToString()
        {
            return (Color == 0) ? "R" : "r";
        }
    }
}
