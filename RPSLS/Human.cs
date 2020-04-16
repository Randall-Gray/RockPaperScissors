using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class Human : Player
    {
        // Member variables

        // constructor
        public Human(string name) : base(name)
        {

        }

        // Member method
        public override void ChooseGesture(RuleTable ruleTable)
        {
            bool validInput;
            int numGesture;

            Console.Clear();            // Don't want to see previous human player choice (if there was one).
            do
            {
                Console.WriteLine("\n" + name + " select a gesture: ");
                ruleTable.DisplayGestures();
                // Add selection to redisplay the game rules.
                Console.WriteLine(ruleTable.rules.Count + ") (**Display game rules**)");
                // protect against non-number input
                validInput = int.TryParse(Console.ReadLine(), out numGesture);
                if (!validInput)
                    continue;
                
                // Display game rules.
                if (numGesture == ruleTable.rules.Count)
                {
                    Console.Clear();
                    ruleTable.DisplayRules();
                }
            }
            while (!validInput || numGesture < 0 || numGesture > ruleTable.rules.Count - 1);

            gesture = ruleTable.rules[numGesture][0].winGesture;

            Console.WriteLine(name + " selected " + gesture);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
