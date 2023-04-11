using System;
using System.Collections.Generic;

namespace BattleShip
{
    class Program
    {
        bool running = true;

        const int windiwWidth = 40;
        const int windowHeight = 30;

        private List<Ship> ships = new List<Ship>();

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
            Console.WriteLine("Hello World!");
            SetResolution(windiwWidth, windowHeight);
        }
        private void Update()
        {
            
        }
        private void Render()
        {

        }
        private void CheckInput()
        {
            
        }

        private void SetResolution(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }
    }
}
