using System;
using System.Collections.Generic;

namespace BattleShip
{
    class Program
    {
        bool running = true;

        const int windiwWidth = 100;
        const int windowHeight = 30;

        const int boardSize = 10;

        private List<Ship> ships = new List<Ship>();

        char[] alphabet = new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

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
            
        }
        private void Update()
        {
            
        }
        private void Render()
        {
            DrawField();
        }
        private void CheckInput()
        {
            
        }

        private void SetResolution(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }
        private void DrawField()
        {
            for (int i = 0; i < boardSize; i++)
            {
                Console.SetCursorPosition(i + 1, 0);
                Console.Write(alphabet[i]);
                Console.SetCursorPosition(0, i + 1);
                Console.Write(i);
            }

        }
        private void DrawYourField()
        {

        }
        private void DrawEnemyField()
        {

        }
    }
}
