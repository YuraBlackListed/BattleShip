using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Cell
    {
        public char Character { get; private set; } = ' ';

        public bool IsShip { get; set; } = false;

        public bool IsAttacked { get; private set; } = false;

        public bool OnPlayerSide { get; private set; } = false;

        private const char shipChar = 'O';
        private const char discoveredChar = '~';
        private const char destroyedShipChar = 'X';

        public Cell(char character)
        {
            Character = character;
        }
        public void CreateShip()
        {
            IsShip = true;

            Character = shipChar;
        }
        public void Attack()
        {
            if(IsShip)
            {
                Character = shipChar;
            }
            else
            {
               Character = discoveredChar;
            }
        }
        public void ShowShip()
        {
            if(IsShip)
            {
                Character = shipChar;
            }
        }
    }
}
