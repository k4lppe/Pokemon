using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;


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

        Random paralysis = new Random();
        int paralysisChance;

        Random increasedCritical = new Random();
        int increasedCriticalChance;

        Random confuse = new Random();
        int confuseChance;

        Random flinch = new Random();
        int flinchChance;

        Random burn = new Random();
        int burningChance;


        private string[] animatedTexts;
        private int currentTextIndex = 0;
        private int currentCharIndex = 0;
        private Timer animationTimer = new Timer();
        private Timer moveTimer = new Timer();

        int potions = 5;
        int superPotions = 3;
        int hyperPotions = 1;

        bool pokemon0Alive = true;
        bool pokemon1Alive = false;
        bool pokemon2Alive = false;

        bool ePokemon0Alive = true;
        bool ePokemon1Alive = false;
        bool ePokemon2Alive = false;

        bool playerTurn;
        bool enemyTurn;

        private int aliveEnemyPokemons;

        public Battle(List<Pokemon> selectedPokemons, string selectedPokemonImageName, List<Pokemon> enemyPokemons)
        {
            InitializeComponent();
            this.selectedPokemons = selectedPokemons;
            this.selectedPokemonImageFileName = selectedPokemonImageName;
            this.enemyPokemons = enemyPokemons;

            enemyRandomIndex = enemyRandom.Next(0, 3);
            enemyIndex = enemyRandomIndex;

            if (enemyRandomIndex < enemyPokemons.Count)
            {
                string enemyImageFileName = @"C:\pokemon\Pokemon-master\pictures\" + enemyPokemons[enemyRandomIndex].ImageFileName + ".png";
                LoadImageForEnemyPokemon(enemyImageFileName);
            }
       
            string message1 = $"Go! {selectedPokemons[0].pokemonName}! ";
            animatedTexts = new string[] { $"{enemyPokemons[enemyRandomIndex].pokemonName }\n{ enemyPokemons[enemyRandomIndex2].pokemonName}\n{ enemyPokemons[enemyRandomIndex3].pokemonName}", message1, $"What will {selectedPokemons[0].pokemonName} do?", $"{selectedPokemons[0].pokemonName} used a move!", "It's super effective!", $"Foe {enemyPokemons[enemyRandomIndex].pokemonName} flinched!" };

            string imageFileName = @"C:\pokemon\Pokemon-master\pictures\" + selectedPokemons[0].ImageFileName + ".png";
            LoadImageForSelectedPokemon(imageFileName);

         
            animationTimer.Interval = 12; // Text speed
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
            UpdateLabelText();
            aliveEnemyPokemons = enemyPokemons.Count;
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
                MessageBox.Show($"Image could not be loaded: {e.Message}");
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
        private bool isEnemyPokemonAlive()
        {
            return aliveEnemyPokemons > 0;
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
            if (enemyIndex >= 0 && enemyIndex < enemyPokemons.Count && enemyPokemons[enemyIndex].pokemonHealth >= 0)
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



        private void btnDamage_Click(object sender, EventArgs e)
        {
            selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - 20, 0);
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
            UpdateProgressBar();
            if (selectedPokemons[0].pokemonHealth <= 0)
            {
                pokemon1Alive = true;
                lblText.Text = $"{selectedPokemons[0].pokemonName} fainted!";

                HideBag();
                MoveButtonsHidden();
                SwitchToNextPokemon();
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
            enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - 20, 0);
            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
            UpdateEnemyProgressBar();

            if (enemyPokemons[enemyIndex].pokemonHealth <= 0)
            {
                ePokemon1Alive = true;
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} fainted!";

                HideBag();
                MoveButtonsHidden();
                if (enemyPokemons.Count > 0)
                {
                    EnemySwitchToNextPokemon();
                }

            }
        }

        private void MoveButtonsVisible()
        {
            lblText.Visible = false;
            btnMove1.Text = selectedPokemons[0].move1;
            btnMove2.Text = selectedPokemons[0].move2;
            btnMove3.Text = selectedPokemons[0].move3;
            btnMove4.Text = selectedPokemons[0].move4;
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
            lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move1}!";
            switch (selectedPokemons[0].move1)
            {
                case "Dragon Rage":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    break;

                case "Dragon Claw":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    break;

                case "Drill Peck":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    break;

                case "Body Slam":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    paralysisChance = paralysis.Next(0, 3);
                    if (paralysisChance == 0)
                    {
                        enemyPokemons[enemyIndex].pokemonParalyzed = true;
                        moveTimer.Interval = 1000;
                        moveTimer.Tick += MoveTimer_Tick;
                        moveTimer.Start();
                    }
                    break;

                case "Confuse Ray":
                    enemyPokemons[enemyIndex].pokemonConfused = true;
                    break;

                case "Karate Chop":
                    increasedCriticalChance = increasedCritical.Next(0, 9);
                    if (increasedCriticalChance == 0)
                    {
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage * 2, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        enemyPokemons[enemyIndex].pokemonCriticalHit = true;
                        moveTimer.Interval = 1000;
                        moveTimer.Tick += MoveTimer_Tick;
                        moveTimer.Start();
                        UpdateEnemyProgressBar();
                    }
                    else
                    {
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                    }                          
                    break;
            }
        }
        bool usedLeer = false;
        bool speedFell = false; 
        private void btnMove2_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move2}!";
            switch(selectedPokemons[0].move2)
            {
                case "Bite":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    flinchChance = flinch.Next(0, 3);
                    if(flinchChance == 0)
                    {
                        enemyPokemons[enemyIndex].pokemonFlinch = true;
                        moveTimer.Interval = 1000;
                        moveTimer.Tick += MoveTimer_Tick;
                        moveTimer.Start();
                        UpdateEnemyProgressBar();
                    }
                    
                    break;

                case "Ember":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    burningChance = burn.Next(0, 11);
                    if(burningChance == 5)
                    {
                        enemyPokemons[enemyIndex].pokemonBurning = true;
                        moveTimer.Interval = 1000;
                        moveTimer.Tick += MoveTimer_Tick;
                        moveTimer.Start();
                        
                    }
                    break;

                case "Thunder Shock":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    paralysisChance = paralysis.Next(0, 11);
                    if (paralysisChance == 2)
                    {
                        enemyPokemons[enemyIndex].pokemonParalyzed = true;
                        moveTimer.Interval = 1000;
                        moveTimer.Tick += MoveTimer_Tick;
                        moveTimer.Start();
                    }
                    break;

                case "Belly Drum":
                    selectedPokemons[0].move1Damage = Math.Max(selectedPokemons[0].move1Damage * 2, 0);
                    selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - selectedPokemons[0].pokemonStartHealth / 2, 0);
                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                    playerPokemonHealthBar.Value = Math.Min(selectedPokemons[0].pokemonHealth / 2, playerPokemonHealthBar.Maximum);
                    UpdateProgressBar();
                    break;

                case "Lick":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    paralysisChance = paralysis.Next(0, 3);
                    if(paralysisChance == 0)
                    {
                        enemyPokemons[enemyIndex].pokemonParalyzed = true;
                        moveTimer.Interval = 1000;
                        moveTimer.Tick += MoveTimer_Tick;
                        moveTimer.Start();
                    }
                    break;

                case "Leer":
                    usedLeer = true;
                    enemyPokemons[enemyIndex].defense = Math.Max(enemyPokemons[enemyIndex].defense - enemyPokemons[enemyIndex].defense - 10, 0);
                    if(usedLeer)
                    {
                        moveTimer.Interval = 1000;
                        moveTimer.Tick += MoveTimer_Tick;
                        moveTimer.Start();                      
                    }
                    break;
            }
        }

        private void btnMove3_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move3}!";
            switch(selectedPokemons[0].move3)
            {
                case "Bubblebeam":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move3Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    paralysisChance = paralysis.Next(0, 3);
                    if(paralysisChance == 0)
                    {
                        speedFell = true;
                        enemyPokemons[enemyIndex].speed = Math.Max(enemyPokemons[enemyIndex].speed - 10, 0);
                        moveTimer.Interval = 1000;
                        moveTimer.Tick += MoveTimer_Tick;
                        moveTimer.Start();
                    }
                    break;

                case "Dragon Breath":
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move3Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    paralysisChance = paralysis.Next(0, 3);
                    if(paralysisChance == 0)
                    {
                        enemyPokemons[enemyIndex].pokemonParalyzed = true;
                        enemyPokemons[enemyIndex].speed = Math.Max(enemyPokemons[enemyIndex].speed - 10, 0);
                        moveTimer.Interval = 1000;
                        moveTimer.Tick += MoveTimer_Tick;
                        moveTimer.Start();
                    }
                    break;
            }
        }

        private void btnMove4_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move4}!";
        }
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            moveTimer.Stop();

            if(enemyPokemons[enemyIndex].pokemonParalyzed)
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fully paralyzed!";
            }
            if(enemyPokemons[enemyIndex].pokemonCriticalHit)
            {
                lblText.Text = "A critical hit!";
            }
            if(enemyPokemons[enemyIndex].pokemonFlinch)
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} flinched!";
            }
            if(enemyPokemons[enemyIndex].pokemonBurning)
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is burning!";
            }
            if(usedLeer)
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} defence fell!";
            }
            if(speedFell)
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} speed fell!";
            }

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
            ePokemon1Alive = false;
            aliveEnemyPokemons--;

            if (isEnemyPokemonAlive())
            {
                int newEnemyIndex = (enemyIndex + 1) % enemyPokemons.Count;

                if (newEnemyIndex >= 0 && newEnemyIndex < enemyPokemons.Count)
                {
                    enemyIndex = newEnemyIndex;
                    LoadEnemyPokemonData();
                }
            }
            else
            {
                lblText.Text = "u win lil bro";
            }
        }
        private void LoadEnemyPokemonData()
        {
            enemyPokemonHealthBar.Maximum = enemyPokemons[enemyIndex].pokemonStartHealth;
            enemyPokemonHealthBar.Value = Math.Min(enemyPokemons[enemyIndex].pokemonHealth, enemyPokemonHealthBar.Maximum);
            string enemyImageFileName = @"C:\pokemon\Pokemon-master\pictures\" + enemyPokemons[enemyIndex].ImageFileName + ".png";
            LoadImageForEnemyPokemon(enemyImageFileName);
            lblEnemyPokemonName.Text = $"{enemyPokemons[enemyIndex].pokemonName}";
            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
            UpdateEnemyProgressBar();
            ePokemon1Alive = true;
        }

        private void btnMove1_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            switch(selectedPokemons[0].move1)
            {
                case "Dragon Rage":
                    lblInfo.Text = "Dragon Rage always deals 40 HP damage to the target, regardless of typing. It has no additional effect.";
                    break;

                case "Dragon Claw":
                    lblInfo.Text = "Dragon Claw deals damage with no additional effect.";
                    break;

                case "Drill Peck":
                    lblInfo.Text = "Drill Peck deals damage with no additional effect.";
                    break;

                case "Body Slam":
                    lblInfo.Text = "Body Slam deals damage and has a 30% chance of paralyzing the target.";
                    break;

                case "Confuse Ray":
                    lblInfo.Size = new Size(500, 190);
                    lblInfo.Location = new System.Drawing.Point(9, 300);
                    lblInfo.Text = "Confuse Ray causes the target to become confused. Confused Pokémon have a 33% chance of hurting themselves each turn, for 1-4 attacking turns. The damage received is as if the Pokémon attacks itself with a typeless 40 base power Physical attack.";
                    break;

                case "Karate Chop":
                    lblInfo.Text = "Karate Chop deals damage and has an increased critical hit ratio (1⁄8 instead of 1⁄24).";
                    break;
            }
        }

        private void btnMove1_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void btnMove2_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            switch(selectedPokemons[0].move2)
            {
                case "Bite":
                    lblInfo.Text = "Bite deals damage and has a 30% chance of causing the target to flinch.";
                    break;

                case "Ember":
                    lblInfo.Text = "Ember deals damage and has a 10% chance of burning the target.";
                    break;

                case "Thunder Shock":
                    lblInfo.Text = "Thunder Shock deals damage and has a 10% chance of paralyzing the target.";
                    break;

                case "Belly Drum":
                    lblInfo.Text = "User loses 50% of its max HP, but Attack doubles.";
                    break;

                case "Lick":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Lick deals damage and has a 30% chance of paralyzing the target.";
                    break;

                case "Leer":
                    lblInfo.Text = "Leer lowers the target's Defense by 10.";
                    break;
            }
        }

        private void btnMove2_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void btnMove3_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            switch(selectedPokemons[0].move3)
            {
                case "Bubblebeam":
                    lblInfo.Text = "Bubblebeam deals damage and has a 10% chance of lowering the target's Speed by 10.";
                    break;

                case "Dragon Breath":
                    lblInfo.Text = "Dragon Breath deals damage and has a 30% chance of paralyzing the target.";
                    break;

                case "Thunder Wave":
                    lblInfo.Text = "Thunder Wave paralyzes the opponent. Paralyzed Pokémon have a 25% chance of not being able to attack, and their Speed is decreased by 50%";
                    break;

                case "Double-Edge":
                    lblInfo.Text = "Double-Edge deals a lot of damage, but the user receives 1⁄3 of the damage it inflicted in recoil.";
                    break;

                case "Hypnosis":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Hypnosis puts the target to sleep, if it hits. Sleeping Pokémon cannot move. Sleep lasts for 1-3 turns.";
                    break;

                case "Focus Energy":
                    lblInfo.Text = "Increases critical hit ratio by 4.";
                    break;
            }
            
        }

        private void btnMove3_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void btnMove4_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            switch(selectedPokemons[0].move4)
            {
                case "Hydro Pump":
                    lblInfo.Text = "Hydro Pump deals damage with no additional effect.";
                    break;

                case "Growl":
                    lblInfo.Text = "Growl lowers the target's Attack by 10.";
                    break;

                case "Charge":
                    lblInfo.Text = "Charge raises the user's Defense by 10, and if this Pokémon's next move is a damage-dealing Electric-type attack, it will deal double damage.";
                    break;

                case "Rest":
                    lblInfo.Text = "User sleeps for 2 turns, but user is fully healed.";
                    break;

                case "Hex":
                    lblInfo.Text = "Hex inflicts damage, but if the target has a major status ailment (burned, poisoned, paralyzed, asleep or frozen) it will double in power to 130.";
                    break;

                case "Submission":
                    lblInfo.Text = "Submission deals damage, but the user receives 1⁄4 of the damage it inflicts in recoil.";
                    break;
            }
        }

        private void btnMove4_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void btnPotion_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Text = "Potion heals its user by 20 HP";
        }

        private void btnPotion_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void btnSPotion_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Text = "Super Potion heals its user by 50 HP";
        }

        private void btnSPotion_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void btnHPotion_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Text = "Hyper Potion heals its user by 200 HP";
        }

        private void btnHPotion_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }
    }
}
