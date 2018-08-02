using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO.Models
{
    class Rook : Piece
    {
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
                        //if from number is smaller and you subtract youll get a negative number, 0 is never less
                        //than a negative
                        //why not just do i = from_number; i < number; i++
                        for (int i = 0; i < from_number - number; i++)
                        {
                            //this should give an out of bounds exception so just us [i]
                            if (p[from_number + i,from_letter] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                //reaching here means it hit a piece so there should be a check to see
                                //if this is at the end of the for loop, if this is somewhere in the middle of the
                                //loop then the spot the originally chose isn't possible
                                if (p[from_number,from_letter].Color != p[number,letter].Color)
                                {
                                    possible = true;
                                    //i would just say i = number tobreak it out of the loop without it having to do
                                    //extra math
                                    i = from_number - number;
                                }
                            }
                        }
                    }
                    else
                    {
                        //incorporate the comments from above
                        for (int i = 0; i < number - from_number; i++)
                        {
                            if (p[from_number + i,from_letter] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (p[from_number,from_letter].Color != p[number,letter].Color)
                                {
                                    possible = true;
                                    i = number - from_number;
                                }
                            }
                        }
                    }
                }
                else if (from_letter != letter && from_number == number)
                {
                    if (from_letter < letter)
                    {
                        for (int i = 0; i < from_letter - letter; i++)
                        {
                            if (p[from_number,from_letter + i] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (p[from_number,from_letter].Color != p[number,letter].Color)
                                {
                                    possible = true;
                                    i = from_letter - letter;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < letter - from_letter; i++)
                        {
                            if (p[from_number,from_letter + i] == null)
                            {
                                possible = true;
                            }
                            else
                            {
                                if (p[from_number,from_letter].Color != p[number,letter].Color)
                                {
                                    possible = true;
                                    i = letter - from_letter;
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
            return "Rook";
        }
    }
}
