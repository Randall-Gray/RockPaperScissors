using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class GameSimulation
    {
        // Member variables
        RuleTable ruleTable;

        Player player1;
        Player player2;

        int winsForVictory;     // based on number of rounds entered by players
        int numRounds;          // total rounds played in game including ties
        int numTies;            // number of tied rounds.

        // constructor
        public GameSimulation()
        {
            ruleTable = new RuleTable();
        }

        // Member methods
        public void RunGame()
        {
            Console.Clear();
            Console.WriteLine("Let's play \"Rock, Paper, Scissors, Lizard, Spock \"");
            ruleTable.DisplayRules();
            ChooseAndInitializePlayers();
            SetWinCondition();

            Console.WriteLine("\nPress <Enter> to begin!");
            Console.ReadLine();

            numRounds = 0;
            numTies = 0;

            while (player1.score < winsForVictory && player2.score < winsForVictory)
            {
                numRounds++;

                player1.ChooseGesture(ruleTable);
                player2.ChooseGesture(ruleTable);
                DisplayAndSetRoundResult();
            }
            DisplayGameOutcome();
        }
        private void ChooseAndInitializePlayers()
        {
            string choice;

            do
            {
                Console.WriteLine("\nHow do you want to play?");
                Console.WriteLine("1) Human vs AI");
                Console.WriteLine("2) Human vs Human");
                Console.WriteLine("3) AI vs AI");
                choice = Console.ReadLine();
            }
            while (choice != "1" && choice != "2" && choice != "3");

            // Make player1
            if (choice == "3")
            {
                player1 = new AI("Computer1");
            }
            else
            { 
                Console.WriteLine("\nEnter player1 name: ");
                player1 = new Human(Console.ReadLine());
            }
            // Make player2
            if (choice == "2")
            {
                Console.WriteLine("\nEnter player2 name: ");
                player2 = new Human(Console.ReadLine());
            }
            else
            {
                player2 = new AI("Computer2");
            }
            Console.WriteLine("\nPlayer1 is: " + player1.name);
            Console.WriteLine("Player2 is: " + player2.name);
        }
        // Ask players how many rounds to play "best of"
        private void SetWinCondition()
        {
            bool validInput;
            int rounds;

            do
            {
                Console.WriteLine("\nEnter odd number of rounds to play: ");    // Don't want to deal with tied games.
                // protect against non-number input
                validInput = int.TryParse(Console.ReadLine(), out rounds);
            }
            while (!validInput || rounds % 2 == 0);

            winsForVictory = rounds / 2 + 1;
            Console.WriteLine("\nThe game will consist of the best of " + rounds + " rounds (" + winsForVictory + " WINS).");
            Console.WriteLine("Ties do not count.");
        }
        private void DisplayAndSetRoundResult()
        {
            Console.Clear();
            Console.WriteLine("Round: " + numRounds);
            Console.WriteLine(player1.name + " chose: " + player1.gesture + "\t" + player2.name + " chose: " + player2.gesture + "\n");

            if (!ruleTable.SetAndDisplayWinner(player1, player2))
                numTies++;

            // display running score so far
            Console.WriteLine("\nScore: " + player1.name + " - " + player1.score + "\t" + player2.name + " - " + player2.score);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        // Display end of game results.
        private void DisplayGameOutcome()
        {
            Console.Clear();
            if (player1.score > player2.score)
                Console.WriteLine("\n" + player1.name.ToUpper() + " WINS!\n");
            else
                Console.WriteLine("\n" + player2.name.ToUpper() + " WINS!\n");

            Console.WriteLine("Rounds: " + numRounds);
            Console.WriteLine(player1.name + " rounds won: " + player1.score + "\t" + player2.name + " rounds won: " + player2.score);
            Console.WriteLine("Number of ties: " + numTies);
        }
    }
}
