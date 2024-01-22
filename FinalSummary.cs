using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemon
{
    public partial class FinalSummary : Form
    {
        string outcome;
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
                outcome = "Victory!";
			}
            else
			{
                lblWinLose.Text = "You Lost!";
                outcome = "Defeat!";
			}
        }
        private string FormantTime(int timeInSeconds)
        {
            int minutes = timeInSeconds / 60;
            int seconds = timeInSeconds % 60;
            return $"{minutes} min {seconds} sec";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string fileName = "GameResults.txt";
            string filePath = Path.Combine("pokemon", fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("The results of the last game: ");
                    writer.WriteLine("");
                    writer.WriteLine("Outcome: " + outcome);
                    writer.WriteLine("Time: " + FormantTime(receivedTime));
                    writer.WriteLine(lblTotalDamage.Text);
                }
                lblTextSaved.Visible = true;
            }
            catch(Exception ex)
            {
                lblTextNotSaved.Visible = true;
                lblErrorText.Text = ex.Message;
                lblErrorText.Visible = true;
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
