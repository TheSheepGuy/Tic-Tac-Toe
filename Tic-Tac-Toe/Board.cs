using System;
using System.Collections.Generic;
using System.Linq;

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
            //Loop through all rows (Y-coordinates).
            for (int rowCheck = 0; rowCheck < Width; rowCheck++)
            {
                List<Space> currentRow = new List<Space>();
                //Look through all spacesToCheck where the Y-coordinate is the same. We're looking for the ones at y = rowCheck. Add the found ones to a list called 'currentRow'.
                currentRow = spacesToCheck.Where(foundRow => foundRow.YCoordinate.Equals(rowCheck)).ToList();
                for (int xCoords = 0; xCoords < currentRow.Count; xCoords++)
                {
                    List<string> states = new List<string>();
                    //Add all of the states to the list of strings 'states' by looping through them all using their X-coordinate.
                    states.Add((currentRow.Find(result => result.XCoordinate == xCoords)).State);
                    //Check if all of the states are the same.
                    if (states.Distinct().Skip(1).Any())
                    {
                        //If the spaces are empty, then no-one has won.
                        if (states[0] == " ")
                            return 0;
                        //If the spaces are X, then player 1 has won.
                        else if (states[0] == "X")
                        {
                            return 1;
                        }
                        //If they're O, then player 2 has won.
                        else if (states[0] == "0")
                        {
                            return 2;
                        }

                    }
                }
            }
            //Finally, if all else fails, then there's no win.
            return 0;
        }
    }
}
