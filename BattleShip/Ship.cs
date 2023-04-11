using System;

namespace BattleShip
{
    class Ship
    {
        private int? length;
        public int Length
        {
            set
            {
                if (length == null)
                {
                    length = value;
                }
            }
        }

        private char? symbol;
        public char Symbol
        {
            set
            {
                if (symbol == null)
                {
                    symbol = value;
                }
            }
        }

        public int? x;
        public int X
        {
            set
            {
                if (x == null)
                {
                    x = value;
                    SetCoordinates();
                }
            }
        }
        public int? y;
        public int Y
        {
            set
            {
                if (y == null)
                {
                    y = value;
                }
            }
        }

        private int[] coordinates;
        private int hits = 0;

        private void SetCoordinates()
        {
            if (x != null && length != null)
            {
                coordinates = new int[x.Value + length.Value];
            }
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = x.Value + i;
            }
        }

        public int CheckIfHit(int hitX, int hitY)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (hitX == coordinates[i] && hitY == y && coordinates[i] != -1)
                {
                    hits++;
                    coordinates[i] = -1;
                    if (hits == length)
                    {
                        DestroyShip();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            throw new Exception("already hit");
        }
        private void DestroyShip()
        {
            symbol = '*';
        }
    }
}