using System;

namespace RPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSimulation RPSLS = new GameSimulation();        // Rock, Paper, Scissors, Lizard, Spock

            do
            {
                Console.Clear();

                RPSLS.RunGame();

                Console.WriteLine("\nWould you like to play again? (Y/N)");
                if (Console.ReadLine().ToUpper() != "Y")
                    break;
            }
            while (true);
        }
    }
}
