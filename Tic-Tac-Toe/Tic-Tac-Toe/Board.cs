using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Board
    {
        public int Width { get; }
        public int Height { get; }
        public List<Space> Spaces { get; set; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Spaces = new List<Space>();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Spaces.Add(new Space(i, j));
                }
            }
        }

        public void DrawBoard()
        {
            Console.WriteLine();
            for (int i = Height-1; i >= 0; i--)
            {
                Console.Write("\n+---+---+---+");
                Console.Write("\n|   |   |   |");
                Console.Write($"\n{i}");
                for (int j = 0; j < Width; j++)
                {
                    //The "find" expression finds the space at the current X and Y position.
                    Console.Write($" {(Spaces.Find(a => a.XCoordinate == j && a.YCoordinate == i)).State} |");
                }
                Console.Write("\n|   |   |   |");
            }
            Console.Write("\n+-0-+-1-+-2-+");
        }

        public void MakeMove(int x, int y, int player)
        {
            var spaceState = Spaces.Find(a => a.XCoordinate == x && a.YCoordinate == y);
            if (player == 1)
            {
                spaceState.State = "X";
            }
            else
            {
                spaceState.State = "O";
            }
            
        }

        public int CheckWin(List<Space> spacesToCheck)
        {

            return 0;
        }
    }
}
