using System;

namespace BattleShip
{
    class Round
    {
        public Maps maps;

        public Player player1;
        public Player player2;

        private int shipsCount;

        public Round(int _shipsCount)
        {
            shipsCount = _shipsCount;
            maps = new Maps(shipsCount);
            maps.Start(); 
        }

        public void RecreateMaps()
        {
            maps.Start();
        }

        public void Turn()
        {
            Player currentPlayer = CalculateCurrentPlayer();
            currentPlayer.Update();
            currentPlayer.hisTurn = false;
        }

        private Player CalculateCurrentPlayer()
        {
            if(player1.hisTurn)
            {
                player2.hisTurn = true;
                return player1;
            }
            else if(player2.hisTurn)
            {
                player1.hisTurn = true;
                return player2;
            }
            return player2;
        }

        public void WritePlayerTurn(bool player1turn)
        {
            Console.SetCursorPosition(11, 13);
            Console.Write("Current turn:");
            if (player1turn)
            {
                Console.Write("Player 1");
            }
            else
            {
                Console.Write("Player 2");
            }
        }

        public void WritePlayerScore()
        {
            Console.SetCursorPosition(20, 11);
            Console.Write($"Player 1 score: {player1.score}");

            Console.SetCursorPosition(20, 12);
            Console.Write($"Player 2 score: {player2.score}");
            
        }
        public bool SomebodyWon()
        {
            if(player1.score >= shipsCount)
            {
                player1.Won();
                return true;
            }
            else if(player2.score >= shipsCount)
            {
                player2.Won();
                return true;
            }
            return false;
        }
    }
}
