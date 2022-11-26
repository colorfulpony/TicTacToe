using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Matrix
    {
        private readonly string[,] matrix =
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"}
            };

        public string[,] GetMatrix()
        {
            return matrix; 
        }

        public static string[,] ChangeMatrix(string[,] matrix, int placeToChange, string symbol)
        {
            try
            {
                switch (placeToChange)
                {
                    case 1:
                        matrix[0, 0] = symbol;
                        break;
                    case 2:
                        matrix[0, 1] = symbol;
                        break;
                    case 3:
                        matrix[0, 2] = symbol;
                        break;
                    case 4:
                        matrix[1, 0] = symbol;
                        break;
                    case 5:
                        matrix[1, 1] = symbol;
                        break;
                    case 6:
                        matrix[1, 2] = symbol;
                        break;
                    case 7:
                        matrix[2, 0] = symbol;
                        break;
                    case 8:
                        matrix[2, 1] = symbol;
                        break;
                    case 9:
                        matrix[2, 2] = symbol;
                        break;
                }
                return matrix;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }

        }
    }
}
