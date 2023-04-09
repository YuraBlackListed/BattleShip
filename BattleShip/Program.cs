using System;

namespace BattleShip
{
    class Program
    {
        bool running = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
    }
}
