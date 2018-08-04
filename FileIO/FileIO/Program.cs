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
            string[] pieces = System.IO.File.ReadAllLines(@"C:\Users\Damon Black\Desktop\Net\PRO100\FileIO\PiecePlacement.txt");
            for (int i = 0; i < pieces.Length; i++)
            {
                int x = (int)(pieces[i][3] - '0');
                int y = (int)(pieces[i][2] - 'A');
                bool light = (pieces[i][1] == 'l') ? true : false;
                char temp = pieces[i][0];

                switch (temp)
                {
                    case 'Q':
                        p[x, y] = new Queen(light);
                        break;
                    case 'K':
                        p[x, y] = new King(light);
                        break;
                    case 'B':
                        p[x, y] = new Bishop(light);
                        break;
                    case 'R':
                        p[x, y] = new Rook(light);
                        break;
                    case 'N':
                        p[x, y] = new Knight(light);
                        break;
                    default:
                        break;
                }

            }
        }

        static void Main(string[] args)
        {
            //Rook doesn't work correctly

            Piece[,] p = new Piece[8, 8];
            InitializeBoard(ref p);
            //for (int i = 0; i < p.GetLength(0); i++)
            //{
            //    for (int y = 0; y < p.GetLength(1); y++)
            //    {
            //        if(p[i, y] != null)
            //        {
            //            Console.WriteLine(p[i,y].ToString());

            //        }
            //    }
            //}

            string[] tests = System.IO.File.ReadAllLines(@"C:\Users\Damon Black\Desktop\Net\PRO100\FileIO\MoveTests1.txt");

            //Console.WriteLine(tests.Length);
            int count = 0;
            for (int i = 0; i < tests.Length; i++)
            {
                count++;
                if (tests[i] != null && tests[i] != "")
                {
                    if (tests[i][0] >= 'a' && tests[i][0] <= 'h' &&
                        tests[i][3] >= 'a' && tests[i][3] <= 'h' &&
                        tests[i][1] >= '0' && tests[i][1] <= '7' &&
                        tests[i][4] >= '0' && tests[i][4] <= '7')
                    {
                        char temp_from_letter = tests[i].ToUpper()[0];
                        int temp_from_number = (int)(tests[i][1] - '0');
                       // temp_from_number -= '0';

                        char temp_letter = tests[i].ToUpper()[3];
                        int temp_number = (int)(tests[i][4] - '0');

                        //Console.WriteLine(temp_from_number);
                        //Console.WriteLine(temp_from_letter);
                        if (p[temp_from_number, temp_from_letter - 'A'] != null)
                        {
                            Console.WriteLine($"{p[temp_from_number, temp_from_letter - 'A'].ToString()} has moved from position " +
                                $"{temp_from_letter}{(int)(tests[i][1] - '0')} to position {temp_letter}{(int)(tests[i][4] - '0')}");
                            temp_from_letter -= 'A';
                            temp_letter -= 'A';
                            
                            //Console.WriteLine((temp_from_letter.ToString()));
                            p[(int)(tests[i][1] - '0'), (int)temp_from_letter].Move(ref p, temp_from_letter, (int)(tests[i][1] - '0'), 
                                temp_letter,
                                (int)(tests[i][4] - '0'));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Position not on board, no move was made.");
                    }

                }
                //Console.WriteLine(count++);
            }
        }
    }
}
