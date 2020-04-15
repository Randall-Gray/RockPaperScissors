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
        public override string MakeChoice(RuleTable ruleTable)
        {
            Console.Clear();
            Console.WriteLine(name + " select a gesture: \n");
            ruleTable.DisplayGestures();

            int gesture = int.Parse(Console.ReadLine());

            Console.WriteLine(name + " selected " + ruleTable.ruleTable[gesture][0].winGesture);

            return ruleTable.ruleTable[gesture][0].winGesture;
        }

    }
}
