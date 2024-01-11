using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemon
{
    public partial class FinalSummary : Form
    {
        private int receivedTime;
        public FinalSummary(int time, int totalDamage, bool playerWon)
        {
            InitializeComponent();
            receivedTime = time;
            lblTime.Text = "Time: " + FormantTime(receivedTime);
            lblTotalDamage.Text = $"Total Damage: {totalDamage}";
            if(playerWon)
			{
                lblWinLose.Text = "You Won!";
			}
            else
			{
                lblWinLose.Text = "You Lost!";
			}
        }
        private string FormantTime(int timeInSeconds)
        {
            int minutes = timeInSeconds / 60;
            int seconds = timeInSeconds % 60;
            return $"{minutes} min {seconds} sec";
        }
	}
}
