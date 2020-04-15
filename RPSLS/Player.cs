using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public abstract class Player
    {
        // Member variables
        public string name;
        public int score;
        public string gesture;

        // constructor
        public Player(string name)
        {
            this.name = name;
            score = 0;
            gesture = "";
        }

        // Member methods
        public abstract void ChooseGesture(RuleTable ruleTable);

    }
}
