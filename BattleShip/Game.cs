using System;
using System.Threading;

namespace BattleShip
{
    class Game
    {
        bool running = false;

        const int windiwWidth = 50;
        const int windowHeight = 17;

        private Maps maps = new();

        private Player player1;
        private Player player2;

        private Player winner;

        private int round = 1;

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

            SetGameMode(GetGameMode());
        }
        private void Update()
        {
            if(round <= 3)
            {
                Turn();
            }
            else
            {
                
            }
        }
        private void Render()
        {
            if(!player1.IsAI && !player2.IsAI)
            {
                LoadCountdown();
            }
            Console.Clear();
            maps.DrawPlayersFields(0, 0, player1, player2);
        }
        private void CheckInput()
        {
            
        }

        private void Turn()
        {
            if(player1.hisTurn)
            {
                player1.Update();
                
                player2.hisTurn = true;
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

        private void LoadMenu()
        {
            Console.WriteLine("Type 1 to play PvP");
            Console.WriteLine("Type 2 to play PvAI");
            Console.WriteLine("Type 3 to play AIvAI");
        }
        private int GetGameMode()
        {
            LoadMenu();
            string id = Console.ReadLine();

            int value = 0;

            if (int.TryParse(id, out value) && value >= 1 && value <= 3)
            {
                Console.SetCursorPosition(0, 14);
                Console.Write("                             ");
                Console.SetCursorPosition(0, 0);
            }
            else
            {
                Console.SetCursorPosition(0, 14);
                Console.Write("Invalid coordinate, try again");
                Console.SetCursorPosition(0, 0);

                value = GetGameMode();
            }
            return value;
        }
        private void SetGameMode(int value)
        {
            (bool firstAI, bool secondAI) = value switch
            {
                1 =>(false, false),
                2 =>(false, true),
                3 =>(true, true),
            };

            player1 = new Player(maps.player2Cells, maps.player1Cells, firstAI);
            player2 = new Player(maps.player1Cells, maps.player2Cells, secondAI);

            player1.hisTurn = true;
        }
    }
}
