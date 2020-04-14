using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class RuleTable
    {
        // Member variables
        public List<RuleSet> Rules;             // Each RuleSet contains the rules for a single gesture.

        // constructor
        public RuleTable()
        {
            Rules = new List<RuleSet>();

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
        public void AddRule(string strRule)
        {
            Rule rule = new Rule(strRule);
            int index;

            if (FindRuleSet(rule.winGesture, out index))
            {
                Rules[index].AddRule(rule);
            }
            else
            {
                RuleSet ruleSet = new RuleSet(rule.winGesture);
                ruleSet.AddRule(rule);
                Rules.Add(ruleSet);
            }
        }
        public bool FindRuleSet(string gesture, out int index)
        {
            index = -1;

            for (int i = 0; i < Rules.Count; i++)
            {
                if (Rules[i].gesture == gesture)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
        public int Winner(string choice1, string choice2)
        {
            return 1;
        }
        public void DisplayRules()
        {
            Console.WriteLine("\nHere are the rules: ");
            for (int i = 0; i < Rules.Count; i++)
            {
                for (int j = 0; j < Rules[i].rules.Count; j++)
                    Console.WriteLine(Rules[i].rules[j].winGesture + " " + Rules[i].rules[j].action + " " + Rules[i].rules[j].loseGesture);
            }
        }
        public void DisplayGestures()
        {
            for (int i = 0; i < Rules.Count; i++)
                Console.WriteLine(i + ") " + Rules[i].gesture);
        }


    }
}
