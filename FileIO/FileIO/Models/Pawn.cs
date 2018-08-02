using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO.Models
{
    class Pawn : Piece
    {
        public override bool CanMove(ref Piece[,] p, char from_letter, int from_number, char letter, int number, bool light)
        {
            bool possible = false;
            from_letter -= 'A';
            letter -= 'A';

            if((from_letter < 8 && from_letter > -1) && (from_number < 8 && from_number > -1) &&
                (letter < 8 && letter > -1) && (number < 8 && number > -1))
            {
                if (light)
                {
                    if (letter == (from_letter - 1))
                    {
                        if (from_number == number && p[number,letter] == null)
                        {
                            possible = true;
                        }
                        else if (number == (from_number - 1) || number == (from_number + 1))
                        {
                            if (p[number,letter] != null && p[number,letter].Color != p[from_number,from_letter].Color)
                            {
                                possible = true;
                            }
                        }
                    }
                    else if (from_letter == 6)
                    {
                        if (letter == 4 && (from_number == number))
                        {
                            if (p[number,letter] == null && p[number,letter - 1] == null)
                            {
                                possible = true;
                            }
                        }
                    }
                }
                else
                {
                    if (letter == (from_letter + 1))
                    {
                        if (from_number == number && p[number,letter] == null)
                        {
                            possible = true;
                        }
                        else if (number == (from_number - 1) || number == (from_number + 1))
                        {
                            if (p[number,letter] != null && p[number,letter].Color != p[from_number,from_letter].Color)
                            {
                                possible = true;
                            }
                        }
                    }
                    else if (from_letter == 1)
                    {
                        if (letter == 3 && (from_number == number))
                        {
                            if (p[number,letter] == null && p[number,letter - 1] == null)
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
            return "Pawn";
        }
    }
}
