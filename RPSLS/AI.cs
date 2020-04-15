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
        public override string MakeChoice(RuleTable ruleTable)
        {
            int gesture = randomGenerator.Next(0, ruleTable.ruleTable.Count);

            Console.WriteLine(name + " selected " + ruleTable.ruleTable[gesture][0].winGesture);

            return ruleTable.ruleTable[gesture][0].winGesture;
        }
    }
}
