using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===TIC-TAC-TOE===");
            // Create the game board.
            var gameBoard = new Board(3, 3);
            // Keep track of the game's state, whether it has ended yet,
            bool end = false;
            // Record what player won. 0 is no-one yet, 1 player 1, 2 player 2, 3 a draw.
            int playerWin = 0;
            int currentPlayer = 1;
            // A variable just to hold temporary user input, initially empty.
            var input = new ConsoleKeyInfo();

            while(end == false)
            {
                for (int i = 1; i < 3; i++)
                {
                    gameBoard.DrawBoard();
                    Console.WriteLine($"\nPlease enter the x-coordinate of your move, Player {i}");
                    input = Console.ReadKey();
                    int x = int.Parse(input.KeyChar.ToString());
                    Console.WriteLine($"\nPlease enter the y-coordinate");
                    input = Console.ReadKey();
                    int y = int.Parse(input.KeyChar.ToString());
                    gameBoard.MakeMove(x, y, i);
                }
            }
        }
    }
}
