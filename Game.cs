using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        private static int moves = 0;
        private static string playerOneSymbol = "X";
        private static string playerTwoSymbol = "O";
        private static bool playerOneTurn = true;
        private static bool playerTwoTurn = false;

        public void StartGame()
        {
            Matrix newInstanceOfMatrix = new();
            string[,] matrix = newInstanceOfMatrix.GetMatrix();
            Field.Build(matrix);

            do
             {
                 int playerChoosenPosition = 0;

                 if (playerOneTurn)
                 {
                     MoveInfo("1", playerOneSymbol);

                     playerChoosenPosition = GetPlayerChoosedPosition("1", matrix);

                     if (CheckIfPositionIsAvailable(matrix, playerChoosenPosition))
                     {
                        matrix = Matrix.ChangeMatrix(matrix, playerChoosenPosition, playerOneSymbol);
                        Field.Build(matrix);

                         if (CheckWin(matrix))
                         {
                            RestartGame("Player 1 won! Congratulations!");
                         }

                         moves++;
                         playerOneTurn = false;
                         playerTwoTurn = true;
                     }
                     else
                     {
                        Field.Build(matrix);
                        Console.WriteLine($"Position {playerChoosenPosition} is already taken. Please choose another one");
                     }

                     continue;

                 }

                 if (playerTwoTurn)
                 {
                     MoveInfo("2", playerTwoSymbol);

                     playerChoosenPosition = GetPlayerChoosedPosition("2", matrix);

                     if (CheckIfPositionIsAvailable(matrix, playerChoosenPosition))
                     {
                        matrix = Matrix.ChangeMatrix(matrix, playerChoosenPosition, playerTwoSymbol);
                        Field.Build(matrix);

                        if (CheckWin(matrix))
                         {
                            RestartGame("Player 2 won! Congratulations!");
                         }

                         moves++;
                         playerOneTurn = true;
                         playerTwoTurn = false;
                     }
                     else
                     {
                         Field.Build(matrix);
                        Console.WriteLine($"Position {playerChoosenPosition} is already taken. Please choose another one");
                     }

                     continue;
                 }
             } while (moves < 9);

             if (moves == 9)
             {
                RestartGame("Draw. Game Over!");
             }

            Console.Read();
        }

        private static bool CheckWin(string[,] board)
        {
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }  
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    {
                        return true;
                    }
                    else if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private void MoveInfo(string player, string symbol)
        {
            Console.WriteLine($"Player's {player} move");
            Console.WriteLine($"Enter place where you want to put {symbol}:");
        }

        private int GetPlayerChoosedPosition(string player, string[,] matrix)
        {
            int temp;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out temp) && temp >= 1 && temp <= 9)
                {
                    return temp;
                }
                else
                {
                    Field.Build(matrix);
                    Console.WriteLine($"Player's {player} move");
                    Console.WriteLine($"Enter place where you want to put {playerOneSymbol}:");
                    Console.WriteLine("Incorrect format. Please enter number from 1 to 9");
                }
            }
        }

        private bool CheckIfPositionIsAvailable(string[,] matrix, int position)
        {
            int temp = 0;
            try
            {
                switch (position)
                {
                    case 1:
                        return int.TryParse(matrix[0, 0], out temp);
                    case 2:
                        return int.TryParse(matrix[0, 1], out temp);
                    case 3:
                        return int.TryParse(matrix[0, 2], out temp);
                    case 4:
                        return int.TryParse(matrix[1, 0], out temp);
                    case 5:
                        return int.TryParse(matrix[1, 1], out temp);
                    case 6:
                        return int.TryParse(matrix[1, 2], out temp);
                    case 7:
                        return int.TryParse(matrix[2, 0], out temp);
                    case 8:
                        return int.TryParse(matrix[2, 1], out temp);
                    case 9:
                        return int.TryParse(matrix[2, 2], out temp);
                    default:
                        return false;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
        }

        public static void RestartGame(string endGameText)
        {
            playerOneTurn = true;
            playerTwoTurn = false;
            moves = 0;

            Console.WriteLine(endGameText);
            Console.WriteLine("If you want to start again - press Enter. If you want to exit - press any other button");
            ConsoleKey ck = Console.ReadKey(true).Key;
            if (ck == ConsoleKey.Enter)
            {
                Game game = new();
                game.StartGame();
            }
            else 
            {
                System.Environment.Exit(0);
            }
        }
    }
}
