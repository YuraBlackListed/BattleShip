using System;

namespace BattleShip
{
    class Maps
    {
        private const int boardSize = 10;

        public Cell[,] player1Cells = new Cell[boardSize, boardSize];
        public Cell[,] player2Cells = new Cell[boardSize, boardSize];

        public void Start()
        {
            GenerateField(player1Cells);
            GenerateField(player2Cells);

            GenerateShips(player1Cells);
            GenerateShips(player2Cells);
            RevielShips(player1Cells);
        }

        public void DrawPlayersFields(int x, int y, Player player1, Player player2)
        {
            if(player1.hisTurn)
            {
                HideShips(player2.playerCells);
                RevielShips(player1.playerCells);
            }
            else
            {
                HideShips(player1.playerCells);
                RevielShips(player2.playerCells);
            }

            DrawFieldNums(x, y);
            DrawFieldNums(x + 20, y);
            DrawCells(x, y, player1.playerCells);
            DrawCells(x + 20, y, player2.playerCells);
        }

        private void DrawFieldNums(int x, int y)
        {
            for (int i = 0; i < boardSize; i++)
            {
                Console.SetCursorPosition(x + i + 1, y);
                Console.Write(i) ;
                Console.SetCursorPosition(x, y + i + 1);
                Console.Write(i);
            }

        }
        private void GenerateField(Cell[,] cells)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    cells[j, i] = new Cell('~');
                }
            }
        }
        public void GenerateShips(Cell[,] cells)
        {
            Random random = new();
            for (int i = 0; i < 7; i++)
            {
                int x = random.Next(0, boardSize);
                int y = random.Next(0, boardSize);
                cells[x, y].IsShip = true;
            }
        }
        private void RevielShips(Cell[,] cells)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if(cells[i, j] != null)
                    {
                        cells[i, j].ShowShip();
                    }
                }
            }
        }
        private void HideShips(Cell[,] cells)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (cells[i, j] != null)
                    {
                        cells[i, j].HideShip();
                    }
                }
            }
        }
        private void DrawCells(int x, int y, Cell[,] cells)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.SetCursorPosition(x + i + 1, y + j + 1);
                    Console.Write(cells[i,j].Character);
                }
            }
        }
    }
}
