using System;

namespace BattleShip
{
    class Cell
    {
        public char Character { get; private set; } = ' ';

        public bool IsShip { get; set; } = false;

        public bool IsAttacked { get; private set; } = false;
        public bool IsBombed { get; private set; } = false;

        public bool OnPlayerSide { get; private set; } = false;

        private const char shipChar = '^';
        private const char defaultChar = '~';
        private const char destroyedChar = '+';
        private const char destroyedShipChar = 'x';

        public Cell(char character)
        {
            Character = character;
        }
        public void CreateShip()
        {
            IsShip = true;

            Character = shipChar;
        }

        public void DestroyCell()
        {
            if (IsShip)
            {
                Character = destroyedShipChar;

                IsShip = false;
            }
            else Character = destroyedChar;

            IsBombed = true;
        }
        public void ShowShip()
        {
            if(IsShip)
            {
                Character = shipChar;
            }
        }
        public void HideShip()
        {
            if(Character != destroyedChar && Character != destroyedShipChar)
            {
                Character = defaultChar;
            }
            
        }
    }
}
