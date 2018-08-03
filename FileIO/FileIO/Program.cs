using FileIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileIO.Models;

namespace FileIO
{
    class Program
    {
        public static void InitializeBoard(ref Piece[,] p)
        {
            for (int i = 0; i < p.GetLength(0); i++)
            {
                p[1, i] = new Pawn(false);
                p[6, i] = new Pawn(true);
            }
            p[0, 0] = new Rook(false);
            p[0, 1] = new Knight(false);
            p[0, 2] = new Bishop(false);
            p[0, 3] = new Queen(false);
            p[0, 4] = new King(false);
            p[0, 5] = new Bishop(false);
            p[0, 6] = new Knight(false);
            p[0, 7] = new Rook(false);

            p[7, 0] = new Rook(true);
            p[7, 1] = new Knight(true);
            p[7, 2] = new Bishop(true);
            p[7, 3] = new Queen(true);
            p[7, 4] = new King(true);
            p[7, 5] = new Bishop(true);
            p[7, 6] = new Knight(true);
            p[7, 7] = new Rook(true);

        }

        static void Main(string[] args)
        {
            //Rook doesn't work correctly

            Piece[,] p = new Piece[8, 8];
            InitializeBoard(ref p);

            string[] temp = System.IO.File.ReadAllLines(@"C:\Users\Damon Black\Desktop\Net\PRO100\FileIO\MoveTests1.txt");
            string[] tests = new string[(temp.Length/2) + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                tests[i / 2] += temp[i];
            }

            for (int i = 0; i < tests.Length; i++)
            {
                char temp_from_letter = tests[i].ToUpper()[0];
                int temp_from_number = (int)tests[i][1] - 48;
               
                char temp_letter = tests[i].ToUpper()[3];
                int temp_number = (int)tests[i][4] - 48;

                //Console.WriteLine(temp_from_letter + " " + temp_from_number);
                //Console.WriteLine(temp_letter + " " + temp_number);
                if ((temp_from_letter - 65) > 7 || (temp_from_letter - 65) < 0 ||
                    temp_from_number > 7 || temp_from_number < 0)
                {
                    Console.WriteLine("Not a position on the board");
                }
                else
                {
                    if (p[temp_from_number, (temp_from_letter - 65)] != null)
                    {
                        if (p[temp_from_number, (temp_from_letter - 65)].CanMove(ref p, temp_from_letter, temp_from_number,
                            temp_letter, temp_number, (p[temp_from_number, (temp_from_letter - 65)].Color) == 0) ? true : false)
                        {
                            Console.WriteLine($"{p[temp_from_number, (temp_from_letter - 65)].ToString()} " +
                                $"moved from {temp_from_letter}{temp_from_number} to {temp_letter}{temp_number}.");
                        }
                        else
                        {
                            Console.WriteLine("Move was not valid.");
                        }

                    }
                }

            }

        }
    }
}
