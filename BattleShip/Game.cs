using System;
using System.Threading;

namespace BattleShip
{
    class Game
    {
        bool running = false;

        const int windiwWidth = 50;
        const int windowHeight = 17;

        private Player player1;
        private Player player2;
        private int winnerIndex;

        Round round;

        private int roundCount = 1;

        private bool gameFinished = false;

        private int gameIndex;

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

            round = new Round();
            gameIndex = ReceiveGameMode();
            SetGameMode(gameIndex);
            round.player1 = player1;
            round.player2 = player2;
        }
        private void Update()
        {
            if(roundCount <= 3)
            {
                if (round.SomebodyWon())
                {
                    roundCount = 0;
                    round = new();
                    SetGameMode(gameIndex);
                    round.player1 = player1;
                    round.player2 = player2;
                }
                else
                {
                    round.Turn();
                }
            }
            else
            {
                winnerIndex = CalculateWinner();
                gameFinished = true;
            }
        }
        private void Render()
        {
            if(!player1.IsAI && !player2.IsAI)
            {
                LoadCountdown();
            }
            Console.Clear();
            round.maps.DrawPlayersFields(0, 0, player1, player2);

            round.WritePlayerTurn(player1.hisTurn);
            round.WritePlayerScore();

            if(gameFinished)
            {
                Console.Clear();
                Console.SetCursorPosition(windiwWidth / 2, windowHeight / 2);
                Console.WriteLine($"Player {winnerIndex} won");
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

        private void LoadMenu()
        {
            Console.WriteLine("Type 1 to play PvP");
            Console.WriteLine("Type 2 to play PvAI");
            Console.WriteLine("Type 3 to play AIvAI");
        }
        private int ReceiveGameMode()
        {
            LoadMenu();
            int value;
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out value) && value >= 1 && value <= 3)
                {
                    Console.SetCursorPosition(0, 14);
                    Console.Write("                             ");
                    Console.SetCursorPosition(0, 3);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, 14);
                    Console.Write("Invalid index, try again");
                    Console.SetCursorPosition(0, 3);
                }
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

            player1 = new Player(round.maps.player2Cells, round.maps.player1Cells, firstAI);
            player2 = new Player(round.maps.player1Cells, round.maps.player2Cells, secondAI);

            player1.hisTurn = true;
        }
        private int CalculateWinner()
        {
            if(player1.roundWins >= 3)
            {
                return 1;
            }
            else if(player2.roundWins >= 3)
            {
                return 2;
            }

            return 1;
        }
    }
}
