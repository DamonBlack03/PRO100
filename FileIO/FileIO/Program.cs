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
            p[3,4] = new Queen();
            Console.WriteLine(p[3,4].CanMove(ref p, 'r', 3, 'B', 2, true)); //false
            Console.WriteLine(p[3,4].CanMove(ref p, 'D', 3, 'F', 5, true)); //true
            Console.WriteLine(p[3,4].CanMove(ref p, 'D', 3, 'F', 1, true)); //true
            Console.WriteLine(p[3, 4].CanMove(ref p, 'D', 3, 'D', 4, true)); //true
            Console.WriteLine(p[3, 4].CanMove(ref p, 'D', 3, 'B', 3, true)); //true
        }
    }
}
