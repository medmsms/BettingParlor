using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheBettingParlor
{
    
    public partial class Form1 : Form
    {

        Random MyRandomizer = new Random();
        GreyHound[] GreyHoundArray = new GreyHound[4];
        Guy[] GuysArray = new Guy[3];


        public Form1()
        {
            InitializeComponent();
            
            GreyHoundArray[0] = new GreyHound
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox1.Width,
                Randomizer = MyRandomizer

            };
            GreyHoundArray[1] = new GreyHound
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox2.Width,
                Randomizer = MyRandomizer

            };
            GreyHoundArray[2] = new GreyHound
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox3.Width,
                Randomizer = MyRandomizer

            };
            GreyHoundArray[3] = new GreyHound
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox4.Width,
                Randomizer = MyRandomizer

            };

            GuysArray[0] = new Guy
            {
                Name = "Joe",
                MyBet = new Bet(),
                Cash = 100,
                MyLabel = joeBetLabel,
                MyRadioButton = joeRadioButton
            };
            GuysArray[0].MyBet = null;
            GuysArray[0].UpdateLabels();
            GuysArray[1] = new Guy
            {
                Name = "Bob",
                MyBet = new Bet(),
                Cash = 100,
                MyLabel = bobBetLabel,
                MyRadioButton = bobRadioButton
            };
            GuysArray[1].MyBet = null;
            GuysArray[1].UpdateLabels();
            GuysArray[2] = new Guy
            {
                Name = "Al",
                MyBet = new Bet(),
                Cash = 100,
                MyLabel = alBetLabel,
                MyRadioButton = alRadioButton
            };
            GuysArray[2].MyBet = null;
            GuysArray[2].UpdateLabels();


            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked == true)
                GuysArray[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            else if(bobRadioButton.Checked == true)
                GuysArray[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            else if(alRadioButton.Checked == true)
                GuysArray[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GreyHoundArray[i].Run())
                {
                    timer1.Stop();
                    int k = i + 1;
                    MessageBox.Show("Dog #"+k+" has won the race");
                    for (int j = 0; j < 3; j++)
                    {
                        GuysArray[j].Collect(i + 1);
                        GuysArray[j].UpdateLabels();
                    }                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                GreyHoundArray[i].TakeStartingPosition();
                timer1.Start();

        }

       
    }
}
