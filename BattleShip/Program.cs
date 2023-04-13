using System;
using System.Collections.Generic;

namespace BattleShip
{
    class Program
    {
        bool running = true;

        const int windiwWidth = 50;
        const int windowHeight = 15;

        const int boardSize = 10;

        private List<Ship> ships = new List<Ship>();

        private char[] alphabet = new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };
        private char seaChar = '~';

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        private void Run()
        {
            Start();
            while(running)
            {
                CheckInput();
                Update();
                Render();
            }
        }

        private void Start()
        {
            SetResolution(windiwWidth, windowHeight);
            Console.CursorVisible = false;
        }
        private void Update()
        {
            
        }
        private void Render()
        {
            DrawYourField(0, 0);
            DrawEnemyField(20, 0);

        }
        private void CheckInput()
        {
            
        }

        private void SetResolution(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }
        private void DrawFieldNums(int x, int y)
        {
            for (int i = 0; i < boardSize; i++)
            {
                Console.SetCursorPosition(x + i + 1, y);
                Console.Write(alphabet[i]);
                Console.SetCursorPosition(x, y + i + 1);
                Console.Write(i);
            }

        }
        private void DrawSea(int x, int y)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.SetCursorPosition(x + i + 1, y + j + 1);
                    Console.Write(seaChar);
                }
            }
        }
        private void DrawYourField(int x, int y)
        {
            DrawFieldNums(x, y);
            DrawSea(x, y);
        }
        private void DrawEnemyField(int x, int y)
        {
            DrawFieldNums(x, y);
            DrawSea(x, y);
        }

    }
}
