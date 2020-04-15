using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class RuleTable
    {
        // Member variables
        public List<List<Rule>> rules;      // Each rules[] list contains the winning rules for a single gesture.

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

        // Member methods
        private void AddRule(string strRule)
        {
            Rule rule = new Rule(strRule);
            int index;

            // rules[] list already exists for the gesture.
            if (FindGesture(rule.winGesture, out index))
            {
                rules[index].Add(rule);
            }
            else    // create new rules[] list
            {
                List<Rule> gestureList = new List<Rule>();
                gestureList.Add(rule);
                rules.Add(gestureList);
            }
        }
        // Find the index into rules[] pertaining to the gesture (if it exists).
        public bool FindGesture(string gesture, out int index)
        {
            index = -1;     // illegal index if false is returned.

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
        // Returns false if it is a tie and there is no winner.
        public bool SetAndDisplayWinner(Player player1, Player player2)
        {
            if (player1.gesture == player2.gesture)
            {
                Console.WriteLine("This round ended in a tie.");
                return false;    // Tie - no winner
            }

            // See if player1 gesture won
            if (!DidFirstParameterWin(player1, player2))
            {
                // See if player2 gesture won
                if (!DidFirstParameterWin(player2, player1))
                {
                    return false;   // Illegal input - call it a tie
                }
            }

            return true;
        }
        // Checks if first player parameter beat the second player parameter.
        private bool DidFirstParameterWin(Player player1, Player player2)
        {
            int index;

            // See if player1 gesture beat player2 gesture
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
            return false;
        }
        // Displays all of the rules in the form "<gesture> <action> <gesture>"
        public void DisplayRules()
        {
            Console.WriteLine("\nHere are the rules: ");
            for (int i = 0; i < rules.Count; i++)
            {
                for (int j = 0; j < rules[i].Count; j++)
                    rules[i][j].DisplayRule();
            }
        }
        // Displays list of gestures for number input e.g. "1) Rock"....
        public void DisplayGestures()
        {
            for (int i = 0; i < rules.Count; i++)
                Console.WriteLine(i + ") " + rules[i][0].winGesture);
        }
    }
}
