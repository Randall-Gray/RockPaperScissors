﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class GameSimulation
    {
        // Member variables
        public RuleTable Rules;
        public List<string> Choices;

        public Player player1;
        public Player player2;

        // constructor
        public GameSimulation()
        {
            Rules = new RuleTable();
            InitializeChoices();

        }
        public void InitializeChoices()
        {
            Choices = new List<string>();

            for (int i = 0; i < Rules.Rules.Count; i++)
                Choices.Add(Rules.Rules[i].gesture);
        }
        public void BeginGame()
        {
            int player1Wins = 0;
            int player2Wins = 0;
            string player1Gesture;
            string player2Gesture;

            int rounds;

            Console.WriteLine("Let's play \"Rock, Paper, Scissors, Lizard, Spock \"");
            Rules.DisplayRules();
            ChoosePlayers();
            rounds = ChooseRounds();

            while (player1Wins < rounds/2+1 && player2Wins < rounds/2+1)
            {
                player1Gesture = player1.MakeChoice(Choices);
                player2Gesture = player2.MakeChoice(Choices);
                if (Rules.Winner(player1Gesture, player2Gesture) == 1)
                    player1Wins++;
                else
                    player2Wins++;
            }
        }
        public void ChoosePlayers()
        {
            Console.WriteLine("\nHow do you want to play?");
            Console.WriteLine("1) Human vs AI");
            Console.WriteLine("2) Human vs Human");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter player1 name: ");
            player1 = new Human(Console.ReadLine());

            if (choice == 1)
            {
                player2 = new AI("Computer");
            }
            else
            {
                Console.WriteLine("Enter player2 name: ");
                player2 = new Human(Console.ReadLine());
            }
            Console.WriteLine("\nPlayer1 is: " + player1.name);
            Console.WriteLine("Player2 is: " + player2.name);
        }
        public int ChooseRounds()
        {
            Console.WriteLine("Enter number of rounds to play: ");
            int rounds = int.Parse(Console.ReadLine());
            
            Console.WriteLine("\nThe game will consist of the best of " + rounds + " rounds (" + (rounds/2+1) + " WINS).");
            
            return rounds;
        }
        public void DisplayRules()
        {
            Rules.DisplayRules();
        }
        public void DisplayGestures()
        {
            Rules.DisplayGestures();
        }
    
    
    }
}
