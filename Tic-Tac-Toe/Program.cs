using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare initial variables.

            // Declare the symbols used to represent players 1 and 2.
            const string player1Symbol = "X";
            const string player2Symbol = "O";
            string moveSymbol;
            // Temporarily make a board of 3x3.
            const int width = 3;
            const int height = 3;
            // Declare a player variable which keeps track of whose turn it is.
            int player;
            // Take the player's move coordinates.
            int moveX, moveY;



            Console.WriteLine("=TIC-TAC-TOE=");
            
            List<string> board = MakeBoard(width, height);
            // Work out what the possible maximum moves are (which is the area).
            int maxMoves = width * height;


            // Continuously loop until there cannot possibly be any moves left.
            for (int currentMoveNumber = 0; currentMoveNumber < maxMoves; currentMoveNumber++)
            {
                Console.Write(DrawBoard(board, width, height));

                if (currentMoveNumber % 2 == 0)
                {
                    player = 1;
                    moveSymbol = player1Symbol;

                }
                else
                {
                    player = 2;
                    moveSymbol = player2Symbol;
                }

                Console.WriteLine($"Please enter an x-coordinate, player {player}: ");
                moveX = CheckForValidMove(width, height, "X");
                Console.WriteLine($"Please enter a y-coordinate, player {player}: ");
                moveY = CheckForValidMove(width, height, "Y");

                MakeMove(board, moveX, moveY, width, moveSymbol);
            }
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

        static List<string> MakeMove(List<string> board, int x, int y, int width, string currentPlayer)
        {
            List<string> newBoard = board;

            int spaceToPlace = x + width*y;

            newBoard[spaceToPlace] = currentPlayer;

            return newBoard;
        }

        static string DrawBoard(List<string> boardToDraw, int width, int height)
        {
            StringBuilder toReturn = new StringBuilder("\n+");
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

                // If it's not the last loop, then append a | for the next row.
                if (y < width-1)
                {
                    toReturn.Append("\n|");
                }
                // Otherwise, append a new line control character.
                else{
                    toReturn.Append("\n");
                }
            }

            return toReturn.ToString();
        }

        static int CheckForValidMove(int width, int height, string coordinate)
        {
            System.ConsoleKeyInfo input = Console.ReadKey();
            int toReturn = -1;

            // If the move is for the X coordinate, then the maximum value that can be entered must be width-1.
            if (coordinate == "X")
            {
                while (true)
                {
                    // Check if the key pressed is a digit.
                    if (char.IsDigit(input.KeyChar))
                    {
                        // Try and convert it to an int.
                        toReturn = int.Parse(input.KeyChar.ToString());
                        // If it isn't between the right numbers, then continue onwards and ask for a new one.
                        if (toReturn >= 0 && toReturn <= width-1)
                        {
                            break;
                        }
                        Console.WriteLine($"That is not a valid move. Please enter a number between 0 and {width-1}: ");
                        input = Console.ReadKey();
                    }
                    else
                    {
                        // It isn't, so it definitely isn't a right move.
                        Console.WriteLine($"That is not a valid move. Please enter a number between 0 and {width-1}: ");
                        input = Console.ReadKey();
                    }
                }
            }
            // Same for the Y coordinate.
            else
            {
                while (true)
                {
                    if (char.IsDigit(input.KeyChar))
                    {
                        toReturn = int.Parse(input.KeyChar.ToString());
                        if (toReturn >= 0 && toReturn <= height-1)
                        {
                            break;
                        }
                        Console.WriteLine($"That is not a valid move. Please enter a number between 0 and {height-1}: ");
                        input = Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"That is not a valid move. Please enter a number between 0 and {height-1}: ");
                        input = Console.ReadKey();
                    }
                }
            }

            return toReturn;
        }
    }
}
