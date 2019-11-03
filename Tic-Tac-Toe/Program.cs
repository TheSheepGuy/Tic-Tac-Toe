using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=TIC-TAC-TOE=");

            List<string> board = MakeBoard(3, 3);
            Console.Write(DrawBoard(board, 3, 3));

            /* Abandon OOP apporach


            // Create the game board.
            var gameBoard = new Board(3, 3);
            // Keep track of the game's state, whether it has ended yet,
            bool end = false;
            // Record what player won. 0 is no-one yet, 1 player 1, 2 player 2, 3 a draw.
            int playerWin = 0;
            int currentPlayer = 1;
            // A variable xust to hold temporary user input, initially empty.
            var input = new ConsoleKeyInfo();

            while(end == false)
            {
                for (int i = 1; i < 3; i++)
                {
                    gameBoard.DrawBoard();
                    Console.WriteLine($"\nPlease enter the x-coordinate of your move, Player {i}");
                    input = Console.ReadKey();
                    // Convert the key to an int.
                    int x = int.Parse(input.KeyChar.ToString());
                    Console.WriteLine($"\nPlease enter the y-coordinate");
                    input = Console.ReadKey();
                    int y = int.Parse(input.KeyChar.ToString());
                    gameBoard.MakeMove(x, y, i);
                }
            }*/
        }

        static List<string> MakeBoard(int width, int height)
        {
            List<string> createdBoard = new List<string>();

            // Fill the board with empty spaces.
            for (int i = 0; i < width*height; i++)
            {
                createdBoard.Add(" ");
            }

            return createdBoard;
        }
        static string DrawBoard(List<string> boardToDraw, int width, int height)
        {
            StringBuilder toReturn = new StringBuilder("+");
            // Add the top border. For Tic-Tac-Toe, this will be "+---+---+---+" (the initial + was added on the line above).
            for (int x = 0; x < width; x++)
            {
                toReturn.Append("---+");
            }
            toReturn.Append("\n|");

            for (int y = 0; y < width; y++)
            {
                // This will add "|   |   |   |" etc. for how long the width says to do so (again, the initial | was added above).
                for (int x = 0; x < width; x++)
                {
                    toReturn.Append("   |");
                }
                toReturn.Append("\n|");

                // Now write in whatever the spaces are, e.g. "| X |   | O |".
                for (int x = 0; x < width; x++)
                {
                    // This write the actual state. x+width*y will return whatever is at the current x,y position.
                    toReturn.Append($" {boardToDraw[(x+width*y)]} |");
                }
                toReturn.Append("\n|");

                // Finally, add "|   |   |   |" again.
                for (int x = 0; x < width; x++)
                {
                    toReturn.Append("   |");
                }
                toReturn.Append("\n+");

                // Add the top border for the next row.
                for (int x = 0; x < width; x++)
                {
                    toReturn.Append("---+");
                }
                toReturn.Append("\n|");
            }

            return toReturn.ToString();
        }
    }
}
