using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class GameSimulation
    {
        // Member variables
        public RuleTable ruleTable;

        public Player player1;
        public Player player2;

        int winsForVictory;
        int numRounds;
        int numTies;

        // constructor
        public GameSimulation()
        {
            ruleTable = new RuleTable();
        }
        public void RunGame()
        {
            int roundResult;

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
                player1.ChooseGesture(ruleTable);
                player2.ChooseGesture(ruleTable);
                roundResult = ruleTable.SetWinner(player1, player2);
                DisplayAndSetRoundResult(roundResult);
            }
            DisplayGameOutcome();
        }
        public void ChooseAndInitializePlayers()
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
        public void SetWinCondition()
        {
            int rounds;

            do
            {
                Console.WriteLine("\nEnter odd number of rounds to play: ");    // Don't want to deal with ties.
                rounds = int.Parse(Console.ReadLine());
            }
            while (rounds % 2 == 0);

            winsForVictory = rounds / 2 + 1;
            Console.WriteLine("\nThe game will consist of the best of " + rounds + " rounds (" + winsForVictory + " WINS).");
            Console.WriteLine("Ties do not count.");
        }
        public void DisplayAndSetRoundResult(int result)
        {
            Console.WriteLine("\nPlayer1 chose: " + player1.gesture + "\tPlayer2 chose: " + player2.gesture);

            switch (result)
            {
                case 0:
                    numTies++;
                    Console.WriteLine("This round ended in a tie.");
                    break;
                case 1:
                    Console.WriteLine("Player 1 " + player1.name + " won this round");
                    break;
                case 2:
                    Console.WriteLine("Player 2 " + player2.name + " won this round");
                    break;
                default:
                    break;
            }
        }
        public void DisplayGameOutcome()
        {
            Console.WriteLine("Rounds: " + numRounds);
            Console.WriteLine("Player1 wins: " + player1.score + "\tPlayer2 wins: " + player2.score);
            Console.WriteLine("Number of ties: " + numTies);

            if (player1.score > player2.score)
                Console.WriteLine("\n PLAYER 1 " + player1.name.ToUpper() + " WINS!");
            else
                Console.WriteLine("\n PLAYER 2 " + player2.name.ToUpper() + " WINS!");
        }
    }
}
