using System;
using System.Collections.Generic;

namespace BattleShip
{
    class Game
    {
        bool running = false;

        const int windiwWidth = 50;
        const int windowHeight = 15;

        Maps maps = new();



        public void Run()
        {
            Start();
            while(running)
            {
                Render();
                CheckInput();
                Update();
            }
        }

        private void Start()
        {
            running = true;
            Console.CursorVisible = false;
            SetResolution(windiwWidth, windowHeight);
            maps.Start();
        }
        private void Update()
        {
            
        }
        private void Render()
        {
            Console.Clear();
            maps.DrawYourField(0, 0);
            maps.DrawEnemyField(20, 0);

        }
        private void CheckInput()
        {
            ReadCoordinate('x');
            ReadCoordinate('y');
        }
        private int ReadCoordinate(char vertexName)
        {
            Console.SetCursorPosition(0, windowHeight - 4);
            Console.Write($"Type in {vertexName} coordinate: ");
            int value = int.Parse(Console.ReadLine());
            return value;
        }
        private void SetResolution(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }
    }
}
