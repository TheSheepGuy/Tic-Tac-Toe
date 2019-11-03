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
