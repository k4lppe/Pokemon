using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pokemon
{
    public partial class Battle : Form
    {
        private readonly List<Pokemon> selectedPokemons;
        private readonly List<Pokemon> enemyPokemons;
        private readonly string selectedPokemonImageFileName;

        readonly Random enemyRandom = new Random();
        private readonly int enemyRandomIndex;

        int enemyIndex;
        readonly Random paralysis = new Random();
        int paralysisChance;

        readonly Random increasedCritical = new Random();
        int increasedCriticalChance;

        readonly Random confuse = new Random();
        readonly int confuseChance;

        readonly Random flinch = new Random();
        int flinchChance;

        readonly Random sleep = new Random();
        int sleepingChance;

        readonly Random burn = new Random();
        int burningChance;

        readonly Random enemy = new Random();
        int enemyMove;

        private Timer turnTimer = new Timer();
        private int turnDelay = 5000;
        private bool playerTurn = true;
        private bool enemyTurnInProgress = false;
        private const int turnDelaySec = 4;

        private Timer moveTimer = new Timer();
        private int delay = 2000;

        int potions = 5;
        int superPotions = 3;
        int hyperPotions = 1;
        int lumBerries = 1;

        bool pokemon0Alive = true;
        bool pokemon1Alive = false;
        bool pokemon2Alive = false;

        bool ePokemon0Alive = true;
        bool ePokemon1Alive = false;
        bool ePokemon2Alive = false;

        bool eventActive = false;

        private int aliveEnemyPokemons;

        public Battle(List<Pokemon> selectedPokemons, string selectedPokemonImageName, List<Pokemon> enemyPokemons)
        {
            InitializeComponent();


            this.selectedPokemons = selectedPokemons;
            this.selectedPokemonImageFileName = selectedPokemonImageName;
            this.enemyPokemons = enemyPokemons;

            enemyRandomIndex = enemyRandom.Next(0, 3);
            enemyIndex = enemyRandomIndex;

            turnTimer.Interval = turnDelay;
            turnTimer.Tick += TurnTimer_Tick;

            if (enemyRandomIndex < enemyPokemons.Count)
            {
                string enemyImageFileName = @"C:\pokemon\Pokemon-master\pictures\" + enemyPokemons[enemyRandomIndex].ImageFileName + "2" + ".gif";
                LoadImageForEnemyPokemon(enemyImageFileName);
            }



            string imageFileName = @"C:\pokemon\Pokemon-master\pictures\" + selectedPokemons[0].ImageFileName + ".gif";
            LoadImageForSelectedPokemon(imageFileName);

            aliveEnemyPokemons = enemyPokemons.Count;
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
        private bool IsEnemyPokemonAlive()
        {
            return aliveEnemyPokemons > 0;
        }

        private void UpdateProgressBar()
        {
            if (selectedPokemons[0].pokemonHealth >= 0)
            {
                playerPokemonHealthBar.Maximum = selectedPokemons[0].pokemonStartHealth;
                playerPokemonHealthBar.Value = Math.Min(selectedPokemons[0].pokemonHealth, playerPokemonHealthBar.Maximum);
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
            }
            else
            {
                playerPokemonHealthBar.Value = 0;
                lblPlayerPokemonHealth.Text = $"0/{selectedPokemons[0].pokemonStartHealth}";
            }

        }
        private void UpdateEnemyProgressBar()
        {
            if (enemyIndex >= 0 && enemyIndex < enemyPokemons.Count && enemyPokemons[enemyIndex].pokemonHealth >= 0)
            {
                enemyPokemonHealthBar.Maximum = enemyPokemons[enemyIndex].pokemonStartHealth;
                enemyPokemonHealthBar.Value = Math.Min(enemyPokemons[enemyIndex].pokemonHealth, enemyPokemonHealthBar.Maximum);
                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";              
            }
            else
            {
                enemyPokemonHealthBar.Value = 0;
                lblEnemyPokemonHealth.Text = $"0/{enemyPokemons[enemyIndex].pokemonStartHealth}";               
            }
        }
        private void HideBag()
        {
            btnPotion.Visible = false;
            btnSPotion.Visible = false;
            btnHPotion.Visible = false;
            btnLumberry.Visible = false;
        }
        private void ShowBag()
        {
            btnPotion.Visible = true;
            btnSPotion.Visible = true;
            btnHPotion.Visible = true;
            btnLumberry.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HideBag();

            lblPlayerPokemonName.Text = $"{selectedPokemons[0].pokemonName}";
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
            lblEnemyPokemonName.Text = $"{enemyPokemons[enemyRandomIndex].pokemonName}";
            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
            lblText.Text = $"Go! {selectedPokemons[0].pokemonName}!";

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

        private void BtnHeal_Click(object sender, EventArgs e)
        {
            selectedPokemons[0].pokemonHealth = Math.Min(selectedPokemons[0].pokemonHealth + 10, selectedPokemons[0].pokemonStartHealth);
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
            UpdateProgressBar();
        }

        private void BtnHeal2_Click(object sender, EventArgs e)
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
            EnemyPokemonFaints();
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

        private void BtnFight_Click(object sender, EventArgs e)
        {
            HideBag();
            MoveButtonsVisible();

        }

        bool defenceUp = false;
        bool criticalIncreased = false;
        bool attackFell = false;
        bool usedLeer = false;
        bool speedFell = false;
        private bool enemyHasAttacked = false;
        private void BtnMove1_Click(object sender, EventArgs e)
        {

            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move1}!";
            if (playerTurn)
            {
                switch (selectedPokemons[0].move1)
                {


                    case "Dragon Rage":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Dragon Claw":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Drill Peck":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Body Slam":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        paralysisChance = paralysis.Next(0, 3);
                        if (paralysisChance == 0)
                        {
                            enemyPokemons[enemyIndex].pokemonParalyzed = true;
                            lblParalyzed2.Visible = true;
                            PokemonParalyzed();
                        }
                        else
                        {
                            MoveDelayStart();
                        }
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        break;

                    case "Confuse Ray":
                        enemyPokemons[enemyIndex].pokemonConfused = true;
                        PokemonConfused();
                        turnTimer.Start();
                        break;

                    case "Karate Chop":
                        increasedCriticalChance = increasedCritical.Next(0, 9);
                        if (increasedCriticalChance == 0)
                        {

                            enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage * 2, 0);
                            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                            enemyPokemons[enemyIndex].pokemonCriticalHit = true;
                            eventActive = true;
                            UpdateEnemyProgressBar();
                            EnemyPokemonFaints();
                            CriticalHit();
                        }
                        else
                        {

                            enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                            UpdateEnemyProgressBar();
                            EnemyPokemonFaints();
                            MoveDelayStart();
                        }
                        turnTimer.Start();
                        break;
                }
            }

        }

        private void BtnMove2_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move2}!";
            if (playerTurn)
            {
                switch (selectedPokemons[0].move2)
                {
                    case "Bite":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        flinchChance = flinch.Next(0, 3);
                        if (flinchChance == 0)
                        {
                            enemyPokemons[enemyIndex].pokemonFlinch = true;
                            UpdateEnemyProgressBar();
                            EnemyPokemonFaints();
                            turnTimer.Start();                          
                            PokemonFlinch();                          
                        }
                        else
                        {
                            EnemyPokemonFaints();
                            turnTimer.Start();
                            MoveDelayStart();
                        }

                        break;

                    case "Ember":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        burningChance = burn.Next(0, 11);
                        if (burningChance == 5)
                        {
                            enemyPokemons[enemyIndex].pokemonBurning = true;
                            lblBurning2.Visible = true;
                        }
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Thunder Shock":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        paralysisChance = paralysis.Next(0, 11);
                        if (paralysisChance == 2)
                        {
                            enemyPokemons[enemyIndex].pokemonParalyzed = true;
                            lblParalyzed2.Visible = true;
                        }
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Belly Drum":
                        selectedPokemons[0].move1Damage = Math.Max(selectedPokemons[0].move1Damage * 2, 0); //MUOKKAA!
                        selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - selectedPokemons[0].pokemonStartHealth / 2, 0);
                        lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                        playerPokemonHealthBar.Value = Math.Min(selectedPokemons[0].pokemonHealth / 2, playerPokemonHealthBar.Maximum);
                        UpdateProgressBar();
                        UpdateEnemyProgressBar();
                        EnemyPokemonFaints();
                        PlayerPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Lick":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        paralysisChance = paralysis.Next(0, 3);
                        if (paralysisChance == 0)
                        {
                            enemyPokemons[enemyIndex].pokemonParalyzed = true;
                            lblParalyzed2.Visible = true;
                        }
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Leer":
                        usedLeer = true;
                        enemyPokemons[enemyIndex].defense = Math.Max(enemyPokemons[enemyIndex].defense - enemyPokemons[enemyIndex].defense - 10, 0);
                        if (usedLeer)
                        {

                        }
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;
                }
            }

        }

        private void BtnMove3_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move3}!";
            if (playerTurn)
            {
                switch (selectedPokemons[0].move3)
                {
                    case "Bubblebeam":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move3Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        paralysisChance = paralysis.Next(0, 3);
                        if (paralysisChance == 0)
                        {
                            speedFell = true;
                            enemyPokemons[enemyIndex].speed = Math.Max(enemyPokemons[enemyIndex].speed - 10, 0);
                            lblParalyzed2.Visible = true;
                        }
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Dragon Breath":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move3Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        paralysisChance = paralysis.Next(0, 3);
                        if (paralysisChance == 0)
                        {
                            enemyPokemons[enemyIndex].pokemonParalyzed = true;
                            enemyPokemons[enemyIndex].speed = Math.Max(enemyPokemons[enemyIndex].speed - 10, 0);
                            lblParalyzed2.Visible = true;
                        }
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Thunder Wave":
                        enemyPokemons[enemyIndex].pokemonParalyzed = true;;
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Double-Edge":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move3Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - selectedPokemons[0].move3Damage / 4, 0);
                        lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                        UpdateProgressBar();
                        EnemyPokemonFaints();
                        PlayerPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Hypnosis":
                        sleepingChance = sleep.Next(0, 3);
                        if (sleepingChance == 0)
                        {
                            enemyPokemons[enemyIndex].pokemonSleeping = true;
                            lblSleeping2.Visible = true;
                            EnemyPokemonFaints();
                            turnTimer.Start();
                            MoveDelayStart();
                        }
                        else
                        {
                            lblText.Text = $"{selectedPokemons[0].pokemonName} missed!";
                            EnemyPokemonFaints();
                            turnTimer.Start();
                            MoveDelayStart();
                        }
                        break;

                    case "Focus Energy":
                        criticalIncreased = true;
                        enemyPokemons[enemyIndex].pokemonSleeping = true;
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;
                }
            }

        }

        private void BtnMove4_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move4}!";
            if (playerTurn)
            {
                switch (selectedPokemons[0].move4)
                {
                    case "Hydro Pump":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move4Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Growl":
                        enemyPokemons[enemyIndex].move1Damage = enemyPokemons[enemyIndex].move1Damage - 10;
                        enemyPokemons[enemyIndex].move2Damage = enemyPokemons[enemyIndex].move2Damage - 10;
                        enemyPokemons[enemyIndex].move3Damage = enemyPokemons[enemyIndex].move3Damage - 10;
                        enemyPokemons[enemyIndex].move4Damage = enemyPokemons[enemyIndex].move4Damage - 10;
                        attackFell = true;
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Charge":
                        selectedPokemons[0].defense = selectedPokemons[0].defense + 10;
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;

                    case "Rest":
                        //btnFight.Enabled = false;
                        EnemyPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;


                    case "Hex":
                        if (enemyPokemons[enemyIndex].pokemonParalyzed || enemyPokemons[enemyIndex].pokemonBurning || enemyPokemons[enemyIndex].pokemonSleeping || enemyPokemons[enemyIndex].pokemonConfused)
                        {
                            enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move4Damage * 2, 0);
                            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                            UpdateEnemyProgressBar();
                            EnemyPokemonFaints();
                            turnTimer.Start();
                            MoveDelayStart();
                        }
                        else
                        {
                            enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move4Damage, 0);
                            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                            UpdateEnemyProgressBar();
                            EnemyPokemonFaints();
                            turnTimer.Start();
                            MoveDelayStart();
                        }
                        break;

                    case "Submission":
                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move4Damage, 0);
                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                        UpdateEnemyProgressBar();
                        selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - selectedPokemons[0].move3Damage / 4, 0);
                        lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                        UpdateProgressBar();
                        EnemyPokemonFaints();
                        PlayerPokemonFaints();
                        turnTimer.Start();
                        MoveDelayStart();
                        break;
                }
            }

        }

        private void TurnTimer_Tick(object sender, EventArgs e)
        {
            turnTimer.Tick -= TurnTimer_Tick;
            turnTimer.Interval = turnDelaySec * 1000;
            turnTimer.Start();
            PlayersTurn();
        }

        private async void EnemyPokemonFaints()
        {          
            if (enemyPokemons[enemyIndex].pokemonHealth <= 0)
            {
                enemyTurnInProgress = true;
                await Task.Delay(3000);
                ePokemon1Alive = true;
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} fainted!";

                HideBag();
                MoveButtonsHidden();
                criticalIncreased = false;
                enemyPokemons[enemyIndex].move1Damage = enemyPokemons[enemyIndex].move1Damage;
                enemyPokemons[enemyIndex].move2Damage = enemyPokemons[enemyIndex].move2Damage;
                enemyPokemons[enemyIndex].move3Damage = enemyPokemons[enemyIndex].move3Damage;
                enemyPokemons[enemyIndex].move4Damage = enemyPokemons[enemyIndex].move4Damage;
                enemyPokemons[enemyIndex].pokemonConfused = false;
                lblConfused2.Visible = false;
                enemyPokemons[enemyIndex].pokemonSleeping = false;
                lblSleeping2.Visible = false;
                enemyPokemons[enemyIndex].pokemonBurning = false;
                lblBurning2.Visible = false;
                enemyPokemons[enemyIndex].pokemonParalyzed = false;
                lblParalyzed2.Visible = false;
                selectedPokemons[0].defense = selectedPokemons[0].defense;
                if (enemyPokemons.Count > 0)
                {
                    EnemySwitchToNextPokemon();
                    await Task.Delay(2000);
                    lblText.Text = $"Enemy sent out {enemyPokemons[enemyIndex].pokemonName}!";
                }
                enemyTurnInProgress = false;
                PlayersTurn();
            }        
        }
        private async void PlayerPokemonFaints()
        {
            
            if (selectedPokemons[0].pokemonHealth <= 0)
            {
                enemyTurnInProgress = true;
                await Task.Delay(3000);
                pokemon1Alive = true;
                lblText.Text = $"{selectedPokemons[0].pokemonName} fainted!";

                HideBag();
                MoveButtonsHidden();
                criticalIncreased = false;
                selectedPokemons[0].move1Damage = selectedPokemons[0].move1Damage;
                selectedPokemons[0].move2Damage = selectedPokemons[0].move2Damage;
                selectedPokemons[0].move3Damage = selectedPokemons[0].move3Damage;
                selectedPokemons[0].move4Damage = selectedPokemons[0].move4Damage;
                selectedPokemons[0].pokemonConfused = false;
                lblConfused.Visible = false;
                selectedPokemons[0].pokemonSleeping = false;
                lblSleeping.Visible = false;
                selectedPokemons[0].pokemonBurning = false;
                lblBurning.Visible = false;
                selectedPokemons[0].pokemonParalyzed = false;
                lblParalyzed.Visible = false;
                selectedPokemons[0].defense = selectedPokemons[0].defense;
                if (selectedPokemons.Count > 0)
                {
                    SwitchToNextPokemon();
                    await Task.Delay(2000);
                    lblText.Text = $"Player sent out {selectedPokemons[0].pokemonName}!";
                }
                enemyTurnInProgress = false;
                await Task.Delay(3000);
                await EnemysTurn();
            }
        }

        private void btnBag_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            ShowBag();
            btnPotion.Text = $"Potions x{potions}";
            btnSPotion.Text = $"Super Potions x{superPotions}";
            btnHPotion.Text = $"Hyper Potions x{hyperPotions}";
            btnLumberry.Text = $"Lum Berries x{lumBerries}";
        }

        private void BtnPotion_Click(object sender, EventArgs e)
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
        private void BtnSPotion_Click(object sender, EventArgs e)
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

        private void BtnHPotion_Click(object sender, EventArgs e)
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
                string imageFileName = @"C:\pokemon\Pokemon-master\pictures\" + selectedPokemons[0].ImageFileName + ".gif";
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

            if (IsEnemyPokemonAlive())
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
            string enemyImageFileName = @"C:\pokemon\Pokemon-master\pictures\" + enemyPokemons[enemyIndex].ImageFileName + "2" + ".gif";
            LoadImageForEnemyPokemon(enemyImageFileName);
            lblEnemyPokemonName.Text = $"{enemyPokemons[enemyIndex].pokemonName}";
            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
            UpdateEnemyProgressBar();
            ePokemon1Alive = true;
        }

        private void BtnMove1_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            switch (selectedPokemons[0].move1)
            {
                case "Dragon Rage":
                    lblInfo.Text = "Dragon Rage always deals 40 HP damage to the target, regardless of typing. It has no additional effect.";
                    break;

                case "Dragon Claw":
                    lblInfo.Text = "Dragon Claw deals damage with no additional effect.";
                    break;

                case "Drill Peck":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Drill Peck deals damage with no additional effect.";
                    break;

                case "Body Slam":
                    lblInfo.Size = new Size(500, 190);
                    lblInfo.Location = new System.Drawing.Point(9, 300);
                    lblInfo.Text = "Body Slam deals damage and has a 30% chance of paralyzing the target. Paralyzed Pokémon have a 25% chance of not being able to attack. It doesn't affect Electric-type Pokémons.";
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

        private void BtnMove1_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void BtnMove2_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            switch (selectedPokemons[0].move2)
            {
                case "Bite":
                    lblInfo.Text = "Bite deals damage and has a 30% chance of causing the target to flinch.";
                    break;

                case "Ember":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Ember deals damage and has a 10% chance of burning the target. Burning Pokémon will lose HP every turn.";
                    break;

                case "Thunder Shock":
                    lblInfo.Size = new Size(500, 190);
                    lblInfo.Location = new System.Drawing.Point(9, 300);
                    lblInfo.Text = "Thunder Shock deals damage and has a 10% chance of paralyzing the target. Paralyzed Pokémon have a 25% chance of not being able to attack. It doesn't affect Electric-type Pokémons.";
                    break;

                case "Belly Drum":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "User loses 50% of its max HP, but Attack doubles.";
                    break;

                case "Lick":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Lick deals damage and has a 30% chance of paralyzing the target. Paralyzed Pokémon have a 25% chance of not being able to attack. It doesn't affect Electric-type Pokémons.";
                    break;

                case "Leer":
                    lblInfo.Text = "Leer lowers the target's Defense by 10.";
                    break;
            }
        }

        private void BtnMove2_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void BtnMove3_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            switch (selectedPokemons[0].move3)
            {
                case "Bubblebeam":
                    lblInfo.Text = "Bubblebeam deals damage and has a 10% chance of lowering the target's Speed by 10.";
                    break;

                case "Dragon Breath":
                    lblInfo.Size = new Size(500, 190);
                    lblInfo.Location = new System.Drawing.Point(9, 300);
                    lblInfo.Text = "Dragon Breath deals damage and has a 30% chance of paralyzing the target. Paralyzed Pokémon have a 25% chance of not being able to attack. It doesn't affect Electric-type Pokémons.";
                    break;

                case "Thunder Wave":
                    lblInfo.Size = new Size(500, 190);
                    lblInfo.Location = new System.Drawing.Point(9, 300);
                    lblInfo.Text = "Thunder Wave paralyzes the opponent. Paralyzed Pokémon have a 25% chance of not being able to attack. It doesn't affect Electric-type Pokémons.";
                    break;

                case "Double-Edge":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Double-Edge deals a lot of damage, but the user receives 1⁄4 of the damage it inflicted in recoil.";
                    break;

                case "Hypnosis":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Hypnosis puts the target to sleep, but it has 1/3 chance of missing. Sleeping Pokémon cannot move. Sleep lasts for 1-3 turns.";
                    break;

                case "Focus Energy":
                    lblInfo.Text = "Increases critical hit ratio from 1/16 to 1/4";
                    break;
            }

        }

        private void BtnMove3_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void BtnMove4_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            switch (selectedPokemons[0].move4)
            {
                case "Hydro Pump":
                    lblInfo.Text = "Hydro Pump deals damage with no additional effect.";
                    break;

                case "Growl":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Growl lowers the target's Attack by 10.";
                    break;

                case "Charge":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Charge raises the user's Defense by 10, and if this Pokémon's next move is a damage-dealing Electric-type attack, it will deal double damage.";
                    break;

                case "Rest":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
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

        private void BtnMove4_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void BtnPotion_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Text = "Potion heals its user by 20 HP";
        }

        private void BtnPotion_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void btnSPotion_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Text = "Super Potion heals its user by 50 HP";
        }

        private void BtnSPotion_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void BtnHPotion_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Text = "Hyper Potion heals its user by 200 HP";
        }

        private void BtnHPotion_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void BtnLumberry_Click(object sender, EventArgs e)
        {
            if (lumBerries > 0)
            {
                if (selectedPokemons[0].pokemonBurning || selectedPokemons[0].pokemonConfused || selectedPokemons[0].pokemonParalyzed || selectedPokemons[0].pokemonSleeping)
                {
                    HideBag();
                    lblText.Text = $"Used Lum Berry on {selectedPokemons[0].pokemonName}!";
                    RestorePokemonsCondition();
                    lumBerries--;
                    btnPotion.Text = $"Lum berries x{lumBerries}";

                }
                else
                {
                    HideBag();
                    lblText.Text = $"{selectedPokemons[0].pokemonName} is not affected by any non-volatile or volantile status condition.";
                }
            }
            else
            {
                HideBag();
                lblText.Text = $"You're all out of Lum Berries!";
            }
        }
        private void RestorePokemonsCondition()
        {
            selectedPokemons[0].pokemonSleeping = false;
            selectedPokemons[0].pokemonParalyzed = false;
            selectedPokemons[0].pokemonBurning = false;
            selectedPokemons[0].pokemonConfused = false;
        }

        private void BtnLumberry_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Text = "Lum Berry cures its users non-volatile or volantile status condition. (Sleeping, Paralysis, Confusion, Burning)";
        }

        private void BtnLumberry_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }
        private void FunctionButtonsHidden()
        {
            btnFight.Visible = false;
            btnBag.Visible = false;
            btnPokemon.Visible = false;
            button1.Visible = false;
        }
        private void FunctionButtonsVisible()
        {
            btnFight.Visible = true;
            btnBag.Visible = true;
            btnPokemon.Visible = true;
            button1.Visible = true;
        }
        private async void PokemonFlinch()
        {
            eventActive = false;
            FunctionButtonsHidden();
            await Task.Delay(2 * 1000);
            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} flinched!";
            await Task.Delay(2 * 1000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async void PokemonParalyzed()
        {
            eventActive = false;
            FunctionButtonsHidden();
            await Task.Delay(2 * 1000);
            if (enemyPokemons[enemyIndex].pokemonType == "Electric")
            {
                lblText.Text = $"Paralysis doesn't affect {enemyPokemons[enemyIndex].pokemonName}!";
            }
            else
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is paralyzed!";
                lblParalyzed2.Visible = true;
            }

            await Task.Delay(2 * 1000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async void PokemonParalyzedEnemy()
        {
            eventActive = false;
            FunctionButtonsHidden();
            await Task.Delay(2 * 1000);
            if (selectedPokemons[0].pokemonType == "Electric")
            {
                lblText.Text = $"Paralysis doesn't affect {selectedPokemons[0].pokemonName}!";
            }
            else
            {
                lblText.Text = $"{selectedPokemons[0].pokemonName} is paralyzed!";
                lblParalyzed.Visible = true;
            }
            PlayersTurn();
        }
        private async void PokemonConfused()
        {
            eventActive = false;
            FunctionButtonsHidden();
            await Task.Delay(2 * 1000);
            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is confused!";
            lblConfused2.Visible = true;
            await Task.Delay(2 * 1000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async void CriticalHitEnemy()
        {
            await Task.Delay(2 * 1000);
            playerTurn = true;
            lblText.Text = $"A critical hit!";
            await Task.Delay(2 * 1000);
            FunctionButtonsVisible();
            turnTimer.Start();
        }
        private async void CriticalHit()
        {
            eventActive = false;
            FunctionButtonsHidden();
            await Task.Delay(2 * 1000);
            lblText.Text = $"A critical hit!";
            await Task.Delay(2 * 1000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async void MoveDelayStart()
        {

            FunctionButtonsHidden();
            await Task.Delay(turnDelaySec * 1000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }

        }

        private async void PlayersTurn()
        {
            await Task.Delay(turnDelaySec * 1000);
            playerTurn = true;
            FunctionButtonsVisible();
            lblText.Text = $"What will {selectedPokemons[0].pokemonName} do?";
            turnTimer.Start();

        }

        private async Task EnemysTurn()
        {
            playerTurn = false;
            MoveButtonsHidden();
            HideBag();
            enemyMove = enemy.Next(0, 4);

            if (enemyPokemons[enemyIndex].pokemonName == "Gyarados")
            {
                if (!enemyTurnInProgress)
                {
                    enemyTurnInProgress = true;

                    if (enemyPokemons[enemyIndex].pokemonFlinch)
                    {
                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is unable to attack!";
                        enemyPokemons[enemyIndex].pokemonFlinch = false;
                    }
                    else
                    {
                        switch (enemyMove)
                        {

                            case 0:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move1Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                UpdateProgressBar();
                                PlayerPokemonFaints();
                                break;

                            case 1:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move2Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                flinchChance = flinch.Next(0, 3);
                                if (flinchChance == 0)
                                {
                                    selectedPokemons[0].pokemonFlinch = true;
                                    UpdateProgressBar();
                                }
                                PlayerPokemonFaints();
                                break;

                            case 2:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move3Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                paralysisChance = paralysis.Next(0, 3);
                                if (paralysisChance == 0)
                                {
                                    speedFell = true;
                                    selectedPokemons[0].speed = Math.Max(selectedPokemons[0].speed - 10, 0);
                                    lblParalyzed.Visible = true;
                                }
                                PlayerPokemonFaints();
                                break;

                            case 3:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move4Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                PlayerPokemonFaints();
                                break;
                        }
                    }

                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    PlayersTurn();
                }

            }
            if (enemyPokemons[enemyIndex].pokemonName == "Charizard")
            {
                if (!enemyTurnInProgress)
                {
                    enemyTurnInProgress = true;

                    if (enemyPokemons[enemyIndex].pokemonFlinch)
                    {
                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is unable to attack!";
                        enemyPokemons[enemyIndex].pokemonFlinch = false;
                    }
                    else
                    {
                        switch (enemyMove)
                        {
                            case 0:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move1Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                PlayerPokemonFaints();
                                break;

                            case 1:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move2Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                burningChance = burn.Next(0, 11);
                                if (burningChance == 5)
                                {
                                    selectedPokemons[0].pokemonBurning = true;
                                    lblBurning.Visible = true;
                                }
                                PlayerPokemonFaints();
                                break;

                            case 2:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move3Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                paralysisChance = paralysis.Next(0, 3);
                                if (paralysisChance == 0)
                                {
                                    selectedPokemons[0].pokemonParalyzed = true;
                                    selectedPokemons[0].speed = Math.Max(selectedPokemons[0].speed - 10, 0);
                                    lblParalyzed.Visible = true;
                                }
                                PlayerPokemonFaints();
                                break;

                            case 3:
                                selectedPokemons[0].move1Damage = selectedPokemons[0].move1Damage - 10;
                                selectedPokemons[0].move2Damage = selectedPokemons[0].move2Damage - 10;
                                selectedPokemons[0].move3Damage = selectedPokemons[0].move3Damage - 10;
                                selectedPokemons[0].move4Damage = selectedPokemons[0].move4Damage - 10;
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                attackFell = true;
                                PlayerPokemonFaints();
                                break;
                        }
                    }
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    PlayersTurn();
                }

            }
            if (enemyPokemons[enemyIndex].pokemonName == "Zapdos")
            {
                if (!enemyTurnInProgress)
                {
                    enemyTurnInProgress = true;

                    if (enemyPokemons[enemyIndex].pokemonFlinch)
                    {
                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is unable to attack!";
                        enemyPokemons[enemyIndex].pokemonFlinch = false;
                    }
                    else
                    {
                        switch (enemyMove)
                        {
                            case 0:
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move1Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                PlayerPokemonFaints();
                                break;

                            case 1:
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move2Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                paralysisChance = paralysis.Next(0, 11);
                                if (paralysisChance == 2)
                                {
                                    selectedPokemons[0].pokemonParalyzed = true;
                                    lblParalyzed.Visible = true;
                                    PokemonParalyzedEnemy();
                                }
                                PlayerPokemonFaints();
                                break;

                            case 2:
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                selectedPokemons[0].pokemonParalyzed = true;
                                lblParalyzed.Visible = true;
                                PokemonParalyzedEnemy();
                                PlayerPokemonFaints();
                                break;

                            case 3:
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                enemyPokemons[enemyIndex].defense = enemyPokemons[enemyIndex].defense + 10;
                                PlayerPokemonFaints();
                                break;
                        }
                    }
                   
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    PlayersTurn();
                }

            }
            if (enemyPokemons[enemyIndex].pokemonName == "Snorlax")
            {
                if (!enemyTurnInProgress)
                {
                    enemyTurnInProgress = true;

                    if (enemyPokemons[enemyIndex].pokemonFlinch)
                    {
                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is unable to attack!";
                        enemyPokemons[enemyIndex].pokemonFlinch = false;
                    }
                    else
                    {
                        switch (enemyMove)
                        {
                            case 0:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move1Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                paralysisChance = paralysis.Next(0, 3);
                                if (paralysisChance == 0)
                                {
                                    selectedPokemons[0].pokemonParalyzed = true;
                                    lblParalyzed.Visible = true;
                                }
                                PlayerPokemonFaints();
                                break;

                            case 1:
                                enemyPokemons[enemyIndex].move1Damage = Math.Max(enemyPokemons[enemyIndex].move1Damage * 2, 0);//MUOKKAA!
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - enemyPokemons[enemyIndex].pokemonStartHealth / 2, 0);
                                lblEnemyPokemonHealth.Text = $"{ enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                                enemyPokemonHealthBar.Value = Math.Min(enemyPokemons[enemyIndex].pokemonHealth / 2, enemyPokemonHealthBar.Maximum);
                                UpdateEnemyProgressBar();
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                EnemyPokemonFaints();
                                PlayerPokemonFaints();
                                break;

                            case 2:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move3Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - enemyPokemons[enemyIndex].move3Damage / 4, 0);
                                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                                UpdateEnemyProgressBar();
                                EnemyPokemonFaints();
                                PlayerPokemonFaints();
                                break;

                            case 3:
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                PlayerPokemonFaints();
                                break;
                        }
                    }                 
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    PlayersTurn();



                }

            }
            if (enemyPokemons[enemyIndex].pokemonName == "Gengar")
            {
                if (!enemyTurnInProgress)
                {
                    enemyTurnInProgress = true;

                    if (enemyPokemons[enemyIndex].pokemonFlinch)
                    {
                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is unable to attack!";
                        enemyPokemons[enemyIndex].pokemonFlinch = false;
                    }
                    else
                    {
                        switch (enemyMove)
                        {
                            case 0:
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                selectedPokemons[0].pokemonConfused = true;
                                break;

                            case 1:

                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move2Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                paralysisChance = paralysis.Next(0, 3);
                                if (paralysisChance == 0)
                                {
                                    selectedPokemons[0].pokemonParalyzed = true;
                                    lblParalyzed.Visible = true;
                                }
                                PlayerPokemonFaints();
                                break;

                            case 2:
                                sleepingChance = sleep.Next(0, 3);
                                if (sleepingChance == 0)
                                {
                                    lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                    selectedPokemons[0].pokemonSleeping = true;
                                    lblSleeping.Visible = true;
                                    PlayerPokemonFaints();
                                }
                                else
                                {
                                    lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} missed!";
                                    PlayerPokemonFaints();
                                }
                                break;

                            case 3:
                                if (selectedPokemons[0].pokemonParalyzed || selectedPokemons[0].pokemonBurning || selectedPokemons[0].pokemonSleeping || selectedPokemons[0].pokemonConfused)
                                {
                                    selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move4Damage * 2, 0);
                                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                    UpdateProgressBar();
                                    lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}, it does double damage!";
                                    PlayerPokemonFaints();
                                }
                                else
                                {
                                    selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move4Damage, 0);
                                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                    UpdateProgressBar();
                                    lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                    PlayerPokemonFaints();
                                }
                                break;
                        }
                    }                  
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    PlayersTurn();
                }

            }
            if (enemyPokemons[enemyIndex].pokemonName == "Machamp")
            {
                if (!enemyTurnInProgress)
                {
                    enemyTurnInProgress = true;

                    if (enemyPokemons[enemyIndex].pokemonFlinch)
                    {
                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is unable to attack!";
                        enemyPokemons[enemyIndex].pokemonFlinch = false;
                    }
                    else
                    {
                        switch (enemyMove)
                        {
                            case 0:
                                increasedCriticalChance = increasedCritical.Next(0, 9);
                                if (increasedCriticalChance == 0)
                                {
                                    selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move1Damage * 2, 0);
                                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                    selectedPokemons[0].pokemonCriticalHit = true;
                                    UpdateProgressBar();
                                    lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                    PlayerPokemonFaints();
                                    CriticalHitEnemy();
                                }
                                else
                                {
                                    selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move1Damage, 0);
                                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                    UpdateProgressBar();
                                    lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                    PlayerPokemonFaints();
                                }
                                break;

                            case 1:
                                usedLeer = true;
                                selectedPokemons[0].defense = Math.Max(selectedPokemons[0].defense - selectedPokemons[0].defense - 10, 0);
                                if (usedLeer)
                                {

                                }
                                PlayerPokemonFaints();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                break;

                            case 2:

                                criticalIncreased = true;
                                selectedPokemons[0].pokemonSleeping = true;

                                PlayerPokemonFaints();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                break;

                            case 3:
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move4Damage, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                lblText.Text = $"{enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move3Damage / 4, 0);
                                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                                UpdateEnemyProgressBar();
                                EnemyPokemonFaints();
                                PlayerPokemonFaints();
                                break;
                        }
                    }                  
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    PlayersTurn();
                }

            }
        }

    }
}
