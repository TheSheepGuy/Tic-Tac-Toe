using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Space
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public string State { get; set; }

        public Space(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
            State = " ";
        }
    }
}
