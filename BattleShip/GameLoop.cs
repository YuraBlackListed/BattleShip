using System;
using System.Threading;

namespace BattleShip
{
    class GameLoop
    {
        bool running = false;

        const int windiwWidth = 50;
        const int windowHeight = 17;

        private Game game;

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

            game = new Game();
        }
        private void Update()
        {
            game.Update();
        }
        private void Render()
        {
            if(!game.player1.IsAI && !game.player2.IsAI)
            {
                LoadCountdown();
            }
            Console.Clear();
            game.round.maps.DrawPlayersFields(0, 0, game.player1, game.player2);

            game.round.WritePlayerTurn(game.player1.hisTurn);
            game.round.WritePlayerScore();

            if(game.Finished)
            {
                Console.Clear();
                Console.SetCursorPosition(windiwWidth / 2, windowHeight / 2);
                Console.WriteLine($"Player {game.winnerIndex} won");
            }
        }
        private void CheckInput()
        {
            //I messed up, I'd better use this
        }

        private void SetResolution(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
        }

        private void LoadCountdown()
        {
            Console.Clear();
            for (int i = 5; i > -1; i--)
            {
                Console.SetCursorPosition(windiwWidth / 2, windowHeight / 2);
                Console.Write(i);
                Thread.Sleep(1000);
            }
        }
    }
}
