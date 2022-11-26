using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Field
    {
        public static void Build(string[,] matrix)
        {
            Console.Clear();
            Console.WriteLine("                  ");

            Console.WriteLine("      |   |   |   ");
            Console.WriteLine("    {0} | {1} | {2} |", matrix[0, 0], matrix[0, 1], matrix[0, 2]);
            Console.WriteLine("      |   |   |   ");

            Console.WriteLine("   ---------------");

            Console.WriteLine("      |   |   |   ");
            Console.WriteLine("    {0} | {1} | {2} |", matrix[1, 0], matrix[1, 1], matrix[1, 2]);
            Console.WriteLine("      |   |   |   ");

            Console.WriteLine("   ---------------");

            Console.WriteLine("      |   |   |   ");
            Console.WriteLine("    {0} | {1} | {2} |", matrix[2, 0], matrix[2, 1], matrix[2, 2]);
            Console.WriteLine("      |   |   |   ");

            Console.WriteLine("                  ");
        }
    }
}
