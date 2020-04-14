using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class RuleSet
    {
        // Member variables
        public string gesture;                 // "Rock", "Scissors", "Paper"....
        public List<Rule> rules;               // All rules pertaining to gesture.

        // constructor
        public RuleSet(string gesture)
        {
            this.gesture = gesture;
            rules = new List<Rule>();
        }

        // Member methods
        public void AddRule(Rule rule)
        {
            if (rule.winGesture == gesture)
                rules.Add(rule);
        }
    }
}
