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
        static void Main(string[] args)
        {
            Piece[,] p = new Piece[8,8];
            p[3,4] = new Rook();
            Console.WriteLine("Rook test");
            Console.WriteLine(p[3,4].CanMove(ref p, 'r', 3, 'B', 2, true));
            Console.WriteLine(p[3,4].CanMove(ref p, 'D', 3, 'D', 5, true));
            Console.WriteLine(p[3,4].CanMove(ref p, 'D', 3, 'B', 3, true));
            p[3,4] = new Knight();
            Console.WriteLine("Knight test");
            Console.WriteLine(p[3,4].CanMove(ref p, 'r', 3, 'B', 2, true));
            Console.WriteLine(p[3,4].CanMove(ref p, 'D', 3, 'B', 2, true));
        }
    }
}
