using System;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLoop gameLoop = new();
            gameLoop.Run();
        }
    }
}
