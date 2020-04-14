using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class AI : Player
    {
        // Member variables

        // constructor
        public AI(string name) : base(name)
        {

        }

        // Member method
        public override string MakeChoice(List<string> choices)
        {
            return "Rock";
        }
    }
}
