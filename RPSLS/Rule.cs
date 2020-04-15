using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class Rule
    {
        // Member variables
        public string winGesture;           // "Rock", "Paper", "Scissors".....
        public string action;               // "crushes", "cuts", "covers", "poisons".....
        public string loseGesture;          // "Rock", "Paper", "Scissors".....

        // constructor
        public Rule(string winGesture, string action, string loseGesture)
        {
            this.winGesture = winGesture;
            this.action = action;
            this.loseGesture = loseGesture;
        }
        public Rule(string rule)
        { 
            string[] words = rule.Split(' ');

            winGesture = words[0];
            action = words[1];
            loseGesture = words[2];
        }

        // Member methods
        public void DisplayRule()
        {
            Console.WriteLine(winGesture + " " + action + " " + loseGesture);
        }
    }
}
