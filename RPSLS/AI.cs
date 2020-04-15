using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class AI : Player
    {
        // Member variables
        Random randomGenerator;         // Selects the AI player gesture.

        // constructor
        public AI(string name) : base(name)
        {
            randomGenerator = new Random();
        }

        // Member method
        public override void ChooseGesture(RuleTable ruleTable)
        {
            int numGesture = randomGenerator.Next(0, ruleTable.rules.Count);

            Console.Clear();

            gesture = ruleTable.rules[numGesture][0].winGesture;

            Console.WriteLine(name + " selected " + gesture);
        }
    }
}
