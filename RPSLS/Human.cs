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
            int numGesture;

            Console.Clear();
            do
            {
                Console.WriteLine("\n" + name + " select a gesture: ");
                ruleTable.DisplayGestures();

                numGesture = int.Parse(Console.ReadLine());
            }
            while (numGesture < 0 || numGesture > ruleTable.rules.Count - 1);

            gesture = ruleTable.rules[numGesture][0].winGesture;

            Console.WriteLine(name + " selected " + gesture);
        }

    }
}
