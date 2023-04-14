using System;

namespace BattleShip
{
    class Player
    {
        public bool IsAI { get; private set; } = false;

        private Cell[,] playerCells;
        private Cell[,] enemyCells;

        private bool hitLastTime = false;

        public bool hisTurn = false;

        public Player(Cell[,] yourcells, Cell[,] enemycells, bool isAi)
        {
            playerCells = yourcells;
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
            Console.Write($"Type in {vertexName} coordinate: ");
            Console.SetCursorPosition(21, 15);
            int value = int.Parse(Console.ReadLine());
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
                return;
            }

            if (enemyCells[x, y].IsShip)
            {
                enemyCells[x, y].ShowShip();
            }

            hitLastTime = enemyCells[x, y].IsShip;

            enemyCells[x, y].DestroyCell();
        }
    }
}
