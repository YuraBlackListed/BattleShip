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

        private Player player;
        private Player bot;

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


            player = new Player(maps.enemyCells, false);
            bot = new Player(maps.playerCells, true);

            player.hisTurn = true;
        }
        private void Update()
        {
            Turn();
        }
        private void Render()
        {
            Console.Clear();
            maps.DrawYourField(0, 0);
            maps.DrawEnemyField(20, 0);

        }
        private void CheckInput()
        {
            player.CheckInput();
        }

        private void Turn()
        {
            if(player.hisTurn)
            {
                player.Update();
            }
            else
            {
                bot.Update();
                player.hisTurn = true;
            }
        }

        private void SetResolution(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }
    }
}
