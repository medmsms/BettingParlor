using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheBettingParlor
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;

        public Label MyLabel;

        public void UpdateLabels() {
            if (MyBet != null)
            {
                MyLabel.Text = Name+" bets " + MyBet.Amount + " on dog #" + MyBet.Dog;
                
            }
            else
                MyLabel.Text = Name + " hasn't place a bet";
            MyRadioButton.Text = Name+" has " + Cash;
       
        }

        public bool PlaceBet(int BetAmount, int DogToWin) {

            if (Cash >= BetAmount)
            {
                MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };
                UpdateLabels();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearBet() {
            MyBet.Amount = 0;
        }

        public void Collect(int Winner) {
            int winnings= MyBet.PayOut(Winner);
            Cash += winnings;
            UpdateLabels();
            ClearBet();
        }
    }
}
