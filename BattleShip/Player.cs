using System;
using System.Threading;

namespace BattleShip
{
    class Player
    {
        public bool IsAI { get; private set; } = false;

        public Cell[,] playerCells;
        private Cell[,] enemyCells;

        private bool hitLastTime = false;

        public bool hisTurn = false;

        public Player(Cell[,] enemycells, Cell[,] playercells, bool isAi)
        {
            playerCells = playercells;
            enemyCells = enemycells;
            IsAI = isAi;
        }
        (int, int) lastCoords;

        Random ramndom = new();

        public void CheckInput()
        {
            if(!IsAI && hisTurn)
            {
                lastCoords = ((int)ReadCoordinate('x'), (int)ReadCoordinate('y'));
            }
        }
        public void Update()
        {
            Shoot();
            if(!hitLastTime)
            {
                hisTurn = false;
            }
        }
        
        private int ReadCoordinate(char vertexName)
        {
            Console.SetCursorPosition(0, 15);
            Console.Write($"Type in {vertexName} coordinate:      ");
            Console.SetCursorPosition(21, 15);

            int value = 0;
            string strValue = Console.ReadLine();

            if (int.TryParse(strValue, out value) && value >= 0 && value <= 9)
            {
                Console.SetCursorPosition(0, 14);
                Console.Write("                             ");

                return value;
            }
            else
            {
                Console.SetCursorPosition(0, 14);
                Console.Write("Invalid coordinate, try again");

                value = ReadCoordinate(vertexName);
            }
            return value;
        }

        private void Shoot()
        {
            if(!IsAI)
            {
                PlayerShoot();
            }
            else
            {
                BotShoot();
            }
        }
        private void PlayerShoot()
        {
            int x = lastCoords.Item1;
            int y = lastCoords.Item2;

            if (enemyCells[x, y].IsBombed)
            {
                return;
            }

            if (enemyCells[x, y].IsShip)
            {
                enemyCells[x, y].ShowShip();
            }

            hitLastTime = enemyCells[x, y].IsShip;

            enemyCells[x, y].DestroyCell();
        }
        private void BotShoot()
        {
            int x = ramndom.Next(0, enemyCells.Length / 10);
            int y = ramndom.Next(0, enemyCells.Length / 10);

            if (enemyCells[x, y].IsBombed)
            {
                BotShoot();
            }

            if (enemyCells[x, y].IsShip)
            {
                enemyCells[x, y].ShowShip();
            }

            hitLastTime = enemyCells[x, y].IsShip;

            enemyCells[x, y].DestroyCell();

            Thread.Sleep(1500);
        }
    }
}
