using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace pokemon
{
    public partial class Battle : Form
    {
        private List<Pokemon> selectedPokemons;
        private List<Pokemon> enemyPokemons;
        private string selectedPokemonImageFileName;
        Random enemyRandom = new Random();
        private int enemyRandomIndex;

        Random enemyRandom2 = new Random();
        private int enemyRandomIndex2;
        int enemyIndex;

        Random enemyRandom3 = new Random();
        private int enemyRandomIndex3;

        private string[] animatedTexts;
        private int currentTextIndex = 0;
        private int currentCharIndex = 0;
        private Timer animationTimer = new Timer();

        int potions = 5;
        int superPotions = 3;
        int hyperPotions = 1;

        bool pokemon0Alive = true;
        bool pokemon1Alive = false;
        bool pokemon2Alive = false;

        bool ePokemon0Alive = true;
        bool ePokemon1Alive = false;
        bool ePokemon2Alive = false;

        public Battle(List<Pokemon> selectedPokemons, string selectedPokemonImageName, List<Pokemon> enemyPokemons)
        {
            InitializeComponent();
            this.selectedPokemons = selectedPokemons;
            this.selectedPokemonImageFileName = selectedPokemonImageName;
            this.enemyPokemons = enemyPokemons;

            // First enemy comes randomly

            enemyRandomIndex = enemyRandom.Next(0, 3);
            enemyIndex = enemyRandomIndex;

            if (enemyRandomIndex < enemyPokemons.Count)
            {
                string enemyImageFileName = @"C:\pokemon\Pokemon-master\pictures\" + enemyPokemons[enemyRandomIndex].ImageFileName + ".png";
                LoadImageForEnemyPokemon(enemyImageFileName);
            }
            // lblText animoitu label
            string message1 = $"Go! {selectedPokemons[0].pokemonName}! ";
            animatedTexts = new string[] { message1, $"What will {selectedPokemons[0].pokemonName} do?", $"{selectedPokemons[0].pokemonName} used a move!", "It's super effective!", $"Foe {enemyPokemons[enemyRandomIndex].pokemonName} flinched!" };

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
            catch (Exception e)
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
                playerPokemonHealthBar.Maximum = selectedPokemons[0].pokemonStartHealth;
                playerPokemonHealthBar.Value = Math.Min(selectedPokemons[0].pokemonHealth, playerPokemonHealthBar.Maximum);
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
                enemyPokemonHealthBar.Maximum = enemyPokemons[enemyIndex].pokemonStartHealth;
                enemyPokemonHealthBar.Value = Math.Min(enemyPokemons[enemyIndex].pokemonHealth, enemyPokemonHealthBar.Maximum);
            }
            else
            {
                enemyPokemonHealthBar.Value = 0;
            }
        }
        private void HideBag()
        {
            btnPotion.Visible = false;
            btnSPotion.Visible = false;
            btnHPotion.Visible = false;
        }
        private void ShowBag()
        {
            btnPotion.Visible = true;
            btnSPotion.Visible = true;
            btnHPotion.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HideBag();

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
            selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - 20, 0);
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
            UpdateProgressBar();
            if (selectedPokemons[0].pokemonHealth <= 0)
            {
                pokemon1Alive = true;
                lblText.Text = $"{selectedPokemons[0].pokemonName} fainted!";
                enemyPokemons.RemoveAt(enemyRandomIndex);
                HideBag();
                MoveButtonsHidden();
                SwitchToNextPokemon();
            }
        }
        private void RollNewPokemon()
        {
            enemyRandomIndex2 = enemyRandom2.Next(0, 2);
            if (enemyRandomIndex < enemyPokemons.Count)
            {
                enemyIndex = enemyRandomIndex;
                string enemyImageFileName = @"C:\pokemon\Pokemon-master\pictures\" + enemyPokemons[enemyIndex].ImageFileName + ".png";
                LoadImageForEnemyPokemon(enemyImageFileName);
            }
        }
        private void RollLastPokemon()
        {
            enemyRandomIndex3 = enemyRandom3.Next(0, 1);
            if (enemyRandomIndex < enemyPokemons.Count)
            {
                enemyIndex = enemyRandomIndex3;
                string enemyImageFileName = @"C:\pokemon\Pokemon-master\pictures\" + enemyPokemons[enemyRandomIndex3].ImageFileName + ".png";
                LoadImageForEnemyPokemon(enemyImageFileName);
            }
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
            enemyPokemons[enemyRandomIndex].pokemonHealth = Math.Max(enemyPokemons[enemyRandomIndex].pokemonHealth - 20, 0);
            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
            UpdateEnemyProgressBar();
            if (enemyPokemons[enemyRandomIndex].pokemonHealth <= 0)
            {
                ePokemon1Alive = true;
                lblText.Text = $"Foe {enemyPokemons[enemyRandomIndex].pokemonName} fainted!";
                HideBag();
                MoveButtonsHidden();
                EnemySwitchToNextPokemon();
                if (ePokemon1Alive)
                {
                    RollNewPokemon();
                }
                else
                {
                    RollLastPokemon();
                }

            }
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
            HideBag();
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

        private void btnBag_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            ShowBag();
            btnPotion.Text = $"Potions x{potions}";
            btnSPotion.Text = $"Super Potions x{superPotions}";
            btnHPotion.Text = $"Hyper Potions x{hyperPotions}";
        }

        private void btnPotion_Click(object sender, EventArgs e)
        {

            if (potions > 0)
            {
                if (selectedPokemons[0].pokemonHealth == selectedPokemons[0].pokemonStartHealth)
                {
                    HideBag();
                    lblText.Text = $"{selectedPokemons[0].pokemonName} is already fully healed.";
                }
                else
                {
                    HideBag();
                    lblText.Text = $"Used Potion on {selectedPokemons[0].pokemonName}!";
                    selectedPokemons[0].pokemonHealth = Math.Min(selectedPokemons[0].pokemonHealth + 20, selectedPokemons[0].pokemonStartHealth);
                    UpdateProgressBar();
                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                    potions--;
                    btnPotion.Text = $"Potions x{potions}";
                }
            }
            else
            {
                HideBag();
                lblText.Text = $"You're all out of Potions!";
            }


        }

        private void btnSPotion_Click(object sender, EventArgs e)
        {

            if (superPotions > 0)
            {
                if (selectedPokemons[0].pokemonHealth == selectedPokemons[0].pokemonStartHealth)
                {
                    HideBag();
                    lblText.Text = $"{selectedPokemons[0].pokemonName} is already fully healed.";
                }
                else
                {
                    HideBag();
                    lblText.Text = $"Used Super Potion on {selectedPokemons[0].pokemonName}!";
                    selectedPokemons[0].pokemonHealth = Math.Min(selectedPokemons[0].pokemonHealth + 50, selectedPokemons[0].pokemonStartHealth);
                    UpdateProgressBar();
                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                    superPotions--;
                    btnSPotion.Text = $"Super Potions x{superPotions}";
                }
            }
            else
            {
                HideBag();
                lblText.Text = $"You're all out of Super Potions!";
            }

        }

        private void btnHPotion_Click(object sender, EventArgs e)
        {
            if (hyperPotions > 0)
            {
                if (selectedPokemons[0].pokemonHealth == selectedPokemons[0].pokemonStartHealth)
                {
                    HideBag();
                    lblText.Text = $"{selectedPokemons[0].pokemonName} is already fully healed.";
                }
                else
                {
                    HideBag();
                    lblText.Text = $"Used Hyper Super Potion on {selectedPokemons[0].pokemonName}!";
                    selectedPokemons[0].pokemonHealth = Math.Min(selectedPokemons[0].pokemonHealth + 200, selectedPokemons[0].pokemonStartHealth);
                    UpdateProgressBar();
                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                    hyperPotions--;
                    btnHPotion.Text = $"Hyper Potions x{hyperPotions}";
                }
            }
            else
            {
                HideBag();
                lblText.Text = $"You're all out of Super Potions!";
            }
        }
        private void SwitchToNextPokemon()
        {
            if (selectedPokemons[0].pokemonHealth <= 0)
            {
                if (selectedPokemons[1] == null)
                {
                    selectedPokemons[0] = selectedPokemons[2];
                    selectedPokemons[2] = null;
                    pokemon2Alive = true;
                    pokemon1Alive = false;
                }
                if (pokemon1Alive)
                {
                    selectedPokemons[0] = selectedPokemons[1];
                    selectedPokemons[1] = null;
                    pokemon0Alive = false;
                    pokemon2Alive = true;
                }
            }
            if (selectedPokemons[0] != null)
            {
                string imageFileName = @"C:\pokemon\Pokemon-master\pictures\" + selectedPokemons[0].ImageFileName + ".png";
                LoadImageForSelectedPokemon(imageFileName);
                lblPlayerPokemonName.Text = $"{selectedPokemons[0].pokemonName}";
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();
            }
            else
            {
                lblText.Text = $"Enemy defeated! You win!";
                lblText.Text = $"Gained - amout of xp!";

            }

        }
        private void EnemySwitchToNextPokemon()
        {
            if (enemyPokemons[enemyRandomIndex].pokemonHealth <= 0)
            {
                if (ePokemon1Alive)
                {
                    enemyPokemons[enemyRandomIndex] = enemyPokemons[enemyRandomIndex2];
                    enemyPokemons[enemyRandomIndex2] = null;
                    ePokemon0Alive = false;
                    ePokemon2Alive = true;
                }
                if (enemyPokemons[enemyRandomIndex2] == null)
                {

                    pokemon2Alive = true;
                    pokemon1Alive = false;
                }
            }
            if (enemyPokemons[enemyRandomIndex] != null)
            {
                enemyIndex = enemyRandomIndex;
                string enemyImageFileName = @"C:\pokemon\Pokemon-master\pictures\" + enemyPokemons[enemyIndex].ImageFileName + ".png";
                LoadImageForEnemyPokemon(enemyImageFileName);
                lblEnemyPokemonName.Text = $"{enemyPokemons[enemyIndex].pokemonName}";
                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                UpdateEnemyProgressBar();
            }
        }
    }
}
