using System;

namespace RPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSimulation RPSLS = new GameSimulation();

            do
            {
                Console.Clear();

                RPSLS.RunGame();

                Console.WriteLine("\nWould you like to play again? (Y/N)");
                if (Console.ReadLine() != "Y")
                    break;
            }
            while (true);
        }
    }
}
