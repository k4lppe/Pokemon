using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pokemon
{
    public partial class Battle : Form
    {
        private List<Pokemon> selectedPokemons;
        private List<Pokemon> enemyPokemons;
        private string selectedPokemonImageFileName;
        Random enemyRandom = new Random();
        private int enemyRandomIndex;

        private string[] animatedTexts;
        private int currentTextIndex = 0;
        private int currentCharIndex = 0;
        private Timer animationTimer = new Timer();

        public Battle(List<Pokemon> selectedPokemons, string selectedPokemonImageName, List<Pokemon> enemyPokemons)
        {
            InitializeComponent();
            this.selectedPokemons = selectedPokemons;
            this.selectedPokemonImageFileName = selectedPokemonImageName;
            this.enemyPokemons = enemyPokemons;

            // First enemy comes randomly
           
            enemyRandomIndex = enemyRandom.Next(0, 3);

            if (enemyRandomIndex < enemyPokemons.Count)
            {
                string enemyImageFileName = @"C:\pokemon\Pokemon-master\pictures\" + enemyPokemons[enemyRandomIndex].ImageFileName + ".png";
                LoadImageForEnemyPokemon(enemyImageFileName);

                // lblText animoitu label
                string message1 = $"Go! {selectedPokemons[0].pokemonName}! ";
                animatedTexts = new string[] { message1, $"What will {selectedPokemons[0].pokemonName} do?", $"{selectedPokemons[0].pokemonName} used a move!", "It's super effective!", $"Foe {enemyPokemons[enemyRandomIndex].pokemonName} flinched!" };
            }

                string imageFileName = @"C:\pokemon\Pokemon-master\pictures\" + selectedPokemons[0].ImageFileName + ".png";
                LoadImageForSelectedPokemon(imageFileName);

            // Text animation timer
            animationTimer.Interval = 12; // Text speed
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
            UpdateLabelText();

        }
      
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentCharIndex < animatedTexts[currentTextIndex].Length)
            {
                currentCharIndex++;
                UpdateLabelText();
            }
            else
            {
                animationTimer.Stop();
            }
        }
        private void UpdateLabelText()
        {
            lblText.Text = animatedTexts[currentTextIndex].Substring(0, currentCharIndex);
        }

        private void LoadImageForSelectedPokemon(string imageFileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(imageFileName) && System.IO.File.Exists(imageFileName))
                {
                    pictureBox1.ImageLocation = imageFileName;
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Virhe kuvan lataamisessa: {e.Message}");
            }
        }
        private void LoadImageForEnemyPokemon(string enemyImageFileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(enemyImageFileName) && System.IO.File.Exists(enemyImageFileName))
                {
                    pictureBox2.ImageLocation = enemyImageFileName;
                }
                else
                {
                    pictureBox2.Image = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Virhe kuvan lataamisessa: {e.Message}");
            }
        }


        private void UpdateProgressBar()
        {
                if (selectedPokemons[0].pokemonHealth >= 0)
                {
                    playerPokemonHealthBar.Value = selectedPokemons[0].pokemonHealth;
                }
                else
                {
                    playerPokemonHealthBar.Value = 0;
                }

        }
        private void UpdateEnemyProgressBar()
        {
            if (enemyPokemons[enemyRandomIndex].pokemonHealth >= 0)
            {
                enemyPokemonHealthBar.Value = enemyPokemons[enemyRandomIndex].pokemonHealth;
            }
            else
            {
                enemyPokemonHealthBar.Value = 0;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         
            lblPlayerPokemonName.Text = $"{selectedPokemons[0].pokemonName}";
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
            lblEnemyPokemonName.Text = $"{enemyPokemons[enemyRandomIndex].pokemonName}";
            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";

            playerPokemonHealthBar.Minimum = 0;
            playerPokemonHealthBar.Maximum = selectedPokemons[0].pokemonHealth;
            playerPokemonHealthBar.Value = selectedPokemons[0].pokemonHealth;
            enemyPokemonHealthBar.Minimum = 0;
            enemyPokemonHealthBar.Maximum = enemyPokemons[enemyRandomIndex].pokemonHealth;
            enemyPokemonHealthBar.Value = enemyPokemons[enemyRandomIndex].pokemonHealth;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            currentTextIndex = (currentTextIndex + 1) % animatedTexts.Length;
            currentCharIndex = 0;
            animationTimer.Start();

            //lblText.Text = $"Valittu Pokemon: {selectedPokemons[0].pokemonName}\nValittu Pokemon: {selectedPokemons[1].pokemonName}\nValittu Pokemon: {selectedPokemons[2].pokemonName}";
        }
       

        private void btnDamage_Click(object sender, EventArgs e)
        {
            selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - 10, 0);
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
            UpdateProgressBar();
        }

        private void btnHeal_Click(object sender, EventArgs e)
        {
            selectedPokemons[0].pokemonHealth = Math.Min(selectedPokemons[0].pokemonHealth + 10, selectedPokemons[0].pokemonStartHealth);
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
            UpdateProgressBar();
        }

        private void btnHeal2_Click(object sender, EventArgs e)
        {
            enemyPokemons[enemyRandomIndex].pokemonHealth = Math.Min(enemyPokemons[enemyRandomIndex].pokemonHealth + 10, enemyPokemons[enemyRandomIndex].pokemonStartHealth);
            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
            UpdateEnemyProgressBar();
        }

        private void btnDamage2_Click(object sender, EventArgs e)
        {
            enemyPokemons[enemyRandomIndex].pokemonHealth = Math.Max(enemyPokemons[enemyRandomIndex].pokemonHealth - 10, 0);
            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
            UpdateEnemyProgressBar();
        }
        private void MoveButtonsVisible()
        {
            lblText.Visible = false;
            btnMove1.Visible = true;
            btnMove2.Visible = true;
            btnMove3.Visible = true;
            btnMove4.Visible = true;
        }
        private void MoveButtonsHidden()
        {
            lblText.Visible = true;
            btnMove1.Visible = false;
            btnMove2.Visible = false;
            btnMove3.Visible = false;
            btnMove4.Visible = false;
        }

        private void btnFight_Click(object sender, EventArgs e)
        {
            MoveButtonsVisible();
        }

        private void btnMove1_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used Move1!";
        }

        private void btnMove2_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used Move2!";
        }

        private void btnMove3_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used Move3!";
        }

        private void btnMove4_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used Move4!";
        }
    }
}
