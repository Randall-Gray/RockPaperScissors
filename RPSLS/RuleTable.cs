using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class RuleTable
    {
        // Member variables
        public List<List<Rule>> ruleTable;      // Each ruleTable[] list contains the rules for a single gesture.

        // constructor
        public RuleTable()
        {
            ruleTable = new List<List<Rule>>();

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
                ruleTable[index].Add(rule);
            }
            else
            {
                List<Rule> gestureSet = new List<Rule>();
                gestureSet.Add(rule);
                ruleTable.Add(gestureSet);
            }
        }
        public bool FindGesture(string gesture, out int index)
        {
            index = -1;

            for (int i = 0; i < ruleTable.Count; i++)
            {
                if (ruleTable[i][0].winGesture == gesture)
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
            for (int i = 0; i < ruleTable.Count; i++)
            {
                for (int j = 0; j < ruleTable[i].Count; j++)
                    ruleTable[i][j].DisplayRule();
            }
        }
        public void DisplayGestures()
        {
            for (int i = 0; i < ruleTable.Count; i++)
                Console.WriteLine(i + ") " + ruleTable[i][0].winGesture);
        }


    }
}
