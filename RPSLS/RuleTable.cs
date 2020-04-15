using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class RuleTable
    {
        // Member variables
        public List<List<Rule>> rules;      // Each rules[] list contains the rules for a single gesture.

        // constructor
        public RuleTable()
        {
            rules = new List<List<Rule>>();

            AddRule("Rock crushes Scissors");
            AddRule("Scissors cuts Paper");
            AddRule("Paper covers Rock");
            AddRule("Rock crushes Lizard");
            AddRule("Lizard poisons Spock");
            AddRule("Spock smashes Scissors");
            AddRule("Scissors decapitates Lizard");
            AddRule("Lizard eats Paper");
            AddRule("Paper disproves Spock");
            AddRule("Spock vaporizes Rock");
        }
        private void AddRule(string strRule)
        {
            Rule rule = new Rule(strRule);
            int index;

            if (FindGesture(rule.winGesture, out index))
            {
                rules[index].Add(rule);
            }
            else
            {
                List<Rule> gestureSet = new List<Rule>();
                gestureSet.Add(rule);
                rules.Add(gestureSet);
            }
        }
        public bool FindGesture(string gesture, out int index)
        {
            index = -1;

            for (int i = 0; i < rules.Count; i++)
            {
                if (rules[i][0].winGesture == gesture)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
        public bool SetAndDisplayWinner(Player player1, Player player2)
        {
            if (player1.gesture == player2.gesture)
            {
                Console.WriteLine("This round ended in a tie.");
                return false;    // Tie - no winner
            }

            int index;

            // See if player1 gesture won
            if (FindGesture(player1.gesture, out index))
            {
                for (int i = 0; i < rules[index].Count; i++)
                {
                    if (rules[index][i].loseGesture == player2.gesture)
                    {
                        player1.score++;
                        rules[index][i].DisplayRule();
                        Console.WriteLine("\n" + player1.name + " won this round");
                        return true;
                    }
                }
            }
            // See if player 2 gesture won
            if (FindGesture(player2.gesture, out index))
            {
                for (int i = 0; i < rules[index].Count; i++)
                {
                    if (rules[index][i].loseGesture == player1.gesture)
                    {
                        player2.score++;
                        rules[index][i].DisplayRule();
                        Console.WriteLine("\n" + player2.name + " won this round");
                        return true;
                    }
                }
            }

            return false;   // Illegal input - call it a tie
        }
        public void DisplayRules()
        {
            Console.WriteLine("\nHere are the rules: ");
            for (int i = 0; i < rules.Count; i++)
            {
                for (int j = 0; j < rules[i].Count; j++)
                    rules[i][j].DisplayRule();
            }
        }
        public void DisplayGestures()
        {
            for (int i = 0; i < rules.Count; i++)
                Console.WriteLine(i + ") " + rules[i][0].winGesture);
        }
    }
}
