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
        public override string MakeChoice(List<string> choices)
        {
            return "Rock";
        }

    }
}
