using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBettingParlor
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription() {
            if (Amount > 0)
                return Bettor.Name + " has bet " + Amount + " on dog #" + Dog;
            else
                return Bettor.Name + " hasn't placed a bet";
        }

        public int PayOut(int Winner) {
            if (Winner == Dog)
            {
                return Amount*2;
            }
            else
                return -Amount;

        }
    }
}
