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
            // Make the width and height variables, and the variables to check for a win.
            int width, height, winNumber, winner = 0;
            // Declare a player variable which keeps track of whose turn it is.


            Console.WriteLine("\n\n=TIC-TAC-TOE=");

            // Get the width and height of the board.
            width = GetSimpleNumber("Please enter the width of the board: ", "That is not a number. Please enter a natural number.");
            height = GetSimpleNumber("Please enter the height of the board: ", "That is not a number.Please enter a natural number.");
            winNumber = GetSimpleNumber("Please enter the symbols in a row to win: ", "That is not a number.Please enter a natural number.");

            List<string> board = MakeBoard(width, height);
            // Work out what the possible maximum moves are (which is the area).
            int maxMoves = width * height;


            // Continuously loop until there cannot possibly be any moves left.
            for (int currentMoveNumber = 0; currentMoveNumber < maxMoves / 2; currentMoveNumber++)
            {
                Console.WriteLine(DrawBoard(board, width, height));
                MakeMove(board, width, height, 1, player1Symbol);
                if (CheckForWin(board, width, height, winNumber) == true)
                {
                    winner = 1;
                    break;
                }

                Console.WriteLine(DrawBoard(board, width, height));
                MakeMove(board, width, height, 2, player2Symbol);
                if (CheckForWin(board, width, height, winNumber) == true)
                {
                    winner = 2;
                    break;
                }
            }

            // If the board's area is odd, then player 1 will go last, and maxMoves / 2 will have remainder 1. That's why the above for loop won't cover for the last move. Also, the and checks if someone hasn't won already.
            if (maxMoves % 2 == 1 && winner == 0)
            {
                Console.WriteLine(DrawBoard(board, width, height));
                MakeMove(board, width, height, 1, player1Symbol);
                if (CheckForWin(board, width, height, winNumber) == true)
                {
                    winner = 1;
                }
            }

            switch (winner)
            {
                case 1:
                    Console.WriteLine(DrawBoard(board, width, height));
                    Console.WriteLine("Player 1 wins! Press any key to exit.");
                    break;
                case 2:
                    Console.WriteLine(DrawBoard(board, width, height));
                    Console.WriteLine("Player 2 wins! Press any key to exit.");
                    break;
                default:
                    Console.WriteLine(DrawBoard(board, width, height));
                    Console.WriteLine("It's a draw. Press any key to exit.");
                    break;
            }
            Console.ReadKey();
        }

        static int CheckForValidCoordinate(string input, int minNum, int maxNum, string message)
        {
            int toReturn;
            string inputToCheck = input;

            while (true)
            {
                // Hope that what the user entered is actually a number.
                try
                {
                    // Convert the entered string to an int.
                    toReturn = int.Parse(inputToCheck);
                    if (toReturn >= minNum && toReturn <= maxNum)
                    {
                        return toReturn;
                    }
                    else
                    {
                        // It isn't in the correct region, so report to the user that they need to enter the number again.
                        Console.WriteLine($"{message} Please enter a number between {minNum} and {maxNum}: ");
                        // Since this is the end of the loop, it'll go back up to the 'try'.
                        inputToCheck = Console.ReadLine();
                    }

                }
                catch (FormatException)
                {
                    // It isn't, so it definitely isn't a right move.
                    Console.WriteLine($"{message} Please enter a number between {minNum} and {maxNum}: ");
                    // Get the new input to check over. After this, it's reached the end of the while loop, so it'll go back to the top of the 'try'.
                    inputToCheck = Console.ReadLine();
                }
            }
        }

        static bool CheckForWin(List<string> boardToCheck, int width, int height, int winNumber)
        {
            for (int currentSpaceNumber = 0; currentSpaceNumber < boardToCheck.Count; currentSpaceNumber++)
            {
                string currentState = boardToCheck[currentSpaceNumber];

                // If the state is a space, no-one could have won.
                if (currentState == " ")
                {
                    continue;
                }

                // Get the (x,y) coordinate of the current space that is being checked.
                int x = currentSpaceNumber % width,
                    y = currentSpaceNumber / width;

                // Check left-right.
                // All of these methods take the same sort of structure.
                // Check whether a win through horizontal in a row is even possible.
                if ((x + winNumber) <= width)
                {
                    // Check the next spaces up to the winNumber. If it's any longer, then there's no point in continuing to check. Getting 4-in-a-row if you only need 3 doesn't get you extra points.
                    for (int i = 0; i < winNumber; i++)
                    {
                        // If the space that's to the left is the same as the current one, break the loop. If it is, then continue to the next one.
                        if (boardToCheck[x + i] != currentState)
                        {
                            break;
                        }
                        // Once you've reached winNumber, then return true, as you've won.
                        if (i == winNumber - 1)
                        {
                            return true;
                        }
                    }
                }

                // Check up-down. Same structure as above.
                if ((y + winNumber) <= height)
                {
                    for (int i = 1; i < winNumber; i++)
                    {
                        // If the space that's to the left is the same as the current one, break the loop. If it is, then continue to the next one.
                        if (boardToCheck[x + width * (y + i)] != currentState)
                        {
                            break;
                        }
                        // Once you've reached winNumber, then return true, as you've won.
                        if (i == winNumber - 1)
                        {
                            return true;
                        }
                    }
                }

                // Check diagonal up-right.
                // Firstly, check if the selected space can even have winNumber in a row. For example, in Tic-Tac-Toe, only (0,2) can have a diagonal up-right win.
                if ((x + winNumber) <= width && (y + 1 - winNumber) >= 0)
                {
                    // Repeat for the number of necessary spaces you need to have in a row to win (winNumber). Doing more would be useless.
                    for (int i = 1; i < winNumber; i++)
                    {
                        // Check if up and to the right is the same as the current one. If it isn't, then stop checking (as you cannot win).
                        if (boardToCheck[(x + i) + width * (y - i)] != currentState)
                        {
                            break;
                        }
                        // If you've checked them all, return true.
                        if (i == winNumber - 1)
                        {
                            return true;
                        }
                    }
                }

                // Check diagonal down-right. Same algorithm as above, just adjusted to go in another direction.
                if ((x + winNumber) <= width && (y + winNumber) <= height)
                {
                    for (int i = 0; i < winNumber; i++)
                    {
                        if (boardToCheck[(x + i) + width * (y + i)] != currentState)
                        {
                            break;
                        }
                        if (i == winNumber - 1)
                        {
                            return true;
                        }
                    }
                }
            }

            // If nothing's been returned yet, then it must be false.
            return false;
        }

        static string DrawBoard(List<string> boardToDraw, int width, int height)
        {
            StringBuilder toReturn = new StringBuilder("\n+");
            // Add the top border. For Tic-Tac-Toe, this will be "+---+---+---+" (the initial + was added on the line above).
            for (int x = 0; x < width; x++)
            {
                // The x places a coordinate to help visualise the board easier for the user.
                toReturn.Append($"-{x}-+");
            }
            toReturn.Append("\n|");

            for (int y = 0; y < height; y++)
            {
                // This will add "|   |   |   |" etc. for how long the width says to do so (again, the initial | was added above).
                for (int x = 0; x < width; x++)
                {
                    toReturn.Append("   |");
                }
                // The y places a coordinate to help visualise the board easier for the user.
                toReturn.Append($"\n{y}");

                // Now write in whatever the spaces are, e.g. "| X |   | O |".
                for (int x = 0; x < width; x++)
                {
                    // This write the actual state. x+width*y will return whatever is at the current x,y position.
                    toReturn.Append($" {boardToDraw[(x + width * y)]} |");
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
                if (y < height - 1)
                {
                    toReturn.Append("\n|");
                }
                // Otherwise, append a new line control character.
                else
                {
                    toReturn.Append("\n");
                }
            }

            return toReturn.ToString();
        }

        static int GetSimpleNumber(string message, string failMessage)
        {
            int toReturn;
            while (true)
            {
                try
                {
                    Console.Write($"\n{message}");
                    toReturn = int.Parse(Console.ReadLine());
                    if (Math.Sign(toReturn) == 1)
                    {
                        return toReturn;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(failMessage);
                }
            }
        }

        static List<string> MakeBoard(int width, int height)
        {
            List<string> createdBoard = new List<string>();

            // Fill the board with empty spaces.
            for (int i = 0; i < width * height; i++)
            {
                createdBoard.Add(" ");
            }

            return createdBoard;
        }

        static List<string> MakeMove(List<string> board, int width, int height, int currentPlayer, string moveSymbol)
        {
            List<string> newBoard = board;
            // Take the player's move coordinates.
            int moveX, moveY, spaceToPlace;
            // Save user input.
            string rawInput;

            while (true)
            {
                // Get the coordinates.
                Console.WriteLine($"Please enter an x-coordinate, player {currentPlayer}: ");
                rawInput = Console.ReadLine();
                moveX = CheckForValidCoordinate(rawInput, 0, width, "That is not a valid move.");

                Console.WriteLine($"Please enter a y-coordinate, player {currentPlayer}: ");
                rawInput = Console.ReadLine();
                moveY = CheckForValidCoordinate(rawInput, 0, width, "That is not a valid move.");

                //Get the correct index in the board list.
                spaceToPlace = moveX + width * moveY;

                //A try is used in case the user types a coordinate too large.
                try
                {
                    // Check if the space is already occupied.
                    if (newBoard[spaceToPlace] != " ")
                    {
                        Console.WriteLine(DrawBoard(board, width, height));
                        Console.WriteLine("\nThat space is already occupied! You need to choose another.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine(DrawBoard(board, width, height));
                    Console.WriteLine("\nThat coordinate is outside of the board!");
                }
            }
            
            // Change the board to reflect the new move.
            newBoard[spaceToPlace] = moveSymbol;

            return newBoard;
        }

    }
}
