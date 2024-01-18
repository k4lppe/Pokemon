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

        readonly Random Random = new Random();
        int randomChance;
        readonly Random increasedCritical = new Random();
        int increasedCriticalChance;

        readonly Random healingRandom = new Random();
        int healing;

        readonly Random confuse = new Random();
        int confuseChance;

        readonly Random flinch = new Random();
        int flinchChance;

        readonly Random sleep = new Random();
        int sleepingChance;

        readonly Random burn = new Random();
        int burningChance;

        readonly Random enemy = new Random();
        int enemyMove;

        readonly Random damageCalculation = new Random();
        double randomPercentage;

        private Timer turnTimer = new Timer();
        private int turnDelay = 5000;
        private bool playerTurn = true;
        private bool enemyTurnInProgress = false;
        private const int turnDelaySec = 2;

        int potions = 5;
        int superPotions = 3;
        int hyperPotions = 1;
        int lumBerries = 1;

        int ePotions = 5;
        int eSuperPotions = 3;
        int eHyperPotions = 1;
        int eLumBerries = 1;

        bool pokemon0Alive = true;
        bool pokemon1Alive = false;
        bool pokemon2Alive = false;

        bool ePokemon0Alive = true;
        bool ePokemon1Alive = false;
        bool ePokemon2Alive = false;

        bool usedMove1 = false;
        bool usedMove2 = false;
        bool usedMove3 = false;
        bool usedMove4 = false;

        bool enemyUsedMove1 = false;
        bool enemyUsedMove2 = false;
        bool enemyUsedMove3 = false;
        bool enemyUsedMove4 = false;

        int enemyParalysisIndex;
        int paralysisIndex;
        int confuseIndex;
        int enemyConfuseIndex;
        int sleepIndex;
        int enemySleepIndex;
        int burnIndex;
        int enemyBurnIndex;
        bool usedHex = false;
        bool usedBellyDrum = false;
        bool EnemyUsedBellyDrum = false;
        bool defenceUp = false;
        int defenceUpIndex;
        int enemyDefenceUpIndex;
        bool criticalIncreased = false;
        int critical;
        int enemyLeerIndex = 0;
        bool attackFell = false;
        int attackFellIndex;
        int enemyAttackFellIndex;
        bool usedLeer = false;
        bool speedFell = false;
        private bool enemyHasAttacked = false;
        bool usedSurf;


        private Timer gameTimer = new Timer();
        private int seconds;

        bool playerWon = false;
        bool statusEffectOn = false;
        int totalDamage;
        private int aliveEnemyPokemons;

        public Battle(List<Pokemon> selectedPokemons, string selectedPokemonImageName, List<Pokemon> enemyPokemons)
        {
            InitializeComponent();

            this.selectedPokemons = selectedPokemons;
            this.selectedPokemonImageFileName = selectedPokemonImageName;
            this.enemyPokemons = enemyPokemons;

            enemyRandomIndex = enemyRandom.Next(0, 3);
            enemyIndex = enemyRandomIndex;

            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            lblTime.Text = "Time: " + seconds;

            turnTimer.Interval = turnDelay;
            turnTimer.Tick += TurnTimer_Tick;

            if (enemyRandomIndex < enemyPokemons.Count)
            {
                string enemyImageFileName = @"C:\pokemon\pictures\" + enemyPokemons[enemyRandomIndex].ImageFileName + "2" + ".gif";
                LoadImageForEnemyPokemon(enemyImageFileName);
            }

            string imageFileName = @"C:\pokemon\pictures\" + selectedPokemons[0].ImageFileName + ".gif";
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
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            seconds++;
            lblTime.Text = "Time: " + seconds;
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
            gameTimer.Start();
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

        private void BtnDamage_Click(object sender, EventArgs e)
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
                SwitchToNextPokemon(seconds);

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

        private async void BtnDamage2_Click(object sender, EventArgs e)
        {
            enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - 20, 0);
            lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
            UpdateEnemyProgressBar();
            await EnemyPokemonFaints();
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

        private async void BtnMove1_Click(object sender, EventArgs e)
        {

            MoveButtonsHidden();
            if (playerTurn)
            {
                if (selectedPokemons[0].pokemonFlinch)
                {
                    lblText.Text = $"{selectedPokemons[0].pokemonName} is unable to attack!";
                    enemyPokemons[0].pokemonFlinch = false;
                }
                else
                {
                    confuseChance = confuse.Next(0, 3); //3
                    paralysisChance = paralysis.Next(0, 4); // 4
                    if (selectedPokemons[0].pokemonParalyzed && paralysisChance == 0)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is fully paralyzed and unable to move!";
                        await MoveDelayStart();
                    }
                    else if (selectedPokemons[0].pokemonBurning)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is badly burning and took damage from it!";
                        selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - selectedPokemons[0].pokemonStartHealth / 8, 0);
                        UpdateProgressBar();
                        await PlayerPokemonFaints();

                    }
                    else if (selectedPokemons[0].pokemonSleeping)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is fast asleep!";
                        await MoveDelayStart();
                    }
                    else if (selectedPokemons[0].pokemonConfused)
                    {
                        if (confuseChance == 0)
                        {
                            lblText.Text = $"{selectedPokemons[0].pokemonName} is confused, and hurt itself in confusion!";
                            randomChance = Random.Next(10, 21);
                            selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - randomChance, 0);
                            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                            UpdateProgressBar();
                            await PlayerPokemonFaints();
                            await MoveDelayStart();
                        }
                    }
                    else
                    {
                        usedMove1 = true;
                        lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move1}!";
                        switch (selectedPokemons[0].move1)
                        {

                            case "Dragon Rage":
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                                UpdateEnemyProgressBar();
                                FunctionButtonsHidden();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;

                            case "Dragon Claw":
                                PhysicalDamageCalculation();
                                await MoveEffectivenes();
                                FunctionButtonsHidden();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;

                            case "Drill Peck":
                                PhysicalDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();

                                break;

                            case "Body Slam":
                                PhysicalDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                if (enemyPokemons[enemyIndex].pokemonType == "Ghost")
                                {
                                    FunctionButtonsHidden();
                                    await Task.Delay(2000);
                                    lblText.Text = $"It had no effect on {enemyPokemons[enemyIndex].pokemonName}!";
                                }
                                paralysisChance = paralysis.Next(0, 3);
                                if (paralysisChance == 0)
                                {
                                    enemyPokemons[enemyIndex].pokemonParalyzed = true;
                                    await PokemonParalyzed();
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                }
                                else
                                {
                                    await MoveDelayStart();
                                }
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                break;

                            case "Confuse Ray":
                                FunctionButtonsHidden();
                                enemyPokemons[enemyIndex].pokemonConfused = true;
                                await PokemonConfusedEnemy();
                                
                                turnTimer.Start();
                                break;

                            case "Karate Chop":
                                increasedCriticalChance = increasedCritical.Next(0, 9);
                                if (increasedCriticalChance == 0)
                                {

                                    selectedPokemons[0].pokemonCriticalHit = true;
                                    PhysicalDamageCalculation();
                                    FunctionButtonsHidden();
                                    await MoveEffectivenes();
                                    await EnemyPokemonFaints();
                                    CriticalHit();
                                }
                                else
                                {
                                    PhysicalDamageCalculation();
                                    FunctionButtonsHidden();
                                    await MoveEffectivenes();
                                    await EnemyPokemonFaints();
                                    await MoveDelayStart();
                                }
                                turnTimer.Start();
                                break;
                        }
                    }
                }




            }

        }

        private async void BtnMove2_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            if (playerTurn)
            {
                if (selectedPokemons[0].pokemonFlinch)
                {
                    lblText.Text = $"{selectedPokemons[0].pokemonName} is unable to attack!";
                    enemyPokemons[0].pokemonFlinch = false;
                }
                else
                {
                    confuseChance = confuse.Next(0, 3); //3
                    paralysisChance = paralysis.Next(0, 4); // 4
                    if (selectedPokemons[0].pokemonParalyzed && paralysisChance == 0)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is fully paralyzed and unable to move!";
                        await MoveDelayStart();
                    }
                    else if (selectedPokemons[0].pokemonBurning)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is badly burning and took damage from it!";
                        selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - selectedPokemons[0].pokemonStartHealth / 8, 0);
                        UpdateProgressBar();
                        await PlayerPokemonFaints();

                    }
                    else if (selectedPokemons[0].pokemonSleeping)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is fast asleep!";
                        await MoveDelayStart();
                    }
                    else if (selectedPokemons[0].pokemonConfused)
                    {
                        if (confuseChance == 0)
                        {
                            lblText.Text = $"{selectedPokemons[0].pokemonName} is confused, and hurt itself in confusion!";
                            randomChance = Random.Next(10, 21);
                            selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - randomChance, 0);
                            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                            UpdateProgressBar();
                            await PlayerPokemonFaints();
                            await MoveDelayStart();
                        }

                    }
                    else
                    {
                        usedMove2 = true;
                        lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move2}!";
                        switch (selectedPokemons[0].move2)
                        {
                            case "Bite":
                                PhysicalDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                flinchChance = flinch.Next(0, 3);
                                if (flinchChance == 0)
                                {
                                    enemyPokemons[enemyIndex].pokemonFlinch = true;
                                    UpdateEnemyProgressBar();
                                    await MoveEffectivenes();
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    await PokemonFlinch();
                                }
                                else
                                {
                                    await MoveEffectivenes();
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    await MoveDelayStart();
                                }
                                break;

                            case "Ember":
                                SpecialDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                burningChance = burn.Next(0, 10);
                                if (burningChance == 0)
                                {
                                    enemyPokemons[enemyIndex].pokemonBurning = true;
                                    lblBurning2.Visible = true;
                                }
                                await EnemyPokemonStatusCondition();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();

                                break;

                            case "Thunder Shock":
                                SpecialDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                paralysisChance = paralysis.Next(0, 10);
                                if (paralysisChance == 0)
                                {
                                    enemyPokemons[enemyIndex].pokemonParalyzed = true;
                                    lblParalyzed2.Visible = true;
                                }
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;

                            case "Belly Drum":
                                if (selectedPokemons[0].pokemonHealth > selectedPokemons[0].pokemonStartHealth / 2)
                                {
                                    usedBellyDrum = true;
                                    FunctionButtonsHidden();
                                    selectedPokemons[0].attack += 30;
                                    selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - selectedPokemons[0].pokemonStartHealth / 2, 0);
                                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                    playerPokemonHealthBar.Value = Math.Min(selectedPokemons[0].pokemonHealth / 2, playerPokemonHealthBar.Maximum);
                                    UpdateProgressBar();
                                    UpdateEnemyProgressBar();
                                    await MoveEffectivenes();
                                    await EnemyPokemonFaints();
                                    await PlayerPokemonFaints();
                                    turnTimer.Start();
                                }
                                else
                                {
                                    FunctionButtonsHidden();
                                    await Task.Delay(3000);
                                    lblText.Text = $"{selectedPokemons[0].move2} failed!";
                                    await EnemyPokemonFaints();
                                    await Task.Delay(2000);
                                    turnTimer.Start();
                                }
                                await MoveDelayStart();
                                break;

                            case "Lick":
                                PhysicalDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                paralysisChance = paralysis.Next(0, 3);
                                if (paralysisChance == 0)
                                {
                                    enemyPokemons[enemyIndex].pokemonParalyzed = true;
                                    lblParalyzed2.Visible = true;
                                }
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;

                            case "Leer":
                                enemyPokemons[enemyIndex].defense = Math.Max(enemyPokemons[enemyIndex].defense - enemyPokemons[enemyIndex].defense - 10, 0);
                                FunctionButtonsHidden();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                EnemyDefenceFell();
                                break;
                        }
                    }
                }
            }
        }
        private async void BtnMove3_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            if (playerTurn)
            {
                if (selectedPokemons[0].pokemonFlinch)
                {
                    lblText.Text = $"{selectedPokemons[0].pokemonName} is unable to attack!";
                    enemyPokemons[0].pokemonFlinch = false;
                }
                else
                {
                    confuseChance = confuse.Next(0, 3); //3
                    paralysisChance = paralysis.Next(0, 4); // 4
                    if (selectedPokemons[0].pokemonParalyzed && paralysisChance == 0)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is fully paralyzed and unable to move!";
                        await MoveDelayStart();
                    }
                    else if (selectedPokemons[0].pokemonBurning)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is badly burning and took damage from it!";
                        selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - selectedPokemons[0].pokemonStartHealth / 8, 0);
                        UpdateProgressBar();
                        await PlayerPokemonFaints();

                    }
                    else if (selectedPokemons[0].pokemonSleeping)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is fast asleep!";
                        await MoveDelayStart();
                    }
                    else if (selectedPokemons[0].pokemonConfused)
                    {
                        if (confuseChance == 0)
                        {
                            lblText.Text = $"{selectedPokemons[0].pokemonName} is confused, and hurt itself in confusion!";
                            randomChance = Random.Next(10, 21);
                            selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - randomChance, 0);
                            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                            UpdateProgressBar();
                            await PlayerPokemonFaints();
                            await MoveDelayStart();
                        }

                    }
                    else
                    {
                        usedMove3 = true;
                        lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move3}!";
                        switch (selectedPokemons[0].move3)
                        {
                            case "Bubblebeam":
                                SpecialDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;

                            case "Dragon Breath":
                                SpecialDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                paralysisChance = paralysis.Next(0, 3);
                                if (paralysisChance == 0)
                                {
                                    enemyPokemons[enemyIndex].pokemonParalyzed = true;
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    await PokemonParalyzed();
                                }
                                else
                                {
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    await MoveDelayStart();
                                }
                                break;

                            case "Thunder Wave":
                                enemyPokemons[enemyIndex].pokemonParalyzed = true;
                                FunctionButtonsHidden();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await PokemonParalyzed();
                                break;

                            case "Double-Edge":
                                PhysicalDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - calculatedDamage / 3, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                await EnemyPokemonFaints();
                                await PlayerPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;

                            case "Hypnosis":
                                sleepingChance = sleep.Next(0, 3);
                                FunctionButtonsHidden();
                                if (sleepingChance == 0)
                                {
                                    enemyPokemons[enemyIndex].pokemonSleeping = true;
                                    lblSleeping2.Visible = true;
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    await PokemonSleepingEnemy();
                                }
                                else
                                {
                                    lblText.Text = $"{selectedPokemons[0].pokemonName} missed!";
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    await MoveDelayStart();
                                }
                                break;

                            case "Focus Energy":
                                criticalIncreased = true;
                                FunctionButtonsHidden();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;
                        }
                    }

                }

            }
        }
        private async void BtnMove4_Click(object sender, EventArgs e)
        {
            MoveButtonsHidden();
            if (playerTurn)
            {
                if (selectedPokemons[0].pokemonFlinch)
                {
                    lblText.Text = $"{selectedPokemons[0].pokemonName} is unable to attack!";
                    enemyPokemons[0].pokemonFlinch = false;
                }
                else
                {
                    confuseChance = confuse.Next(0, 3); //3
                    paralysisChance = paralysis.Next(0, 4); // 4
                    if (selectedPokemons[0].pokemonParalyzed && paralysisChance == 0)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is fully paralyzed and unable to move!";
                        await MoveDelayStart();
                    }
                    else if (selectedPokemons[0].pokemonBurning)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is badly burning and took damage from it!";
                        selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - selectedPokemons[0].pokemonStartHealth / 8, 0);
                        UpdateProgressBar();
                        await PlayerPokemonFaints();

                    }
                    else if (selectedPokemons[0].pokemonSleeping)
                    {
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is fast asleep!";
                        await MoveDelayStart();
                    }
                    else if (selectedPokemons[0].pokemonConfused)
                    {
                        if (confuseChance == 0)
                        {
                            lblText.Text = $"{selectedPokemons[0].pokemonName} is confused, and hurt itself in confusion!";
                            randomChance = Random.Next(10, 21);
                            selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - randomChance, 0);
                            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                            UpdateProgressBar();
                            await PlayerPokemonFaints();
                            await MoveDelayStart();
                        }

                    }
                    else
                    {
                        usedMove4 = true;
                        lblText.Text = $"{selectedPokemons[0].pokemonName} used {selectedPokemons[0].move4}!";
                        switch (selectedPokemons[0].move4)
                        {
                            case "Hydro Pump":
                                SpecialDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;

                            case "Growl":
                                FunctionButtonsHidden();
                                if (attackFellIndex >= 3)
                                {
                                    await Task.Delay(2000);
                                    lblText.Text = $"{selectedPokemons[0].move4} failed!";
                                    await EnemyPokemonStatusCondition();
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    await MoveDelayStart();
                                }
                                else
                                {
                                    enemyPokemons[enemyIndex].move1Damage = enemyPokemons[enemyIndex].move1Damage - 10;
                                    enemyPokemons[enemyIndex].move2Damage = enemyPokemons[enemyIndex].move2Damage - 10;
                                    enemyPokemons[enemyIndex].move3Damage = enemyPokemons[enemyIndex].move3Damage - 10;
                                    enemyPokemons[enemyIndex].move4Damage = enemyPokemons[enemyIndex].move4Damage - 10;
                                    if (enemyPokemons[enemyIndex].move1Damage < 10 || enemyPokemons[enemyIndex].move2Damage < 10 || enemyPokemons[enemyIndex].move3Damage < 10 || enemyPokemons[enemyIndex].move4Damage < 10)
                                    {
                                        enemyPokemons[enemyIndex].move1Damage += 10;
                                    }
                                    attackFell = true;
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    EnemyAttackFell();
                                    attackFellIndex++;
                                }
                                break;

                            case "Charge":
                                FunctionButtonsHidden();
                                if (defenceUpIndex >= 3)
                                {
                                    await Task.Delay(2000);
                                    lblText.Text = $"{selectedPokemons[0].move4} failed!";
                                }
                                else
                                {
                                    FunctionButtonsHidden();
                                    selectedPokemons[0].specialDefence += 10;
                                    await Task.Delay(3000);
                                    lblText.Text = $"It rose it's Special Defence!";

                                    defenceUpIndex++;
                                }
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;

                            case "Surf":
                                usedSurf = true;
                                SpecialDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                await EnemyPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;


                            case "Hex":
                                FunctionButtonsHidden();
                                if (enemyPokemons[enemyIndex].pokemonParalyzed || enemyPokemons[enemyIndex].pokemonBurning || enemyPokemons[enemyIndex].pokemonSleeping || enemyPokemons[enemyIndex].pokemonConfused)
                                {
                                    usedHex = true;
                                    SpecialDamageCalculation();
                                    await MoveEffectivenes();
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    await MoveDelayStart();
                                }
                                else
                                {
                                    
                                    SpecialDamageCalculation();
                                    await MoveEffectivenes();
                                    await EnemyPokemonFaints();
                                    turnTimer.Start();
                                    await MoveDelayStart();
                                }
                                break;

                            case "Submission":
                                PhysicalDamageCalculation();
                                FunctionButtonsHidden();
                                await MoveEffectivenes();
                                playerPokemonHealthBar.Value = Math.Max(playerPokemonHealthBar.Value - calculatedDamage / 4, 0);
                                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                UpdateProgressBar();
                                await EnemyPokemonFaints();
                                await PlayerPokemonFaints();
                                turnTimer.Start();
                                await MoveDelayStart();
                                break;
                        }
                    }

                }

            }
        }
        private void TurnTimer_Tick(object sender, EventArgs e)
        {
            turnTimer.Tick -= TurnTimer_Tick;
            turnTimer.Interval = turnDelaySec * 1000;
            turnTimer.Start();

        }

        private async Task EnemyPokemonFaints()
        {
            if (enemyPokemons[enemyIndex].pokemonHealth <= 0)
            {
                enemyTurnInProgress = true;
                await Task.Delay(3000);
                ePokemon1Alive = true;
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} fainted!";
                FunctionButtonsHidden();
                HideBag();
                MoveButtonsHidden();
                criticalIncreased = false;
                enemyPokemons[enemyIndex].move1Damage = enemyPokemons[enemyIndex].startMove1Damage;
                enemyPokemons[enemyIndex].move2Damage = enemyPokemons[enemyIndex].startMove2Damage;
                enemyPokemons[enemyIndex].move3Damage = enemyPokemons[enemyIndex].startMove3Damage;
                enemyPokemons[enemyIndex].move4Damage = enemyPokemons[enemyIndex].startMove4Damage;
                RestoreEnemyPokemonCondition();
                selectedPokemons[0].defense = selectedPokemons[0].defense;
                if (enemyPokemons.Count > 0)
                {
                    EnemySwitchToNextPokemon(seconds);
                    await Task.Delay(2000);
                    lblText.Text = $"Enemy sent out {enemyPokemons[enemyIndex].pokemonName}!";
                }
                enemyTurnInProgress = false;
                await Task.Delay(4000);
                await PlayersTurn();
            }
        }
        private async Task PlayerPokemonFaints()
        {
            if (selectedPokemons[0].pokemonHealth <= 0)
            {
                enemyTurnInProgress = true;
                await Task.Delay(3000);
                pokemon1Alive = true;
                lblText.Text = $"{selectedPokemons[0].pokemonName} fainted!";
                FunctionButtonsHidden();
                HideBag();
                MoveButtonsHidden();
                criticalIncreased = false;
                attackFellIndex = 0;
                selectedPokemons[0].move1Damage = selectedPokemons[0].startMove1Damage;
                selectedPokemons[0].move2Damage = selectedPokemons[0].startMove2Damage;
                selectedPokemons[0].move3Damage = selectedPokemons[0].startMove3Damage;
                selectedPokemons[0].move4Damage = selectedPokemons[0].startMove4Damage;
                RestorePokemonsCondition();
                selectedPokemons[0].defense = selectedPokemons[0].startDefence;
                selectedPokemons[0].specialDefence = selectedPokemons[0].startSpecialDefence;
                if (usedBellyDrum)
                {
                    selectedPokemons[0].attack -= 30;
                }
                if (selectedPokemons.Count > 0)
                {
                    SwitchToNextPokemon(seconds);
                    await Task.Delay(3000);
                    lblText.Text = $"Player sent out {selectedPokemons[0].pokemonName}!";
                }
                enemyTurnInProgress = false;
                await Task.Delay(4000);
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

        private async void BtnPotion_Click(object sender, EventArgs e)
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
                    await MoveDelayStart();
                    turnTimer.Start();
                }
            }
            else
            {
                HideBag();
                lblText.Text = $"You're all out of Potions!";
            }
        }
        private async void BtnSPotion_Click(object sender, EventArgs e)
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
                    await MoveDelayStart();
                    turnTimer.Start();
                }
            }
            else
            {
                HideBag();
                lblText.Text = $"You're all out of Super Potions!";
            }

        }

        private async void BtnHPotion_Click(object sender, EventArgs e)
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
                    lblText.Text = $"Used Hyper Potion on {selectedPokemons[0].pokemonName}!";
                    selectedPokemons[0].pokemonHealth = Math.Min(selectedPokemons[0].pokemonHealth + 200, selectedPokemons[0].pokemonStartHealth);
                    UpdateProgressBar();
                    lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                    hyperPotions--;
                    btnHPotion.Text = $"Hyper Potions x{hyperPotions}";
                    await MoveDelayStart();
                    turnTimer.Start();
                }
            }
            else
            {
                HideBag();
                lblText.Text = $"You're all out of Hyper Potions!";
            }
        }
        private void SwitchToNextPokemon(int time)
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
                string imageFileName = @"C:\pokemon\pictures\" + selectedPokemons[0].ImageFileName + ".gif";
                LoadImageForSelectedPokemon(imageFileName);
                lblPlayerPokemonName.Text = $"{selectedPokemons[0].pokemonName}";
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();
            }
            else
            {
                gameTimer.Stop();
                lblText.Text = $"You Lost! Check the final summary form to see results!";
                OpenFinalSummary(time, totalDamage, playerWon);
            }

        }

        private void EnemySwitchToNextPokemon(int time)
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
                playerWon = true;
                gameTimer.Stop();
                lblText.Text = "You Won! Check the final summary form to see results!";
                OpenFinalSummary(time, totalDamage, playerWon);
            }
        }
        private void OpenFinalSummary(int time, int totalDamage, bool playerWon)
        {
            FinalSummary finalSummary = new FinalSummary(time, totalDamage, playerWon);
            finalSummary.ShowDialog();
            this.Close();

        }
        private void LoadEnemyPokemonData()
        {
            enemyPokemonHealthBar.Maximum = enemyPokemons[enemyIndex].pokemonStartHealth;
            enemyPokemonHealthBar.Value = Math.Min(enemyPokemons[enemyIndex].pokemonHealth, enemyPokemonHealthBar.Maximum);
            string enemyImageFileName = @"C:\pokemon\pictures\" + enemyPokemons[enemyIndex].ImageFileName + "2" + ".gif";
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
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
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
                    lblInfo.Text = "Confuse Ray causes the target to become confused. Confused Pokémon have a 50% chance of hurting themselves each turn, for 1-4 attacking turns. The damage received is as if the Pokémon attacks itself with a typeless 40 base power Physical attack.";
                    break;

                case "Karate Chop":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Karate Chop deals damage and has an increased critical hit ratio (1/8 instead of 1/16).";
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
                    lblInfo.Text = "User loses 50% of its max HP, but Attack doubles. It fails if the user's current HP is less than half its maxium.";
                    break;

                case "Lick":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Lick deals damage and has a 30% chance of paralyzing the target. Paralyzed Pokémon have a 25% chance of not being able to attack. It doesn't affect Electric-type Pokémons.";
                    break;

                case "Leer":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
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
                    lblInfo.Text = "Double-Edge deals a lot of damage, but the user receives 1⁄3 of the damage it inflicted in recoil.";
                    break;

                case "Hypnosis":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Hypnosis puts the target to sleep, but it has 1/3 chance of missing. Sleeping Pokémon cannot move. Sleep lasts for 1-3 turns.";
                    break;

                case "Focus Energy":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
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
                    lblInfo.Text = "Growl lowers the target's Attack by 10. It can be used 3 times.";
                    break;

                case "Charge":
                    lblInfo.Size = new Size(500, 190);
                    lblInfo.Location = new System.Drawing.Point(9, 300);
                    lblInfo.Text = "Charge raises the user's Special Defense by 10, and if this Pokémon's next move is a damage-dealing Electric-type attack, it will deal double damage. It can be used 3 times.";
                    break;

                case "Surf":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
                    lblInfo.Text = "Surf deals damage with no additional effect.";
                    break;

                case "Hex":
                    lblInfo.Text = "Hex inflicts damage, but if the target has a major status ailment (burned, poisoned, paralyzed, asleep or frozen) it will double in power to 130.";
                    break;

                case "Submission":
                    lblInfo.Size = new Size(504, 108);
                    lblInfo.Location = new System.Drawing.Point(9, 373);
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
            lblInfo.Size = new Size(504, 108);
            lblInfo.Location = new System.Drawing.Point(9, 373);
            lblInfo.Text = "Potion heals its user by 20 HP";
        }

        private void BtnPotion_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void BtnSPotion_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Size = new Size(504, 108);
            lblInfo.Location = new System.Drawing.Point(9, 373);
            lblInfo.Text = "Super Potion heals its user by 50 HP";
        }

        private void BtnSPotion_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private void BtnHPotion_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Size = new Size(504, 108);
            lblInfo.Location = new System.Drawing.Point(9, 373);
            lblInfo.Text = "Hyper Potion heals its user by 200 HP";
        }

        private void BtnHPotion_MouseLeave(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
        }

        private async void BtnLumberry_Click(object sender, EventArgs e)
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
                    await MoveDelayStart();
                    turnTimer.Start();
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
            lblSleeping.Visible = false;
            selectedPokemons[0].pokemonParalyzed = false;
            lblParalyzed.Visible = false;
            selectedPokemons[0].pokemonBurning = false;
            lblBurning.Visible = false;
            selectedPokemons[0].pokemonConfused = false;
            lblConfused.Visible = false;

        }
        private void RestoreEnemyPokemonCondition()
        {
            enemyPokemons[enemyIndex].pokemonSleeping = false;
            lblSleeping2.Visible = false;
            enemyPokemons[enemyIndex].pokemonParalyzed = false;
            lblParalyzed2.Visible = false;
            enemyPokemons[enemyIndex].pokemonBurning = false;
            lblBurning2.Visible = false;
            enemyPokemons[enemyIndex].pokemonConfused = false;
            lblConfused2.Visible = false;
        }

        private void BtnLumberry_MouseHover(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblInfo.Size = new Size(504, 108);
            lblInfo.Location = new System.Drawing.Point(9, 373);
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
        }
        private void FunctionButtonsVisible()
        {
            btnFight.Visible = true;
            btnBag.Visible = true;
        }
        private async Task PokemonFlinch()
        {
            FunctionButtonsHidden();
            await Task.Delay(2000);
            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} flinched!";
            await Task.Delay(2000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async Task PokemonParalyzed()
        {
            paralysisChance = paralysis.Next(0, 4);
            paralysisIndex = paralysisChance;
            statusEffectOn = true;
            FunctionButtonsHidden();
            await Task.Delay(2000);
            if (enemyPokemons[enemyIndex].pokemonType == "Electric")
            {
                lblParalyzed2.Visible = false;
                lblText.Text = $"Paralysis doesn't affect {enemyPokemons[enemyIndex].pokemonName}!";
                enemyPokemons[enemyIndex].pokemonParalyzed = false;
            }
            else
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is paralyzed!";
                lblParalyzed2.Visible = true;
            }

            await Task.Delay(2000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async Task PokemonParalyzedEnemy()
        {
            paralysisChance = paralysis.Next(0, 4);
            enemyParalysisIndex = paralysisChance;
            statusEffectOn = true;
            FunctionButtonsHidden();
            await Task.Delay(3000);
            if (selectedPokemons[0].pokemonType == "Electric")
            {
                lblText.Text = $"Paralysis doesn't affect {selectedPokemons[0].pokemonName}!";
                selectedPokemons[0].pokemonParalyzed = false;
                lblParalyzed.Visible = false;
            }
            else
            {
                lblText.Text = $"{selectedPokemons[0].pokemonName} is paralyzed!";
                lblParalyzed.Visible = true;
            }
            await Task.Delay(3000);
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }

        }
        private async Task PokemonSleepingEnemy()
        {
            sleepingChance = sleep.Next(1, 7);
            enemySleepIndex = sleepingChance;
            FunctionButtonsHidden();
            await Task.Delay(3000);
            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} fell asleep!";
            lblSleeping2.Visible = true;
            await Task.Delay(2000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async Task PokemonSleeping()
        {
            sleepingChance = sleep.Next(1, 7);
            sleepIndex = sleepingChance;
            FunctionButtonsHidden();
            await Task.Delay(3000);
            lblText.Text = $"{selectedPokemons[0].pokemonName} fell asleep!";
            lblSleeping.Visible = true;
            await Task.Delay(2000);
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async Task PokemonConfusedEnemy()
        {
            confuseChance = confuse.Next(2, 5);
            enemyConfuseIndex = confuseChance;
            statusEffectOn = true;
            FunctionButtonsHidden();
            await Task.Delay(2000);
            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is confused!";
            lblConfused2.Visible = true;
            await Task.Delay(2000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async Task EnemyHealing()
        {
            if (enemyPokemons[enemyIndex].pokemonSleeping)
            {
                healing = healingRandom.Next(0, 4); //4
            }
            else
            {
                healing = healingRandom.Next(0, 6); //6       
            }


            if (healing == 0 && enemyPokemons[enemyIndex].pokemonHealth < enemyPokemons[enemyIndex].pokemonStartHealth - 20 && enemyPokemons[enemyIndex].pokemonHealth > enemyPokemons[enemyIndex].pokemonStartHealth - 49 && ePotions > 0 && enemyPokemons[enemyIndex].pokemonSleeping == false && enemyPokemons[enemyIndex].pokemonBurning == false)
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used Potion!";
                enemyPokemons[enemyIndex].pokemonHealth = Math.Min(enemyPokemons[enemyIndex].pokemonHealth + 20, enemyPokemons[enemyIndex].pokemonStartHealth);
                UpdateEnemyProgressBar();
                await Task.Delay(3000);
                ePotions--;
                await PlayersTurn();
                turnTimer.Start();
            }
            else if (healing == 0 && enemyPokemons[enemyIndex].pokemonHealth < enemyPokemons[enemyIndex].pokemonStartHealth - 50 && enemyPokemons[enemyIndex].pokemonHealth > enemyPokemons[enemyIndex].pokemonStartHealth * 0.3 && eSuperPotions > 0 && enemyPokemons[enemyIndex].pokemonSleeping == false && enemyPokemons[enemyIndex].pokemonBurning == false)
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used Super Potion!";
                enemyPokemons[enemyIndex].pokemonHealth = Math.Min(enemyPokemons[enemyIndex].pokemonHealth + 50, enemyPokemons[enemyIndex].pokemonStartHealth);
                UpdateEnemyProgressBar();
                await Task.Delay(3000);
                eSuperPotions--;
                await PlayersTurn();
                turnTimer.Start();
            }
            else if (healing == 0 && enemyPokemons[enemyIndex].pokemonHealth <= 0.3 * enemyPokemons[enemyIndex].pokemonStartHealth && eHyperPotions > 0 && enemyPokemons[enemyIndex].pokemonSleeping == false && enemyPokemons[enemyIndex].pokemonBurning == false)
            {
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used Hyper Potion!";
                enemyPokemons[enemyIndex].pokemonHealth = Math.Min(enemyPokemons[enemyIndex].pokemonHealth + 200, enemyPokemons[enemyIndex].pokemonStartHealth);
                UpdateEnemyProgressBar();
                await Task.Delay(3000);
                eHyperPotions--;
                await PlayersTurn();
                turnTimer.Start();
            }
            else if (enemyPokemons[enemyIndex].pokemonBurning || enemyPokemons[enemyIndex].pokemonConfused || enemyPokemons[enemyIndex].pokemonParalyzed || enemyPokemons[enemyIndex].pokemonSleeping)
            {
                if (healing == 0)
                {
                    if (eLumBerries > 0)
                    {
                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used Lum Berry!";
                        if (enemyPokemons[enemyIndex].pokemonSleeping)
                        {
                            lblSleeping2.Visible = false;
                            await Task.Delay(3000);
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} woke up!";
                        }
                        RestoreEnemyPokemonCondition();
                        await Task.Delay(3000);
                        eLumBerries--;
                        await PlayersTurn();
                        turnTimer.Start();
                    }

                }

            }
            else if (ePotions <= 0)
            {

            }
            else if (eSuperPotions <= 0)
            {

            }
            else if (eHyperPotions <= 0)
            {

            }
            else if (eLumBerries <= 0)
            {

            }
        }
        private async void CriticalHitEnemy()
        {
            await Task.Delay(2000);
            playerTurn = true;
            lblText.Text = $"A critical hit!";
            await Task.Delay(2000);
            turnTimer.Start();
        }
        private async void CriticalHit()
        {
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
        private async void EnemyDefenceFell()
        {
            FunctionButtonsHidden();
            await Task.Delay(2000);
            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} defence fell!";
            await Task.Delay(2000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }
        }
        private async void EnemyAttackFell()
        {
            FunctionButtonsHidden();
            if (attackFell)
            {
                await Task.Delay(2000);
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} attack fell!";

                if (enemyPokemons[enemyIndex].pokemonBurning)
                {
                    await EnemyPokemonStatusCondition();

                }
                attackFell = false;
            }
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await Task.Delay(3000);
                await EnemysTurn();
            }
        }
        private async void PlayerAttackFell()
        {
            if (attackFell)
            {
                await Task.Delay(2000);
                lblText.Text = $"{selectedPokemons[0].pokemonName}'s attack fell!";
                await Task.Delay(2000);
                attackFell = false;
            }

        }
        private async Task MoveEffectivenes()
        {
            FunctionButtonsHidden();
            if (calculatedDamage >= 60)
            {
                await Task.Delay(3000);
                lblText.Text = $"It's super effective!";
            }
            else if (calculatedDamage <= 30 && calculatedDamage >= 1)
            {
                await Task.Delay(3000);
                lblText.Text = $"It's not very effective.";
            }
            else if (calculatedDamage <= 0)
            {
                await Task.Delay(3000);
                lblText.Text = "It had no effect!";
            }
        }

        private async Task MoveDelayStart()
        {

            FunctionButtonsHidden();
            await Task.Delay(4000);
            enemyHasAttacked = false;
            if (!enemyHasAttacked)
            {
                await EnemysTurn();
            }



        }
        private async Task EnemyPokemonStatusCondition()
        {
            if (enemyPokemons[enemyIndex].pokemonBurning)
            {
                await Task.Delay(3000);
                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is badly burning and took damage from it!";
                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - enemyPokemons[enemyIndex].pokemonStartHealth / 8, 0);
                UpdateEnemyProgressBar();
                await EnemyPokemonFaints();

            }

        }
        private async Task PlayersTurn()
        {
            if (selectedPokemons.Count <= 0)
            {

            }
            else
            {
                if (selectedPokemons[0].pokemonParalyzed)
                {
                    lblParalyzed.Visible = true;
                    selectedPokemons[0].pokemonSleeping = false;
                    lblSleeping.Visible = false;
                    selectedPokemons[0].pokemonBurning = false;
                    lblBurning.Visible = false;
                    selectedPokemons[0].pokemonConfused = false;
                    lblConfused.Visible = false;
                    paralysisIndex++;
                    if (paralysisIndex >= 5)
                    {
                        paralysisIndex = 0;
                        selectedPokemons[0].pokemonParalyzed = false;
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is no longer paralyzed!";
                        lblParalyzed.Visible = false;

                    }

                }
                else if (selectedPokemons[0].pokemonConfused)
                {
                    lblConfused.Visible = true;
                    selectedPokemons[0].pokemonSleeping = false;
                    lblSleeping.Visible = false;
                    selectedPokemons[0].pokemonBurning = false;
                    lblBurning.Visible = false;
                    selectedPokemons[0].pokemonParalyzed = false;
                    lblParalyzed.Visible = false;
                    confuseIndex++;
                    if (confuseIndex >= 6)
                    {
                        confuseIndex = 0;
                        selectedPokemons[0].pokemonConfused = false;
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} is no longer confused!";
                        lblConfused.Visible = false;

                    }
                }
                else if (selectedPokemons[0].pokemonSleeping)
                {
                    lblSleeping.Visible = true;
                    selectedPokemons[0].pokemonConfused = false;
                    lblConfused.Visible = false;
                    selectedPokemons[0].pokemonBurning = false;
                    lblBurning.Visible = false;
                    selectedPokemons[0].pokemonParalyzed = false;
                    lblParalyzed.Visible = false;

                    sleepIndex++;
                    if (sleepIndex >= 8)
                    {
                        sleepIndex = 0;
                        await Task.Delay(2000);
                        lblText.Text = $"{selectedPokemons[0].pokemonName} woke up!";
                        lblSleeping.Visible = false;
                    }
                }
                else if (selectedPokemons[0].pokemonBurning)
                {
                    lblBurning.Visible = true;
                    selectedPokemons[0].pokemonConfused = false;
                    lblSleeping.Visible = false;
                    selectedPokemons[0].pokemonSleeping = false;
                    lblSleeping.Visible = false;
                    selectedPokemons[0].pokemonParalyzed = false;
                    lblParalyzed.Visible = false;

                }

                await Task.Delay(turnDelaySec * 1000);
                playerTurn = true;
                FunctionButtonsVisible();
                lblText.Text = $"What will {selectedPokemons[0].pokemonName} do?";
                FunctionButtonsVisible();
                //turnTimer.Start();
            }

        }
        double type1;
        double type2 = 1.0;
        int calculatedDamage;
        private void PhysicalDamageCalculation()
        {
            switch (enemyPokemons[enemyIndex].pokemonType)
            {
                case "Water":
                    if (selectedPokemons[0].pokemonType == "Fire")
                    {
                        type1 = 0.5;
                    }
                    else if (selectedPokemons[0].pokemonType == "Electric")
                    {
                        type1 = 2.0;
                    }
                    else if (selectedPokemons[0].pokemonType == "Normal" || selectedPokemons[0].pokemonType == "Ghost" || selectedPokemons[0].pokemonType == "Fighting")
                    {
                        type1 = 1.0;
                    }
                    break;

                case "Fire":
                    if (selectedPokemons[0].pokemonType == "Water")
                    {
                        type1 = 2.0;
                    }
                    else if (selectedPokemons[0].pokemonType == "Electric" || selectedPokemons[0].pokemonType == "Normal" || selectedPokemons[0].pokemonType == "Ghost" || selectedPokemons[0].pokemonType == "Fighting")
                    {
                        type1 = 1.0;
                    }
                    break;

                case "Electric":
                    type1 = 1.0;
                    break;

                case "Normal":
                    if (selectedPokemons[0].pokemonType == "Water" || selectedPokemons[0].pokemonType == "Fire" || selectedPokemons[0].pokemonType == "Electric")
                    {
                        type1 = 1.0;
                    }
                    else if (selectedPokemons[0].pokemonType == "Ghost")
                    {
                        type1 = 0;
                    }
                    else if (selectedPokemons[0].pokemonType == "Fighting")
                    {
                        type1 = 2.0;
                    }
                    break;

                case "Ghost":
                    if (selectedPokemons[0].pokemonType == "Water" || selectedPokemons[0].pokemonType == "Fire" || selectedPokemons[0].pokemonType == "Electric")
                    {
                        type1 = 1.0;
                    }
                    else if (selectedPokemons[0].pokemonType == "Normal" || selectedPokemons[0].pokemonType == "Fighting")
                    {
                        type1 = 0;
                    }
                    break;

                case "Fighting":
                    type1 = 1;
                    break;

            }
            if (selectedPokemons[0].pokemonCriticalHit)
            {
                critical = 2;
                selectedPokemons[0].pokemonCriticalHit = false;
            }
            else
            {
                if (criticalIncreased)
                {
                    increasedCriticalChance = increasedCritical.Next(0, 5);
                    if (increasedCriticalChance == 0)
                    {
                        critical = 2;
                    }
                    else
                    {
                        critical = 1;
                    }
                    criticalIncreased = false;
                }
                else
                {
                    increasedCriticalChance = increasedCritical.Next(1, 17);
                    if (increasedCriticalChance == 16)
                    {
                        critical = 2;
                    }
                    else
                    {
                        critical = 1;
                    }
                }
            }

            if (usedMove1)
            {

                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double pokemonMove1Damage = (int)(((((2 * 50 * critical) / 5 + 2) * selectedPokemons[0].move1Damage * (selectedPokemons[0].attack / enemyPokemons[enemyIndex].defense) / 50) + 2) * type1 * type2 * randomPercentage);
                selectedPokemons[0].move1Damage = Convert.ToInt32(pokemonMove1Damage);
                calculatedDamage = Convert.ToInt32(pokemonMove1Damage);
                if (selectedPokemons[0].pokemonBurning)
                {
                    selectedPokemons[0].move1Damage = selectedPokemons[0].move1Damage / 2;
                }
                if (selectedPokemons[0].move1Damage < 10 && selectedPokemons[0].pokemonBurning == false && type1 == 1.0 || type1 == 2.0)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    selectedPokemons[0].move1Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(pokemonMove1Damage);

                }
                else if (selectedPokemons[0].move1Damage < 10 && selectedPokemons[0].pokemonBurning == false && type1 == 0.5)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 15 * randomPercentage;
                    selectedPokemons[0].move1Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(pokemonMove1Damage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(pokemonMove1Damage);
                }
                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";

                UpdateEnemyProgressBar();
                lblDamageText.Text = $"Damage: {selectedPokemons[0].move1Damage}";
                totalDamage = totalDamage + selectedPokemons[0].move1Damage;
                selectedPokemons[0].move1Damage = selectedPokemons[0].startMove1Damage;

                usedMove1 = false;
            }
            else if (usedMove2)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double pokemonMove2Damage = (int)(((((2 * 50 * critical) / 5 + 2) * selectedPokemons[0].move2Damage * (selectedPokemons[0].attack / enemyPokemons[enemyIndex].defense) / 50) + 2) * type1 * type2 * randomPercentage);
                selectedPokemons[0].move2Damage = Convert.ToInt32(pokemonMove2Damage);

                if (selectedPokemons[0].pokemonBurning)
                {
                    selectedPokemons[0].move2Damage = selectedPokemons[0].move2Damage / 2;
                }
                if (selectedPokemons[0].move2Damage < 10 && selectedPokemons[0].pokemonBurning == false && type1 == 1.0 || type1 == 2.0)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    selectedPokemons[0].move2Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(pokemonMove2Damage);

                }
                else if (selectedPokemons[0].move2Damage < 10 && selectedPokemons[0].pokemonBurning == false && type1 == 0.5)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 15 * randomPercentage;
                    selectedPokemons[0].move2Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(pokemonMove2Damage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(pokemonMove2Damage);
                }

                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                UpdateEnemyProgressBar();
                lblDamageText.Text = $"Damage: {selectedPokemons[0].move2Damage}";
                totalDamage = totalDamage + selectedPokemons[0].move2Damage;
                selectedPokemons[0].move2Damage = selectedPokemons[0].startMove2Damage;

                usedMove2 = false;
            }
            else if (usedMove3)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double pokemonMove3Damage = (int)(((((2 * 50 * critical) / 5 + 2) * selectedPokemons[0].move3Damage * (selectedPokemons[0].attack / enemyPokemons[enemyIndex].defense) / 50) + 2) * type1 * type2 * randomPercentage);
                selectedPokemons[0].move3Damage = Convert.ToInt32(pokemonMove3Damage);

                if (selectedPokemons[0].pokemonBurning)
                {
                    selectedPokemons[0].move3Damage = selectedPokemons[0].move3Damage / 2;
                }
                if (selectedPokemons[0].move3Damage < 10 && selectedPokemons[0].pokemonBurning == false && type1 == 1.0 || type1 == 2.0)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    selectedPokemons[0].move3Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(pokemonMove3Damage);

                }
                else if (selectedPokemons[0].move3Damage < 10 && selectedPokemons[0].pokemonBurning == false && type1 == 0.5)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 15 * randomPercentage;
                    selectedPokemons[0].move3Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(pokemonMove3Damage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(pokemonMove3Damage);
                }

                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move3Damage, 0);
                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                UpdateEnemyProgressBar();
                lblDamageText.Text = $"Damage: {selectedPokemons[0].move3Damage}";
                totalDamage = totalDamage + selectedPokemons[0].move3Damage;
                selectedPokemons[0].move3Damage = selectedPokemons[0].startMove3Damage;

                usedMove3 = false;
            }
            else if (usedMove4)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double pokemonMove4Damage = (int)(((((2 * 50 * critical) / 5 + 2) * selectedPokemons[0].move4Damage * (selectedPokemons[0].attack / enemyPokemons[enemyIndex].defense) / 50) + 2) * type1 * type2 * randomPercentage);
                selectedPokemons[0].move4Damage = Convert.ToInt32(pokemonMove4Damage);

                if (selectedPokemons[0].pokemonBurning)
                {
                    selectedPokemons[0].move4Damage = selectedPokemons[0].move4Damage / 2;
                }
                if (selectedPokemons[0].move4Damage < 10 && selectedPokemons[0].pokemonBurning == false && type1 == 1.0 || type1 == 2.0)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    selectedPokemons[0].move4Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(pokemonMove4Damage);

                }
                else if (selectedPokemons[0].move4Damage < 10 && selectedPokemons[0].pokemonBurning == false && type1 == 0.5)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 15 * randomPercentage;
                    selectedPokemons[0].move4Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(pokemonMove4Damage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(pokemonMove4Damage);
                }

                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move4Damage, 0);
                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyRandomIndex].pokemonHealth}/{enemyPokemons[enemyRandomIndex].pokemonStartHealth}";
                UpdateEnemyProgressBar();
                lblDamageText.Text = $"Damage: {selectedPokemons[0].move4Damage}";
                totalDamage = totalDamage + selectedPokemons[0].move4Damage;
                selectedPokemons[0].move4Damage = selectedPokemons[0].startMove4Damage;

                usedMove4 = false;
            }
        }

        private void SpecialDamageCalculation()
        {

            if (usedMove1)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                double pokemonMove1SpecialDamage = (((2 * selectedPokemons[0].specialAttack) * selectedPokemons[0].move1Damage * (enemyPokemons[enemyIndex].specialDefence / 50) / enemyPokemons[enemyIndex].defense / 3.5 * randomPercentage) + 2);
                selectedPokemons[0].move1Damage = Convert.ToInt32(pokemonMove1SpecialDamage);
                calculatedDamage = Convert.ToInt32(pokemonMove1SpecialDamage);

                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move1Damage, 0);
                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                UpdateEnemyProgressBar();
                lblDamageText.Text = $"Damage: {selectedPokemons[0].move1Damage}";
                totalDamage = totalDamage + selectedPokemons[0].move1Damage;
                selectedPokemons[0].move1Damage = selectedPokemons[0].startMove1Damage;

                usedMove1 = false;
            }
            else if (usedMove2)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double pokemonMove2SpecialDamage = ((2 * selectedPokemons[0].specialAttack * selectedPokemons[0].move2Damage * (enemyPokemons[enemyIndex].specialDefence / 50) / enemyPokemons[enemyIndex].defense / 3.5 * randomPercentage) + 2);
                selectedPokemons[0].move2Damage = Convert.ToInt32(pokemonMove2SpecialDamage);
                calculatedDamage = Convert.ToInt32(pokemonMove2SpecialDamage);

                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move2Damage, 0);
                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                UpdateEnemyProgressBar();
                lblDamageText.Text = $"Damage: {selectedPokemons[0].move2Damage}";
                totalDamage = totalDamage + selectedPokemons[0].move2Damage;
                selectedPokemons[0].move2Damage = selectedPokemons[0].startMove2Damage;

                usedMove2 = false;
            }
            else if (usedMove3)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double pokemonMove3SpecialDamage = ((2 * selectedPokemons[0].specialAttack * selectedPokemons[0].move3Damage * (enemyPokemons[enemyIndex].specialDefence / 50) / enemyPokemons[enemyIndex].defense / 3.5 * randomPercentage) + 2);
                selectedPokemons[0].move3Damage = Convert.ToInt32(pokemonMove3SpecialDamage);
                calculatedDamage = Convert.ToInt32(pokemonMove3SpecialDamage);

                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move3Damage, 0);
                lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                UpdateEnemyProgressBar();
                lblDamageText.Text = $"Damage: {selectedPokemons[0].move3Damage}";
                totalDamage = totalDamage + selectedPokemons[0].move3Damage;
                selectedPokemons[0].move3Damage = selectedPokemons[0].startMove3Damage;

                usedMove3 = false;
            }
            else if (usedMove4)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                if (usedHex)
                {

                    selectedPokemons[0].specialAttack *= 2;
                    double pokemonMove4SpecialDamage = ((2 * selectedPokemons[0].specialAttack * selectedPokemons[0].move4Damage * (enemyPokemons[enemyIndex].specialDefence / 50) / enemyPokemons[enemyIndex].defense / 3.5 * randomPercentage) + 2);
                    selectedPokemons[0].move4Damage = Convert.ToInt32(pokemonMove4SpecialDamage);
                    if (selectedPokemons[0].move4Damage < 10)
                    {
                        selectedPokemons[0].move4Damage += 60;
                    }
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move4Damage, 0);
                    selectedPokemons[0].specialAttack /= 2;
                    calculatedDamage = Convert.ToInt32(pokemonMove4SpecialDamage);
                    usedHex = false;
                }
                else if(usedSurf)
                {
                    selectedPokemons[0].move4Damage = 45;
                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move4Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                    UpdateEnemyProgressBar();
                    calculatedDamage = selectedPokemons[0].move4Damage;
                    usedSurf = false;
                }
                else
                {
                    double pokemonMove4SpecialDamage = ((2 * selectedPokemons[0].specialAttack * selectedPokemons[0].move4Damage * (enemyPokemons[enemyIndex].specialDefence / 50) / enemyPokemons[enemyIndex].defense / 3.5 * randomPercentage) + 2);
                    selectedPokemons[0].move4Damage = Convert.ToInt32(pokemonMove4SpecialDamage);
                    calculatedDamage = Convert.ToInt32(pokemonMove4SpecialDamage);

                    enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - selectedPokemons[0].move4Damage, 0);
                    lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                }

                UpdateEnemyProgressBar();
                lblDamageText.Text = $"Damage: {selectedPokemons[0].move4Damage}";
                totalDamage = totalDamage + selectedPokemons[0].move4Damage;

                selectedPokemons[0].move4Damage = selectedPokemons[0].startMove4Damage;

                usedMove4 = false;
            }
        }
        private void EnemyPhysicalDamageCalculation()
        {
            switch (selectedPokemons[0].pokemonType)
            {
                case "Water":
                    if (enemyPokemons[enemyIndex].pokemonType == "Fire")
                    {
                        type1 = 0.5;
                    }
                    else if (enemyPokemons[enemyIndex].pokemonType == "Electric")
                    {
                        type1 = 2.0;
                    }
                    else if (enemyPokemons[enemyIndex].pokemonType == "Normal" || enemyPokemons[enemyIndex].pokemonType == "Ghost" || enemyPokemons[enemyIndex].pokemonType == "Fighting")
                    {
                        type1 = 1.0;
                    }
                    break;

                case "Fire":
                    if (selectedPokemons[0].pokemonType == "Water")
                    {
                        type1 = 2.0;
                    }
                    else if (enemyPokemons[enemyIndex].pokemonType == "Electric" || enemyPokemons[enemyIndex].pokemonType == "Normal" || enemyPokemons[enemyIndex].pokemonType == "Ghost" || enemyPokemons[enemyIndex].pokemonType == "Fighting")
                    {
                        type1 = 1.0;
                    }
                    break;

                case "Electric":
                    type1 = 1.0;
                    break;

                case "Normal":
                    if (enemyPokemons[enemyIndex].pokemonType == "Water" || enemyPokemons[enemyIndex].pokemonType == "Fire" || enemyPokemons[enemyIndex].pokemonType == "Electric")
                    {
                        type1 = 1.0;
                    }
                    else if (enemyPokemons[enemyIndex].pokemonType == "Ghost")
                    {
                        type1 = 0;
                    }
                    else if (enemyPokemons[enemyIndex].pokemonType == "Fighting")
                    {
                        type1 = 2.0;
                    }
                    break;

                case "Ghost":
                    if (enemyPokemons[enemyIndex].pokemonType == "Water" || enemyPokemons[enemyIndex].pokemonType == "Fire" || enemyPokemons[enemyIndex].pokemonType == "Electric")
                    {
                        type1 = 1.0;
                    }
                    else if (enemyPokemons[enemyIndex].pokemonType == "Normal" || enemyPokemons[enemyIndex].pokemonType == "Fighting")
                    {
                        type1 = 0;
                    }
                    break;

                case "Fighting":
                    type1 = 1;
                    break;

            }
            if (enemyPokemons[enemyIndex].pokemonCriticalHit)
            {
                critical = 2;
                enemyPokemons[enemyIndex].pokemonCriticalHit = false;
            }
            else
            {
                if (criticalIncreased)
                {
                    increasedCriticalChance = increasedCritical.Next(0, 4);
                    if (increasedCriticalChance == 0)
                    {
                        critical = 2;
                    }
                    else
                    {
                        critical = 1;
                    }
                    criticalIncreased = false;
                }
                else
                {
                    increasedCriticalChance = increasedCritical.Next(1, 17);
                    if (increasedCriticalChance == 16)
                    {
                        critical = 2;
                    }
                    else
                    {
                        critical = 1;
                    }
                }
            }

            if (enemyUsedMove1)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double enemyPokemonMove1Damage = (int)(((((2 * 50 * critical) / 5 + 2) * enemyPokemons[enemyIndex].move1Damage * (enemyPokemons[enemyIndex].attack / selectedPokemons[0].defense) / 50) + 2) * type1 * type2 * randomPercentage);
                enemyPokemons[enemyIndex].move1Damage = Convert.ToInt32(enemyPokemonMove1Damage);

                if (enemyPokemons[enemyIndex].pokemonBurning)
                {
                    enemyPokemons[enemyIndex].move1Damage = enemyPokemons[enemyIndex].move1Damage / 2;
                }
                if (enemyPokemons[enemyIndex].move1Damage < 10 && enemyPokemons[enemyIndex].pokemonBurning == false && type1 == 1.0 || type1 == 2.0)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    enemyPokemons[enemyIndex].move1Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove1Damage);

                }
                else if (enemyPokemons[enemyIndex].move1Damage < 10 && enemyPokemons[enemyIndex].pokemonBurning == false && type1 == 0.5)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 15 * randomPercentage;
                    enemyPokemons[enemyIndex].move1Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove1Damage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove1Damage);
                }
                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move1Damage, 0);
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();

                enemyPokemons[enemyIndex].move1Damage = enemyPokemons[enemyIndex].startMove1Damage;
                enemyUsedMove1 = false;

            }
            else if (enemyUsedMove2)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double enemyPokemonMove2Damage = (int)(((((2 * 50 * critical) / 5 + 2) * enemyPokemons[enemyIndex].move2Damage * (enemyPokemons[enemyIndex].attack / selectedPokemons[0].defense) / 50) + 2) * type1 * type2 * randomPercentage);
                enemyPokemons[enemyIndex].move2Damage = Convert.ToInt32(enemyPokemonMove2Damage);

                if (enemyPokemons[enemyIndex].pokemonBurning)
                {
                    enemyPokemons[enemyIndex].move2Damage = enemyPokemons[enemyIndex].move2Damage / 2;
                }
                if (enemyPokemons[enemyIndex].move2Damage < 10 && enemyPokemons[enemyIndex].pokemonBurning == false && type1 == 1.0 || type1 == 2.0)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    enemyPokemons[enemyIndex].move2Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove2Damage);

                }
                else if (enemyPokemons[enemyIndex].move2Damage < 10 && enemyPokemons[enemyIndex].pokemonBurning == false && type1 == 0.5)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 15 * randomPercentage;
                    enemyPokemons[enemyIndex].move2Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove2Damage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove2Damage);
                }
                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move2Damage, 0);
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();

                enemyPokemons[enemyIndex].move2Damage = enemyPokemons[enemyIndex].startMove2Damage;
                enemyUsedMove2 = false;
            }
            else if (enemyUsedMove3)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double enemyPokemonMove3Damage = (int)(((((2 * 50 * critical) / 5 + 2) * enemyPokemons[enemyIndex].move3Damage * (enemyPokemons[enemyIndex].attack / selectedPokemons[0].defense) / 50) + 2) * type1 * type2 * randomPercentage);
                enemyPokemons[enemyIndex].move3Damage = Convert.ToInt32(enemyPokemonMove3Damage);

                if (enemyPokemons[enemyIndex].pokemonBurning)
                {
                    enemyPokemons[enemyIndex].move3Damage = enemyPokemons[enemyIndex].move3Damage / 2;
                }
                if (enemyPokemons[enemyIndex].move3Damage < 10 && enemyPokemons[enemyIndex].pokemonBurning == false && type1 == 1.0 || type1 == 2.0)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    enemyPokemons[enemyIndex].move3Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove3Damage);
                }
                else if (enemyPokemons[enemyIndex].move3Damage < 10 && enemyPokemons[enemyIndex].pokemonBurning == false && type1 == 0.5)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 15 * randomPercentage;
                    enemyPokemons[enemyIndex].move3Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove3Damage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove3Damage);
                }
                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move3Damage, 0);
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();

                enemyPokemons[enemyIndex].move3Damage = enemyPokemons[enemyIndex].startMove3Damage;
                enemyUsedMove3 = false;
            }
            else if (enemyUsedMove4)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;

                double enemyPokemonMove4Damage = (int)(((((2 * 50 * critical) / 5 + 2) * enemyPokemons[enemyIndex].move4Damage * (enemyPokemons[enemyIndex].attack / selectedPokemons[0].defense) / 50) + 2) * type1 * type2 * randomPercentage);
                enemyPokemons[enemyIndex].move4Damage = Convert.ToInt32(enemyPokemonMove4Damage);

                if (enemyPokemons[enemyIndex].pokemonBurning)
                {
                    enemyPokemons[enemyIndex].move4Damage = enemyPokemons[enemyIndex].move4Damage / 2;
                }
                if (enemyPokemons[enemyIndex].move4Damage < 10 && enemyPokemons[enemyIndex].pokemonBurning == false && type1 == 1.0 || type1 == 2.0)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    enemyPokemons[enemyIndex].move4Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove4Damage);
                }
                else if (enemyPokemons[enemyIndex].move4Damage < 10 && enemyPokemons[enemyIndex].pokemonBurning == false && type1 == 0.5)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 15 * randomPercentage;
                    enemyPokemons[enemyIndex].move4Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove4Damage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove4Damage);
                }
                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move4Damage, 0);
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();

                enemyPokemons[enemyIndex].move4Damage = enemyPokemons[enemyIndex].startMove4Damage;
                enemyUsedMove4 = false;
            }
        }
        private void EnemySpecialDamageCalculation()
        {
            if (enemyUsedMove1)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                double enemyPokemonMove1SpecialDamage = ((2 * enemyPokemons[enemyIndex].specialAttack * enemyPokemons[enemyIndex].move1Damage * (selectedPokemons[0].specialDefence / 50) / selectedPokemons[0].defense / 3.5 * randomPercentage) + 2);
                enemyPokemons[enemyIndex].move1Damage = Convert.ToInt32(enemyPokemonMove1SpecialDamage);

                if (enemyPokemons[enemyIndex].move1Damage < 10)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    enemyPokemons[enemyIndex].move1Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove1SpecialDamage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove1SpecialDamage);
                }
                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move1Damage, 0);
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();
                totalDamage = totalDamage + selectedPokemons[0].move1Damage;
                enemyPokemons[enemyIndex].move1Damage = enemyPokemons[enemyIndex].startMove1Damage;
                enemyUsedMove1 = false;
            }
            else if (enemyUsedMove2)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                double enemyPokemonMove2SpecialDamage = ((2 * enemyPokemons[enemyIndex].specialAttack * enemyPokemons[enemyIndex].move2Damage * (selectedPokemons[0].specialDefence / 50) / selectedPokemons[0].defense / 3.5 * randomPercentage) + 2);
                enemyPokemons[enemyIndex].move2Damage = Convert.ToInt32(enemyPokemonMove2SpecialDamage);

                if (enemyPokemons[enemyIndex].move2Damage < 10)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    enemyPokemons[enemyIndex].move2Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove2SpecialDamage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove2SpecialDamage);
                }
                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move2Damage, 0);
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();
                totalDamage = totalDamage + selectedPokemons[0].move2Damage;
                enemyPokemons[enemyIndex].move2Damage = enemyPokemons[enemyIndex].startMove2Damage;
                enemyUsedMove2 = false;
            }
            else if (enemyUsedMove3)
            {
                randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                double enemyPokemonMove3SpecialDamage = ((2 * enemyPokemons[enemyIndex].specialAttack * enemyPokemons[enemyIndex].move3Damage * (selectedPokemons[0].specialDefence / 50) / selectedPokemons[0].defense / 3.5 * randomPercentage) + 2);
                enemyPokemons[enemyIndex].move3Damage = Convert.ToInt32(enemyPokemonMove3SpecialDamage);

                if (enemyPokemons[enemyIndex].move3Damage < 10)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double alternateDamage = 30 * randomPercentage;
                    enemyPokemons[enemyIndex].move3Damage = Convert.ToInt32(alternateDamage);
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove3SpecialDamage);
                }
                else
                {
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove3SpecialDamage);
                }
                selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move3Damage, 0);
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();
                totalDamage = totalDamage + selectedPokemons[0].move3Damage;
                enemyPokemons[enemyIndex].move3Damage = enemyPokemons[enemyIndex].startMove3Damage;
                enemyUsedMove3 = false;
            }
            else if (enemyUsedMove4)
            {
                if (usedHex)
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    enemyPokemons[enemyIndex].specialAttack *= 2;
                    double enemyPokemonMove4SpecialDamage = ((2 * enemyPokemons[enemyIndex].specialAttack * enemyPokemons[enemyIndex].move4Damage * (selectedPokemons[0].specialDefence / 50) / selectedPokemons[0].defense / 3.5 * randomPercentage) + 2);
                    enemyPokemons[enemyIndex].move4Damage = Convert.ToInt32(enemyPokemonMove4SpecialDamage);
                    selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move4Damage, 0);
                    enemyPokemons[enemyIndex].specialAttack /= 2;
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove4SpecialDamage);
                    usedHex = false;
                }
                else
                {
                    randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                    double enemyPokemonMove4SpecialDamage = ((2 * enemyPokemons[enemyIndex].specialAttack * enemyPokemons[enemyIndex].move4Damage * (selectedPokemons[0].specialDefence / 50) / selectedPokemons[0].defense / 3.5 * randomPercentage) + 2);
                    enemyPokemons[enemyIndex].move4Damage = Convert.ToInt32(enemyPokemonMove4SpecialDamage);
                    if (enemyPokemons[enemyIndex].move4Damage < 10)
                    {
                        randomPercentage = damageCalculation.Next(85, 101) / 100.0;
                        double alternateDamage = 30 * randomPercentage;
                        enemyPokemons[enemyIndex].move4Damage = Convert.ToInt32(alternateDamage);

                    }
                    calculatedDamage = Convert.ToInt32(enemyPokemonMove4SpecialDamage);
                    selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move4Damage, 0);
                }
                lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                UpdateProgressBar();
                totalDamage = totalDamage + selectedPokemons[0].move4Damage;
                enemyPokemons[enemyIndex].move4Damage = enemyPokemons[enemyIndex].startMove4Damage;
                enemyUsedMove4 = false;
            }

        }
        private async Task EnemysTurn()
        {
            playerTurn = false;
            MoveButtonsHidden();
            HideBag();
            enemyMove = enemy.Next(0, 4); // 4
            if (enemyPokemons[enemyIndex].pokemonParalyzed)
            {
                lblParalyzed2.Visible = true;
                enemyPokemons[enemyIndex].pokemonConfused = false;
                lblConfused2.Visible = false;
                enemyPokemons[enemyIndex].pokemonBurning = false;
                lblBurning2.Visible = false;
                enemyPokemons[enemyIndex].pokemonSleeping = false;
                lblSleeping2.Visible = false;

                enemyParalysisIndex++;
                if (enemyParalysisIndex >= 5)
                {
                    enemyParalysisIndex = 0;
                    enemyPokemons[enemyIndex].pokemonParalyzed = false;
                    await Task.Delay(2000);
                    lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is no longer paralyzed!";
                    lblParalyzed2.Visible = false;
                    await Task.Delay(3000);
                }
            }
            else if (enemyPokemons[enemyIndex].pokemonConfused)
            {
                lblConfused2.Visible = true;
                enemyPokemons[enemyIndex].pokemonParalyzed = false;
                lblParalyzed2.Visible = false;
                enemyPokemons[enemyIndex].pokemonBurning = false;
                lblBurning2.Visible = false;
                enemyPokemons[enemyIndex].pokemonSleeping = false;
                lblSleeping2.Visible = false;

                enemyConfuseIndex++;
                if (enemyConfuseIndex >= 6)
                {
                    enemyConfuseIndex = 0;
                    enemyPokemons[enemyIndex].pokemonConfused = false;
                    await Task.Delay(2000);
                    lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is no longer confused!";
                    lblConfused2.Visible = false;
                    await Task.Delay(3000);
                }
            }
            else if (enemyPokemons[enemyIndex].pokemonSleeping)
            {
                lblSleeping2.Visible = true;
                enemyPokemons[enemyIndex].pokemonParalyzed = false;
                lblParalyzed2.Visible = false;
                enemyPokemons[enemyIndex].pokemonBurning = false;
                lblBurning2.Visible = false;
                enemyPokemons[enemyIndex].pokemonConfused = false;
                lblConfused2.Visible = false;

                enemySleepIndex++;
                if (enemySleepIndex >= 8)
                {
                    enemySleepIndex = 0;
                    enemyPokemons[enemyIndex].pokemonSleeping = false;
                    await Task.Delay(2000);
                    lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} woke up!";
                    lblSleeping2.Visible = false;
                    await Task.Delay(3000);
                }
            }
            else if (enemyPokemons[enemyIndex].pokemonBurning)
            {
                lblBurning2.Visible = true;
                enemyPokemons[enemyIndex].pokemonParalyzed = false;
                lblParalyzed2.Visible = false;
                enemyPokemons[enemyIndex].pokemonSleeping = false;
                lblSleeping2.Visible = false;
                enemyPokemons[enemyIndex].pokemonConfused = false;
                lblConfused2.Visible = false;
            }


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
                        confuseChance = confuse.Next(0, 3); //3
                        paralysisChance = paralysis.Next(0, 4);
                        if (enemyPokemons[enemyIndex].pokemonParalyzed && paralysisChance == 1)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fully paralyzed and unable to move!";
                        }
                        else if (enemyPokemons[enemyIndex].pokemonSleeping)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fast asleep!";
                            await EnemyHealing();
                        }
                        else if (enemyPokemons[enemyIndex].pokemonConfused)
                        {
                            if (confuseChance == 0)
                            {
                                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is confused, and hurt itself in confusion!";
                                randomChance = Random.Next(10, 21);
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - randomChance, 0);
                                UpdateEnemyProgressBar();
                                await EnemyPokemonFaints();
                            }

                        }
                        else
                        {
                            switch (enemyMove)
                            {

                                case 0: //Dragon Rage
                                    enemyUsedMove1 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        selectedPokemons[0].pokemonHealth = Math.Max(selectedPokemons[0].pokemonHealth - enemyPokemons[enemyIndex].move1Damage, 0);
                                        lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                        UpdateProgressBar();
                                        await MoveEffectivenes();
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 1: //Bite
                                    enemyUsedMove2 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                        EnemyPhysicalDamageCalculation();
                                        await MoveEffectivenes();

                                        flinchChance = flinch.Next(0, 3);
                                        if (flinchChance == 0)
                                        {
                                            selectedPokemons[0].pokemonFlinch = true;
                                            UpdateProgressBar();
                                        }
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 2: //Bubblebeam
                                    enemyUsedMove3 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                        EnemySpecialDamageCalculation();
                                        await MoveEffectivenes();
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 3: //Hydro Pump
                                    enemyUsedMove4 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                        EnemySpecialDamageCalculation();
                                        await MoveEffectivenes();
                                        await PlayerPokemonFaints();
                                    }
                                    break;
                            }
                        }
                    }
                    await EnemyPokemonStatusCondition();
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    await PlayersTurn();
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
                        paralysisChance = paralysis.Next(0, 2); //2
                        confuseChance = confuse.Next(0, 3); //3
                        if (enemyPokemons[enemyIndex].pokemonConfused)
                        {
                            if (confuseChance == 0)
                            {
                                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is confused, and hurt itself in confusion!";
                                randomChance = Random.Next(10, 21);
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - randomChance, 0);
                                UpdateEnemyProgressBar();
                                await EnemyPokemonFaints();
                            }

                        }
                        else if (enemyPokemons[enemyIndex].pokemonParalyzed && paralysisChance == 0)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fully paralyzed and unable to move!";
                        }
                        else if (enemyPokemons[enemyIndex].pokemonSleeping)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fast asleep!";
                            await EnemyHealing();
                        }
                        else
                        {
                            switch (enemyMove)
                            {
                                case 0: //Dragon Claw
                                    enemyUsedMove1 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                        EnemyPhysicalDamageCalculation();
                                        await MoveEffectivenes();
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 1: //Ember
                                    enemyUsedMove2 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                        EnemySpecialDamageCalculation();
                                        await MoveEffectivenes();

                                        burningChance = burn.Next(0, 10);
                                        if (burningChance == 0)
                                        {
                                            selectedPokemons[0].pokemonBurning = true;
                                            lblBurning.Visible = true;
                                        }
                                        await PlayerPokemonFaints();
                                    }

                                    break;

                                case 2: //Dragon Breath
                                    enemyUsedMove3 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                        EnemySpecialDamageCalculation();
                                        await MoveEffectivenes();

                                        paralysisChance = paralysis.Next(0, 3);
                                        if (paralysisChance == 0)
                                        {
                                            selectedPokemons[0].pokemonParalyzed = true;
                                            lblParalyzed.Visible = true;
                                            await PokemonParalyzedEnemy();
                                        }
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 3: //Growl
                                    enemyUsedMove4 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                        if (enemyAttackFellIndex >= 3)
                                        {
                                            await Task.Delay(2000);
                                            lblText.Text = $"{enemyPokemons[enemyIndex].move4} failed!";
                                        }
                                        else
                                        {
                                            selectedPokemons[0].move1Damage = selectedPokemons[0].move1Damage - 20;
                                            selectedPokemons[0].move2Damage = selectedPokemons[0].move2Damage - 20;
                                            selectedPokemons[0].move3Damage = selectedPokemons[0].move3Damage - 20;
                                            selectedPokemons[0].move4Damage = selectedPokemons[0].move4Damage - 20;
                                            enemyAttackFellIndex++;
                                            attackFell = true;
                                            PlayerAttackFell();
                                        }
                                        await PlayerPokemonFaints();
                                    }
                                    break;
                            }
                        }
                    }
                    await EnemyPokemonStatusCondition();
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    await PlayersTurn();
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

                        paralysisChance = paralysis.Next(0, 2); //2
                        confuseChance = confuse.Next(0, 3); //3
                        if (enemyPokemons[enemyIndex].pokemonConfused)
                        {
                            if (confuseChance == 0)
                            {
                                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is confused, and hurt itself in confusion!";
                                randomChance = Random.Next(10, 21);
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - randomChance, 0);
                                UpdateEnemyProgressBar();
                                await EnemyPokemonFaints();
                            }

                        }
                        else if (enemyPokemons[enemyIndex].pokemonParalyzed && paralysisChance == 0)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fully paralyzed and unable to move!";
                        }
                        else if (enemyPokemons[enemyIndex].pokemonSleeping)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fast asleep!";
                            await EnemyHealing();
                        }
                        else
                        {
                            switch (enemyMove)
                            {
                                case 0: //Drill Peck
                                    enemyUsedMove1 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                        EnemySpecialDamageCalculation();
                                        await MoveEffectivenes();
                                        await PlayerPokemonFaints();
                                    }

                                    break;

                                case 1: // Thunder Shock
                                    enemyUsedMove2 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                        EnemySpecialDamageCalculation();
                                        await MoveEffectivenes();
                                        paralysisChance = paralysis.Next(0, 10);
                                        if (paralysisChance == 2)
                                        {
                                            selectedPokemons[0].pokemonParalyzed = true;
                                            lblParalyzed.Visible = true;
                                            await PokemonParalyzedEnemy();
                                        }
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 2: //Thunder Wave
                                    enemyUsedMove3 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                        selectedPokemons[0].pokemonParalyzed = true;
                                        lblParalyzed.Visible = true;
                                        await PokemonParalyzedEnemy();
                                        await PlayerPokemonFaints();

                                    }

                                    break;

                                case 3: //Charge
                                    enemyUsedMove4 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                        if (enemyDefenceUpIndex >= 3)
                                        {
                                            await Task.Delay(3000);
                                            lblText.Text = $"{enemyPokemons[enemyIndex].move4} failed!";
                                        }
                                        else
                                        {
                                            await Task.Delay(3000);
                                            lblText.Text = $"It rose it's Special Defence!";
                                            enemyPokemons[enemyIndex].specialDefence += 10;
                                            enemyDefenceUpIndex++;
                                        }
                                        await PlayerPokemonFaints();
                                    }
                                    break;
                            }
                        }

                    }
                    await EnemyPokemonStatusCondition();
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    await PlayersTurn();
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
                        paralysisChance = paralysis.Next(0, 2); //2
                        confuseChance = confuse.Next(0, 3); //3
                        if (enemyPokemons[enemyIndex].pokemonConfused)
                        {
                            if (confuseChance == 0)
                            {
                                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is confused, and hurt itself in confusion!";
                                randomChance = Random.Next(10, 21);
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - randomChance, 0);
                                UpdateEnemyProgressBar();
                                await EnemyPokemonFaints();
                            }

                        }
                        else if (enemyPokemons[enemyIndex].pokemonParalyzed && paralysisChance == 0)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fully paralyzed and unable to move!";
                        }
                        else if (enemyPokemons[enemyIndex].pokemonSleeping)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fast asleep!";
                            await EnemyHealing();
                        }
                        else
                        {
                            switch (enemyMove)
                            {
                                case 0: //Body Slam
                                    enemyUsedMove1 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                        EnemyPhysicalDamageCalculation();
                                        await MoveEffectivenes();

                                        paralysisChance = paralysis.Next(0, 3);
                                        if (paralysisChance == 0)
                                        {
                                            selectedPokemons[0].pokemonParalyzed = true;
                                            lblParalyzed.Visible = true;
                                            await PokemonParalyzedEnemy();
                                        }
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 1: //Belly Drum
                                    enemyUsedMove2 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                        if (enemyPokemons[enemyIndex].pokemonHealth < enemyPokemons[enemyIndex].pokemonStartHealth / 2)
                                        {
                                            await Task.Delay(3000);
                                            lblText.Text = $"Belly Drum failed!";
                                        }
                                        else
                                        {
                                            enemyPokemons[enemyIndex].attack += 30;
                                            enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth / 2, 0);
                                            enemyPokemonHealthBar.Value = Math.Min(enemyPokemons[enemyIndex].pokemonHealth / 2, enemyPokemonHealthBar.Maximum);
                                        }
                                        UpdateEnemyProgressBar();
                                        UpdateProgressBar();
                                        await EnemyPokemonFaints();
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 2: // Double-Edge
                                    enemyUsedMove3 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                        EnemyPhysicalDamageCalculation();
                                        await MoveEffectivenes();
                                        enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - calculatedDamage / 4, 0);
                                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                                        UpdateEnemyProgressBar();
                                        UpdateProgressBar();
                                        await EnemyPokemonFaints();
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 3: // Surf
                                    enemyUsedMove4 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                        EnemySpecialDamageCalculation();
                                        await MoveEffectivenes();
                                        await PlayerPokemonFaints();
                                    }
                                    break;
                            }
                        }


                    }
                    await EnemyPokemonStatusCondition();
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    await PlayersTurn();
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
                        paralysisChance = paralysis.Next(0, 2); //2
                        confuseChance = confuse.Next(0, 3); //3
                        if (enemyPokemons[enemyIndex].pokemonConfused)
                        {
                            if (confuseChance == 0)
                            {
                                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is confused, and hurt itself in confusion!";
                                randomChance = Random.Next(10, 21);
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - randomChance, 0);
                                UpdateEnemyProgressBar();
                                await EnemyPokemonFaints();
                            }

                        }
                        else if (enemyPokemons[enemyIndex].pokemonParalyzed && paralysisChance == 0)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fully paralyzed and unable to move!";
                        }
                        else if (enemyPokemons[enemyIndex].pokemonSleeping)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fast asleep!";
                            await EnemyHealing();
                        }
                        else
                        {
                            switch (enemyMove)
                            {
                                case 0: // Confuse Ray
                                    enemyUsedMove1 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                        selectedPokemons[0].pokemonConfused = true;
                                        lblConfused.Visible = true;
                                        selectedPokemons[0].pokemonParalyzed = false;
                                        selectedPokemons[0].pokemonSleeping = false;
                                        selectedPokemons[0].pokemonBurning = false;
                                        lblParalyzed.Visible = false;
                                        lblSleeping.Visible = false;
                                        lblBurning.Visible = false;
                                    }
                                    break;

                                case 1: // Lick
                                    enemyUsedMove2 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                        EnemyPhysicalDamageCalculation();
                                        await MoveEffectivenes();
                                        paralysisChance = paralysis.Next(0, 3);
                                        if (paralysisChance == 0)
                                        {
                                            selectedPokemons[0].pokemonParalyzed = true;
                                            lblParalyzed.Visible = true;
                                            await PokemonParalyzedEnemy();
                                        }
                                        await PlayerPokemonFaints();
                                    }
                                    break;

                                case 2: // Hypnosis
                                    enemyUsedMove3 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        sleepingChance = sleep.Next(0, 3); // 3
                                        if (sleepingChance == 0)
                                        {
                                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                            selectedPokemons[0].pokemonSleeping = true;
                                            await PokemonSleeping();
                                            await PlayerPokemonFaints();
                                        }
                                        else
                                        {
                                            lblText.Text = $"Hypnosis missed!";
                                            await PlayerPokemonFaints();
                                        }
                                    }
                                    break;

                                case 3: // Hex
                                    enemyUsedMove4 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        if (selectedPokemons[0].pokemonParalyzed || selectedPokemons[0].pokemonBurning || selectedPokemons[0].pokemonSleeping || selectedPokemons[0].pokemonConfused)
                                        {
                                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}, it does double damage!";
                                            usedHex = true;
                                            EnemySpecialDamageCalculation();
                                            await MoveEffectivenes();

                                            await PlayerPokemonFaints();
                                        }
                                        else
                                        {
                                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                            EnemySpecialDamageCalculation();
                                            await MoveEffectivenes();

                                            await PlayerPokemonFaints();
                                        }
                                    }
                                    break;
                            }
                        }

                    }
                    await EnemyPokemonStatusCondition();
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    await PlayersTurn();
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
                        paralysisChance = paralysis.Next(0, 2); //2
                        confuseChance = confuse.Next(0, 3); //3
                        if (enemyPokemons[enemyIndex].pokemonConfused)
                        {
                            if (confuseChance == 0)
                            {
                                lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is confused, and hurt itself in confusion!";
                                randomChance = Random.Next(10, 21);
                                enemyPokemons[enemyIndex].pokemonHealth = Math.Max(enemyPokemons[enemyIndex].pokemonHealth - randomChance, 0);
                                UpdateEnemyProgressBar();
                                await EnemyPokemonFaints();
                            }

                        }
                        else if (enemyPokemons[enemyIndex].pokemonParalyzed && paralysisChance == 0)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fully paralyzed and unable to move!";
                        }
                        else if (enemyPokemons[enemyIndex].pokemonSleeping)
                        {
                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} is fast asleep!";
                            await EnemyHealing();
                        }
                        else
                        {
                            switch (enemyMove)
                            {
                                case 0: // Karate Chop
                                    enemyUsedMove1 = true;
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        increasedCriticalChance = increasedCritical.Next(0, 9);
                                        if (increasedCriticalChance == 0)
                                        {
                                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                            enemyPokemons[enemyIndex].pokemonCriticalHit = true;
                                            EnemyPhysicalDamageCalculation();
                                            await MoveEffectivenes();
                                            await PlayerPokemonFaints();
                                            CriticalHitEnemy();
                                        }
                                        else
                                        {
                                            lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move1}!";
                                            EnemyPhysicalDamageCalculation();
                                            await MoveEffectivenes();

                                            await PlayerPokemonFaints();
                                        }
                                    }
                                    break;

                                case 1: // Leer
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move2}!";
                                        if (enemyLeerIndex <= 3)
                                        {
                                            selectedPokemons[0].defense = Math.Max(selectedPokemons[0].defense - selectedPokemons[0].defense - 10, 0);
                                            await PlayerPokemonFaints();
                                            enemyLeerIndex++;
                                        }
                                        else
                                        {
                                            await Task.Delay(3000);
                                            lblText.Text = $"It failed!";

                                        }
                                    }
                                    break;

                                case 2: // Focus Energy
                                    await EnemyHealing();
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move3}!";
                                        criticalIncreased = true;
                                        await PlayerPokemonFaints();
                                    }

                                    break;

                                case 3: // Submission
                                    await EnemyHealing();
                                    enemyUsedMove4 = true;
                                    if (healing == 0)
                                    {

                                    }
                                    else
                                    {
                                        lblText.Text = $"Foe {enemyPokemons[enemyIndex].pokemonName} used {enemyPokemons[enemyIndex].move4}!";
                                        EnemyPhysicalDamageCalculation();
                                        await MoveEffectivenes();
                                        enemyPokemonHealthBar.Value = Math.Max(enemyPokemonHealthBar.Value - calculatedDamage / 4, 0);
                                        lblEnemyPokemonHealth.Text = $"{enemyPokemons[enemyIndex].pokemonHealth}/{enemyPokemons[enemyIndex].pokemonStartHealth}";
                                        UpdateEnemyProgressBar();
                                        await EnemyPokemonFaints();
                                        await PlayerPokemonFaints();
                                    }
                                    break;
                            }
                        }

                    }
                    await EnemyPokemonStatusCondition();
                    enemyHasAttacked = true;
                    await Task.Delay(turnDelaySec * 1000);
                    enemyTurnInProgress = false;
                    await PlayersTurn();
                }

            }
        }
    }
}
