using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public abstract class Player
    {
        // Member variables
        public string name;

        // constructor
        public Player(string name)
        {
            this.name = name;
        }

        // Member methods
        public abstract string MakeChoice(List<string> choices);

    }
}
