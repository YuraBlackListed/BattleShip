using System;
using System.Collections.Generic;

namespace BattleShip
{
    class Game
    {
        bool running = false;

        const int windiwWidth = 50;
        const int windowHeight = 17;

        Maps maps = new();

        private Player player1;
        private Player player2;

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


            player1 = new Player(maps.player2Cells, false);
            player2 = new Player(maps.player1Cells, true);

            player1.hisTurn = true;
        }
        private void Update()
        {
            Turn();
        }
        private void Render()
        {
            Console.Clear();
            maps.DrawPlayerField(0, 0);
            maps.DrawEnemyField(20, 0);

        }
        private void CheckInput()
        {
            player1.CheckInput();
        }

        private void Turn()
        {
            if(player1.hisTurn)
            {
                player1.Update();
            }
            else
            {
                player2.Update();
                player1.hisTurn = true;
            }
        }

        private void SetResolution(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }
    }
}
